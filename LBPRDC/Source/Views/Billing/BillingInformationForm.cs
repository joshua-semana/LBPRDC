using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;

namespace LBPRDC.Source.Views.Billing
{
    public partial class BillingInformationForm : Form
    {
        public bool IsReleased { get; set; } = false;
        public string? BillingName { get; set; }
        public string? Type { get; set; }
        public BillingControl? ParentControl { get; set; }
        public Services.Billing BillingInformation { get; set; } = new();
        public bool IsEquipmentIncluded { get; set; }
        public string EquipmentAccountNumber { get; set; } = string.Empty;
        public decimal EquipmentsAmount { get; set; }

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
            Text = (Type == "Update") ? $"Update of {BillingName}" : $"Duplicate {BillingName}";
            txtDescription.Text = BillingInformation?.Description ?? "";
            txtOfficerName.Text = BillingInformation?.OfficerName ?? "";
            txtOfficerPosition.Text = BillingInformation?.OfficerPosition ?? "";

            pnlEquipmentsGroup.Enabled = !IsReleased;

            chkIncludeEquipments.Checked = IsEquipmentIncluded;
            txtEquipmentsBilledValue.Text = (IsEquipmentIncluded) ? $"{EquipmentsAmount:N2}" : "";

            txtDescription.Text = (Type == "Update") ? "" : "Billing Duplicate";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(RequiredFields))
            {
                if (Type == "Update") { UpdateBillingInformation(); }
                else if (Type == "Duplicate") { DuplicateBilling(); }
            }
        }

        private async void UpdateBillingInformation()
        {
            if (chkIncludeEquipments.Checked != IsEquipmentIncluded)
            {
                if (chkIncludeEquipments.Checked)
                {
                    List<BillingAccount> newAccount = new();

                    string accountYear = BillingInformation.Year.ToString();
                    string accountMonth = BillingInformation.Month.ToString("D3");
                    decimal equipmentGrossAmount = Convert.ToDecimal(txtEquipmentsBilledValue.Text);

                    newAccount.Add(new()
                    {
                        BillingName = BillingName,
                        AccountNumber = $"SHFCEquip{accountYear}-{accountMonth}",
                        EntryType = "Custom Entry",
                        OfficialReceiptNumber = "",
                        Classification = "SHFC Equipment",
                        BilledValue = equipmentGrossAmount,
                        NetBilling = equipmentGrossAmount - Convert.ToDecimal((double)equipmentGrossAmount / 1.12 * 0.07),
                        CollectedValue = 0,
                        CollectionDate = null,
                        Balance = equipmentGrossAmount,
                        Purpose = "",
                        Timestamp = DateTime.Now,
                        Remarks = "Supplies and Equipment Billing"
                    });

                    await Task.Run(() => BillingAccountService.Add(newAccount, BillingInformation.Name));
                }
                else
                {
                    await Task.Run(() => BillingAccountService.Remove(BillingName, EquipmentAccountNumber));
                }
            }
            else if (IsEquipmentIncluded && Convert.ToDecimal(txtEquipmentsBilledValue.Text) != EquipmentsAmount)
            {
                decimal billingValue = Convert.ToDecimal(txtEquipmentsBilledValue.Text);
                decimal netValue = Convert.ToDecimal((double)billingValue / 1.12 * 0.07);

                await Task.Run(() => BillingAccountService.UpdateEquipmentValue(EquipmentAccountNumber, BillingName, billingValue, netValue));
            }

            Services.Billing billingInformation = new()
            {
                Name = BillingName,
                Description = txtDescription.Text.Trim(),
                OfficerName = txtOfficerName.Text.ToUpper().Trim(),
                OfficerPosition = txtOfficerPosition.Text.ToUpper().Trim(),
                IsEquipmentIncluded = chkIncludeEquipments.Checked
            };

            frmLoading form = new()
            {
                BooleanProcess = Task.Run(() => BillingService.UpdateInformation(billingInformation)),
                Description = "Updating new billing information..."
            };

            var output = form.ShowDialog();

            if (output == DialogResult.OK)
            {
                MessageBox.Show("You have successfully updated the information of this billing. ", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ParentControl?.CloseDetails();
                ParentControl?.ApplySearchThenPopulate();
                Close();
            }
            else if (output == DialogResult.Abort)
            {
                MessageBox.Show("There is a problem updating the information of this billing, please try again.", "Update Not Successful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private async void DuplicateBilling()
        {
            frmLoading form = new()
            {
                BillingProcess = Task.Run(() => BillingService.GetAllBillingDetailsByName(BillingName)),
                StringProcess = Task.Run(() => BillingService.GetNewBillingNameForDuplication(BillingName)),
                Description = "Retrieving billing information..."
            };

            var output = form.ShowDialog();

            if (output == DialogResult.OK)
            {
                Services.Billing defaultBilling = new();
                bool hasData = !Equals(defaultBilling, form.BillingResult);

                if (hasData && !string.IsNullOrEmpty(form.StringResult))
                {
                    string newBillingName = form.StringResult;

                    Services.Billing parentBilling = form.BillingResult;
                    Services.Billing newBilling = new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        Name = newBillingName,
                        OfficerName = txtOfficerName.Text.ToUpper().Trim(),
                        OfficerPosition = txtOfficerPosition.Text.ToUpper().Trim(),
                        Month = parentBilling.Month,
                        Year = parentBilling.Year,
                        Quarter = parentBilling.Quarter,
                        StartDate = parentBilling.StartDate,
                        EndDate = parentBilling.EndDate,
                        Timestamp = DateTime.Now,
                        ReleaseDate = null,
                        ConstantJSON = parentBilling.ConstantJSON,
                        EditableJSON = parentBilling.EditableJSON,
                        AccrualsJSON = parentBilling.AccrualsJSON,
                        VerificationStatus = "Unverified",
                        Description = txtDescription.Text.Trim(),
                        IsEquipmentIncluded = chkIncludeEquipments.Checked,
                        Status = "Active",
                        LockStatus = "Unlock"
                    };

                    frmLoading form2 = new()
                    {
                        BooleanProcess = Task.Run(() => BillingService.Add(newBilling)),
                        Description = "Duplicating the billing, please wait..."
                    };

                    var output2 = form2.ShowDialog();

                    if (output2 == DialogResult.OK)
                    {
                        if (chkIncludeEquipments.Checked)
                        {
                            List<BillingAccount> newAccount = new();

                            string accountYear = parentBilling.Year.ToString();
                            string accountMonth = parentBilling.Month.ToString("D3");
                            decimal equipmentGrossAmount = Convert.ToDecimal(txtEquipmentsBilledValue.Text);

                            newAccount.Add(new()
                            {
                                BillingName = newBillingName,
                                AccountNumber = $"SHFCEquip{accountYear}-{accountMonth}",
                                EntryType = "Custom Entry",
                                OfficialReceiptNumber = "",
                                Classification = "SHFC Equipment",
                                BilledValue = equipmentGrossAmount,
                                NetBilling = equipmentGrossAmount - Convert.ToDecimal((double)equipmentGrossAmount / 1.12 * 0.07),
                                CollectedValue = 0,
                                CollectionDate = null,
                                Balance = equipmentGrossAmount,
                                Purpose = "",
                                Timestamp = DateTime.Now,
                                Remarks = "Supplies and Equipment Billing"
                            });

                            await Task.Run(() => BillingAccountService.Add(newAccount, parentBilling.Name));
                        }

                        MessageBox.Show("You have successfully duplicated this billing.", "Duplicate Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ParentControl?.CloseDetails();
                        ParentControl?.ApplySearchThenPopulate();
                        Close();
                    }
                    else if (output2 == DialogResult.Abort)
                    {
                        MessageBox.Show("There is a problem duplicating the billing; the system can't duplicate this billing.", "Duplicate Billing Not Successful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("There is a problem retrieving the information about the billing; the system can't duplicate this billing.", "Duplicate Billing Not Successful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (output == DialogResult.Abort)
            {
                MessageBox.Show("There is a problem retrieving the information about the billing; the system can't duplicate this billing.", "Duplicate Billing Not Successful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
    }
}
