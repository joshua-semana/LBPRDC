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
        private readonly List<Control> DepartmentSpecificFields;

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
                lblClient,
                cmbClient,
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

            DepartmentSpecificFields = new()
            {
                lblCode,
                txtCode,
                lblClient,
                cmbClient,
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
                case "Clients":
                    break;

                case "Position":
                    ControlUtils.ToggleControlVisibility(PositionSpecificFields, true);
                    InitializeClientComboBoxItems();
                    break;

                case "Location":
                    ControlUtils.ToggleControlVisibility(LocationSpecificFields, true);
                    InitializeDepartmentComboBoxItems();
                    break;

                case "Department":
                    ControlUtils.ToggleControlVisibility(DepartmentSpecificFields, true);
                    InitializeClientComboBoxItems();
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

        private void InitializeClientComboBoxItems()
        {
            cmbClient.DataSource = ClientService.GetClientsForComboBoxByStatus("Active", true);
            cmbClient.DisplayMember = "Name";
            cmbClient.ValueMember = "ID";
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
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(RequiredFields))
            {
                switch (CategoryName)
                {
                    case "Department":
                        var similarDepartmentCodes = DepartmentService.GetAllItems().Where(w => txtCode.Text.ToUpper().Equals(w.Code)).ToList();
                        if (similarDepartmentCodes.Count > 0)
                        {
                            MessageBox.Show("This code has already been used. Please enter another code to continue.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        };
                        break;

                    case "Position":
                        var similarPositionCodes = PositionService.GetAllItems().Where(w => txtCode.Text.ToUpper().Equals(w.Code)).ToList();
                        if (similarPositionCodes.Count > 0)
                        {
                            MessageBox.Show("This code has already been used. Please enter another code to continue.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        };
                        break;
                };

                AddNewItem();
            }
        }

        private async void AddNewItem()
        {
            bool isAdded = false;
            string code = txtCode.Text.ToUpper().Trim();
            string name = txtName.Text.Trim();
            string description = txtDescription.Text.Trim();
            string status = cmbStatus.Text;

            switch (CategoryName)
            {
                case "Clients":
                    isAdded = await ClientService.AddClient(new()
                    {
                        Name = name,
                        Description = description,
                        Status = status
                    });
                    break;

                case "Civil Status":
                    CivilStatusService.CivilStatus AddForCivilStatus = new()
                    {
                        Name = name,
                        Description = description,
                        Status = status
                    };
                    isAdded = await CivilStatusService.Add(AddForCivilStatus);
                    break;

                case "Department":
                    DepartmentService.Department AddForDepartment = new()
                    {
                        Code = code,
                        ClientID = Convert.ToInt32(cmbClient.SelectedValue),
                        Name = name,
                        Description = description,
                        Status = status
                    };
                    isAdded = await DepartmentService.Add(AddForDepartment);
                    break;

                case "Employment Status":
                    EmploymentStatusService.EmploymentStatus AddForEmploymentStatus = new()
                    {
                        Name = name,
                        Description = description,
                        Status = status
                    };
                    isAdded = await EmploymentStatusService.Add(AddForEmploymentStatus);
                    break;

                case "Location":
                    LocationService.Location AddForLocation = new()
                    {
                        Name = name,
                        Description = description,
                        Type = "USER_ENTRY",
                        Status = status,
                        DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue)
                    };
                    isAdded = await LocationService.Add(AddForLocation);
                    break;

                case "Position":
                    isAdded = await PositionService.Add(new()
                    {
                        Name = name,
                        ClientID = Convert.ToInt32(cmbClient.SelectedValue),
                        Description = description,
                        Status = status,
                        Code = code,
                        SalaryRate = Convert.ToDecimal(txtSalaryRate.Text),
                        BillingRate = Convert.ToDecimal(txtBillingRate.Text)
                    });
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
            else
            {
                MessageBox.Show("Addition of item has failed, please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToUpperCase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar)) e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }
}
