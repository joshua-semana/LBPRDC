using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;

namespace LBPRDC.Source.Views.Billing
{
    public partial class BillingInformationForm : Form
    {
        public string? BillingName { get; set; }
        public string? Type { get; set; }
        public BillingControl? ParentControl { get; set; }
        public Services.Billing? BillingInformation { get; set; }

        readonly List<Control>? RequiredFields;

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
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(RequiredFields))
            {
                if (Type == "Update") { UpdateBillingInformation(); }
                else if (Type == "Duplicate") { DuplicateBilling(); }
            }
        }

        private void UpdateBillingInformation()
        {
            Services.Billing billingInformation = new()
            {
                Name = BillingName,
                Description = txtDescription.Text.Trim(),
                OfficerName = txtOfficerName.Text.ToUpper().Trim(),
                OfficerPosition = txtOfficerPosition.Text.ToUpper().Trim()
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

        private void DuplicateBilling()
        {
            frmLoading form = new()
            {
                BillingProcess = Task.Run(() => BillingService.GetAllBillingDetailsByName(BillingName)),
                Description = "Retrieving billing information..."
            };

            var output = form.ShowDialog();

            if (output == DialogResult.OK)
            {
                Services.Billing defaultBilling = new();
                bool hasData = !Equals(defaultBilling, form.BillingResult);

                if (hasData)
                {
                    Services.Billing parentBilling = form.BillingResult;
                    Services.Billing newBilling = new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        Name = $"Copy of {BillingName}",
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
    }
}
