using LBPRDC.Source.Config;
using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using static LBPRDC.Source.Config.MessagesConstants;
using static LBPRDC.Source.Models.Billing;

namespace LBPRDC.Source.Views.Billing
{
    public partial class BillingInformationForm : Form
    {
        public BillingControl? ParentControl { get; set; }
        public int ClientID { get; set; }
        public Models.Billing BillingCompleteInfo { get; set; } = new();
        public Models.Billing.Account AccountEquipmentInfo { get; set; } = new();
        public string? Type { get; set; }

        readonly List<Control> RequiredFields;

        public BillingInformationForm()
        {
            InitializeComponent();

            RequiredFields = new()
            {
                txtOfficerName,
                txtOfficerPosition
            };
        }

        private void BillingInformationForm_Load(object sender, EventArgs e)
        {
            if (ClientID == 0 || BillingCompleteInfo == null)
            {
                MessageBox.Show(Error.MISSING_BILLING, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            var billing = BillingCompleteInfo;
            var account = AccountEquipmentInfo;

            Text = (Type == StringConstants.Operations.UPDATE) ? $"Update of {billing.Name}" : $"Duplicate {billing.Name}";
            txtDescription.Text = (Type == StringConstants.Operations.UPDATE) ? billing.Description : "Billing Duplicate";
            txtOfficerName.Text = Utilities.StringFormat.ToSentenceCase(billing.OfficerName);
            txtOfficerPosition.Text = Utilities.StringFormat.ToSentenceCase(billing.OfficerPosition);

            if (Type == StringConstants.Operations.UPDATE)
            {
                pnlEquipmentsGroup.Enabled = billing.ReleaseDate == null;
            }
            else if (Type == StringConstants.Operations.DUPLICATE)
            {
                pnlEquipmentsGroup.Enabled = true;
            }

            chkIncludeEquipments.Checked = billing.IsEquipmentIncluded;

            if (billing.IsEquipmentIncluded && account != null)
            {
                txtEquipmentsBilledValue.Text = $"{account.BilledValue:N2}";
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(RequiredFields))
            {
                if (Type == StringConstants.Operations.UPDATE) { UpdateBillingInformation(); }
                else if (Type == StringConstants.Operations.DUPLICATE) { DuplicateBilling(); }
            }
        }

        private async void UpdateBillingInformation()
        {
            try
            {
                var clientInfo = await ClientService.GetClientByID(ClientID);

                if (clientInfo == null)
                {
                    MessageBox.Show(Error.MISSING_CLIENT, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var billing = BillingCompleteInfo;
                var account = AccountEquipmentInfo;

                bool isInformationTaskDone = false;
                bool isEquipmentTaskDone = false;

                isInformationTaskDone = await BillingService.Update(new Models.Billing
                {
                    ID = billing.ID,
                    Description = txtDescription.Text.Trim(),
                    OfficerName = txtOfficerName.Text.ToUpper().Trim(),
                    OfficerPosition = txtOfficerPosition.Text.ToUpper().Trim(),
                    IsEquipmentIncluded = chkIncludeEquipments.Checked
                });

                if (chkIncludeEquipments.Checked != billing.IsEquipmentIncluded)
                {
                    if (chkIncludeEquipments.Checked)
                    {
                        string accountYear = billing.Year.ToString();
                        string accountMonth = billing.Month.ToString("D3");
                        decimal amount = Convert.ToDecimal(txtEquipmentsBilledValue.Text);

                        Models.Billing.Account equipmentAccount = new()
                        {
                            ClientID = billing.ClientID,
                            BillingID = billing.ID,
                            AccountNumber = $"{clientInfo.Name}Equip{accountYear}-{accountMonth}",
                            EntryType = StringConstants.Type.EQUIPMENT,
                            Classification = $"{clientInfo.Name} {StringConstants.Type.EQUIPMENT}",
                            BilledValue = amount,
                            NetBilling = amount - NumericConstants.GetNetBilling(amount),
                            Balance = amount,
                            Timestamp = DateTime.Now,
                            Remarks = StringConstants.Remarks.DEFAULT_BILLING_EQUIPMENT
                        };

                        isEquipmentTaskDone = await BillingAccountService.AddSingleAsync(equipmentAccount);
                    }
                    else
                    {
                        if (account != null)
                        {
                            isEquipmentTaskDone = await BillingAccountService.RemoveByID(account.ID);
                        }
                    }
                }
                else if (billing.IsEquipmentIncluded && account != null && Convert.ToDecimal(txtEquipmentsBilledValue.Text) != account.BilledValue)
                {
                    decimal value = Convert.ToDecimal(txtEquipmentsBilledValue.Text);
                    isEquipmentTaskDone = await BillingAccountService.UpdateBillingValue(account.ID, value);
                }
                else
                {
                    isEquipmentTaskDone = true;
                }

                if (isEquipmentTaskDone || isInformationTaskDone)
                {
                    ParentControl?.ResetView();
                    ParentControl?.ApplySearchThenPopulate();
                    Close();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        private async void DuplicateBilling()
        {
            try
            {
                var clientInfo = await ClientService.GetClientByID(ClientID);

                if (clientInfo == null)
                {
                    MessageBox.Show(Error.MISSING_CLIENT, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var billing = BillingCompleteInfo;

                bool isAccountAdded = false;
                string newBillingName = await BillingService.GetNewBillingNameForDuplication(billing.Name);

                Models.Billing newBilling = new()
                {
                    ClientID = ClientID,
                    UserID = UserService.CurrentUser.ID,
                    Name = newBillingName,
                    OfficerName = txtOfficerName.Text.ToUpper().Trim(),
                    OfficerPosition = txtOfficerPosition.Text.ToUpper().Trim(),
                    Month = billing.Month,
                    Year = billing.Year,
                    Quarter = billing.Quarter,
                    StartDate = billing.StartDate,
                    EndDate = billing.EndDate,
                    ConstantJSON = billing.ConstantJSON,
                    EditableJSON = billing.EditableJSON,
                    AccrualsJSON = billing.AccrualsJSON,
                    Description = txtDescription.Text.Trim(),
                    IsEquipmentIncluded = chkIncludeEquipments.Checked
                };

                var (isBillingAdded, LatestInsertedID) = await BillingService.Add(newBilling);

                if (isBillingAdded)
                {
                    if (chkIncludeEquipments.Checked)
                    {
                        string accountYear = billing.Year.ToString();
                        string accountMonth = billing.Month.ToString("D3");
                        decimal equipmentGrossAmount = Convert.ToDecimal(txtEquipmentsBilledValue.Text);

                        Models.Billing.Account account = new()
                        {
                            ClientID = ClientID,
                            BillingID = LatestInsertedID,
                            AccountNumber = $"{clientInfo.Name}Equip{accountYear}-{accountMonth}",
                            EntryType = StringConstants.Type.EQUIPMENT,
                            Classification = $"{clientInfo.Name} {StringConstants.Type.EQUIPMENT}",
                            BilledValue = equipmentGrossAmount,
                            NetBilling = equipmentGrossAmount - NumericConstants.GetNetBilling(equipmentGrossAmount),
                            Balance = equipmentGrossAmount
                        };

                        isAccountAdded = await BillingAccountService.AddSingleAsync(account);
                    }
                }

                if (isBillingAdded && !chkIncludeEquipments.Checked)
                {
                    MessageBox.Show(Add.SUCCESS_BILLING, SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (isBillingAdded && chkIncludeEquipments.Checked)
                {
                    if (isAccountAdded)
                    {
                        MessageBox.Show(Add.SUCCESS_BILLING, SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("A billing is duplicated but the equipment does not. Please add it later as custom entry.", ERROR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show(Error.ACTION, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ParentControl?.ResetTableSearch();
                ParentControl?.ResetView();
                this.Close();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkIncludeEquipments_CheckedChanged(object sender, EventArgs e)
        {
            txtEquipmentsBilledValue.Enabled = chkIncludeEquipments.Checked;
            if (chkIncludeEquipments.Checked)
            {
                RequiredFields.Add(txtEquipmentsBilledValue);
            }
            else
            {
                RequiredFields.Remove(txtEquipmentsBilledValue);
            }
        }

        private void ValidateInputIfNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.' || (e.KeyChar == '.' && (sender as TextBox)?.Text.Contains('.') == true)) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
