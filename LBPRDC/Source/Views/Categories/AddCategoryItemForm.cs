using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;

namespace LBPRDC.Source.Views.Categories
{
    public partial class AddCategoryItemForm : Form
    {
        public CategoriesControl? ParentControl { get; set; }
        public string? CategoryName { get; set; }

        private List<Control> RequiredFields;
        private readonly List<Control> CommonFields;
        private readonly List<Control> PositionSpecificFields;
        private readonly List<Control> LocationSpecificFields;

        public AddCategoryItemForm()
        {
            InitializeComponent();
            CommonFields = new()
            {
                lblName,
                txtName,
                lblDescription,
                txtDescription,
                lblStatus,
                cmbStatus
            };

            PositionSpecificFields = new()
            {
                lblCode,
                txtCode,
                lblSalaryRate,
                txtSalaryRate,
                lblBillingRate,
                txtBillingRate,
            };

            LocationSpecificFields = new()
            {
                lblDepartment,
                cmbDepartment
            };

            RequiredFields = new();
        }

        private void AddCategoryItemForm_Load(object sender, EventArgs e)
        {
            lblTitle.Text = $"NEW {CategoryName?.ToUpper()} ITEM";
            ControlUtils.ToggleControlVisibility(CommonFields, true);
            cmbStatus.SelectedIndex = 0;

            switch (CategoryName)
            {
                case "Position":
                    ControlUtils.ToggleControlVisibility(PositionSpecificFields, true);
                    break;

                case "Location":
                    ControlUtils.ToggleControlVisibility(LocationSpecificFields, true);
                    InitializeDepartmentComboBoxItems();
                    break;

                case "Department":
                    break;

                case "Civil Status":
                    break;

                case "Employment Status":
                    break;

                default:
                    MessageBox.Show("Category is not allowed to use this feature. Please contact support for this error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    break;
            }

            GetRequiredFields();
        }

        private void InitializeDepartmentComboBoxItems()
        {
            cmbDepartment.DataSource = DepartmentService.GetAllItemsForComboBox();
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "ID";
        }

        private void GetRequiredFields()
        {
            foreach (Control control in flowBody.Controls)
            {
                if (control.Visible == true)
                {
                    if ((control is TextBox && control.AccessibleName != "Description") || control is ComboBox)
                    {
                        RequiredFields.Add(control);
                    }
                }
            }
        }

        private void ValidateInputIfNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.' || (e.KeyChar == '.' && (sender as TextBox)?.Text.Contains('.') == true)) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel this operation?", "Cancel Operation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(RequiredFields))
            {
                AddNewItem();
            }
        }

        private async void AddNewItem()
        {
            bool isAdded = false;
            switch (CategoryName)
            {
                case "Civil Status":
                    CivilStatusService.CivilStatus AddForCivilStatus = new()
                    {
                        Name = txtName.Text.ToUpper().Trim(),
                        Description = txtDescription.Text.ToUpper().Trim(),
                        Status = cmbStatus.Text
                    };
                    isAdded = await CivilStatusService.Add(AddForCivilStatus);
                    break;

                case "Department":
                    DepartmentService.Department AddForDepartment = new()
                    {
                        Name = txtName.Text.Trim(),
                        Description = txtDescription.Text.ToUpper().Trim(),
                        Status = cmbStatus.Text
                    };
                    isAdded = await DepartmentService.Add(AddForDepartment);
                    break;

                case "Employment Status":
                    EmploymentStatusService.EmploymentStatus AddForEmploymentStatus = new()
                    {
                        Name = txtName.Text.ToUpper().Trim(),
                        Description = txtDescription.Text.ToUpper().Trim(),
                        Status = cmbStatus.Text
                    };
                    isAdded = await EmploymentStatusService.Add(AddForEmploymentStatus);
                    break;

                case "Location":
                    LocationService.Location AddForLocation = new()
                    {
                        Name = txtName.Text.Trim(),
                        Description = txtDescription.Text.ToUpper().Trim(),
                        Status = cmbStatus.Text,
                        DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue)
                    };
                    isAdded = await LocationService.Add(AddForLocation);
                    break;

                case "Position":
                    PositionService.Position AddForPosition = new()
                    {
                        Name = txtName.Text.ToUpper().Trim(),
                        Description = txtDescription.Text.ToUpper().Trim(),
                        Status = cmbStatus.Text,
                        Code = txtCode.Text.ToUpper().Trim(),
                        SalaryRate = Convert.ToDecimal(txtSalaryRate.Text),
                        BillingRate = Convert.ToDecimal(txtBillingRate.Text)
                    };
                    isAdded = await PositionService.Add(AddForPosition);
                    break;

                default:
                    MessageBox.Show("Please make sure that the text in the category combo box matches in the codebase swith case for update.", "Developer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            if (isAdded)
            {
                MessageBox.Show("You have successfully added a new item in this category.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ParentControl?.PopulateTableAndFields();
                this.Close();
            }
        }
    }
}
