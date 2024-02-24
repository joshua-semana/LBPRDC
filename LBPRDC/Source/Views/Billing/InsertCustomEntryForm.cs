using LBPRDC.Source.Services;

namespace LBPRDC.Source.Views.Billing
{
    public partial class InsertCustomEntryForm : Form
    {
        public Entry? NewEntry { get; private set; }
        public List<Entry>? EditableEntries { get; set; }
        public string? BillingName { get; set; }
        private readonly List<Control> RequiredFields;

        public InsertCustomEntryForm()
        {
            InitializeComponent();
            InitializeDepartmentComboBoxItems();
            InitializePositionComboBoxItems();

            RequiredFields = new()
            {
                txtFirstName,
                txtMiddleName,
                txtLastName,
                txtSalaryRate,
                txtBillingRate,
                cmbDepartment,
                cmbPosition
            };
        }

        private void InsertCustomEntryForm_Load(object sender, EventArgs e)
        {
            Text = $"Insert custom entry for {BillingName}";
        }

        private void InitializePositionComboBoxItems()
        {
            var positions = PositionService.GetAllItemsForComboBox();
            cmbPosition.DataSource = PositionService.GetAllItemsForComboBox();
            cmbPosition.DisplayMember = "Name";
            cmbPosition.ValueMember = "ID";
        }

        private void InitializeDepartmentComboBoxItems()
        {
            cmbDepartment.DataSource = DepartmentService.GetAllItemsForComboBox();
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "ID";
        }

        private void GetLocationComboBoxItems()
        {
            if (cmbDepartment.SelectedIndex != 0)
            {
                cmbLocation.Enabled = true;
                int DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
                cmbLocation.DataSource = LocationService.GetAllItemsForComboBoxByID(DepartmentID);
                cmbLocation.DisplayMember = "Name";
                cmbLocation.ValueMember = "ID";
            }
            else
            {
                cmbLocation.DataSource = null;
                cmbLocation.Enabled = false;
            }
        }

        private void CreateCustomEntry()
        {
            Guid newGuid = Guid.NewGuid();
            var localEntriesGuids = new HashSet<Guid>(EditableEntries.Select(e => e.Guid));
            var databaseGuids = new HashSet<Guid>(BillingRecordService.GetGuids());

            while (localEntriesGuids.Contains(newGuid) || databaseGuids.Contains(newGuid))
            {
                newGuid = Guid.NewGuid();
            }

            string position = (chkCustomPosition.Checked) ? txtCustomPosition.Text : cmbPosition.Text;

            NewEntry = new Entry
            {
                Guid = newGuid,
                EmployeeID = txtEmployeeID.Text.ToUpper().Trim(),
                FirstName = txtFirstName.Text.ToUpper().Trim(),
                MiddleName = txtMiddleName.Text.ToUpper().Trim(),
                LastName = txtLastName.Text.ToUpper().Trim(),
                FullName = $"{txtLastName.Text.ToUpper().Trim()}, {txtFirstName.Text.ToUpper().Trim()} {txtMiddleName.Text.ToUpper().Trim()[..1]}.",
                SalaryRate = Convert.ToDecimal(txtSalaryRate.Text),
                BillingRate = Convert.ToDecimal(txtBillingRate.Text),
                Department = cmbDepartment.Text,
                Location = cmbLocation.Text,
                PositionID = Convert.ToInt32(cmbPosition.SelectedValue),
                Position = position.ToUpper(),
                TimeDetails = new EntryTimeDetails
                {
                    RegularHours = TimeSpan.Zero,
                    LegalHoliday_100 = TimeSpan.Zero,
                    RegOT_125 = TimeSpan.Zero,
                    RestDaySpecialOT_130 = TimeSpan.Zero,
                    RestDaySpecialOTExcess_169 = TimeSpan.Zero,
                    SpecialExcessOT_195 = TimeSpan.Zero,
                    LegalHolidayOT_200 = TimeSpan.Zero,
                    LegalHolidayOT_260 = TimeSpan.Zero,
                    RestDaySpecialOT_150 = TimeSpan.Zero,
                    RegularHoliday_160 = TimeSpan.Zero,
                    NightDiff_10 = TimeSpan.Zero,
                    NightDiff_125 = TimeSpan.Zero,
                    NightDiff_130 = TimeSpan.Zero,
                    NightDiff_150 = TimeSpan.Zero,
                    NightDiff_20 = TimeSpan.Zero,
                    NightDiff_50 = TimeSpan.Zero,
                    UnderTime = TimeSpan.Zero,
                    Absent = TimeSpan.Zero,
                },
                EntryType = "Custom Entry",
                VerificationStatus = "Unverified",
                ExportIncluded = true
            };
            EditableEntries.Add(NewEntry);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (Utilities.ControlUtils.AreRequiredFieldsFilled(RequiredFields))
            {
                CreateCustomEntry();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel this operation?", "Cancel Operation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void ValidateInputIfNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.' || (e.KeyChar == '.' && (sender as TextBox)?.Text.Contains('.') == true)) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetLocationComboBoxItems();
        }

        private void chkCustomPosition_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCustomPosition.Checked) RequiredFields.Remove(cmbPosition);
            else RequiredFields.Add(cmbPosition);

            pnlGroup8.Enabled = !chkCustomPosition.Checked;
            txtCustomPosition.Enabled = lblCustomPositionAsterisk.Visible = chkCustomPosition.Checked;
        }
    }
}
