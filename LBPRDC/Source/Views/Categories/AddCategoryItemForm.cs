﻿using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using LBPRDC.Source.Config;

namespace LBPRDC.Source.Views.Categories
{
    public partial class AddCategoryItemForm : Form
    {
        public CategoriesControl? ParentControl { get; set; }
        public string? CategoryName { get; set; }

        private readonly List<Control> RequiredFields;
        private readonly List<Control> CommonFields;
        private readonly List<Control> ClassificationSpecificFields;
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

            ClassificationSpecificFields = new()
            {
                lblClient,
                cmbClient,
            };

            PositionSpecificFields = new()
            {
                lblCode,
                txtCode,
                lblClient,
                cmbClient,
                lblDailySalaryRate,
                txtDailySalaryRate,
                lblDailyBillingRate,
                txtDailyBillingRate,
                lblMonthlySalaryRate,
                txtMonthlySalaryRate,
                lblMonthlyBillingRate,
                txtMonthlyBillingRate,
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

        private async void AddCategoryItemForm_Load(object sender, EventArgs e)
        {
            lblTitle.Text = $"NEW {CategoryName?.ToUpper()} ITEM";
            ControlUtils.ToggleControlVisibility(CommonFields, true);
            cmbStatus.SelectedIndex = 0;

            switch (CategoryName)
            {
                case StringConstants.Categories.CLIENT:
                    break;

                case StringConstants.Categories.CLASSIFICATION:
                    ControlUtils.ToggleControlVisibility(ClassificationSpecificFields, true);
                    InitializeClientComboBoxItems();
                    break;

                case StringConstants.Categories.WAGE:
                    break;

                case StringConstants.Categories.POSITION:
                    ControlUtils.ToggleControlVisibility(PositionSpecificFields, true);
                    InitializeClientComboBoxItems();
                    break;

                case StringConstants.Categories.LOCATION:
                    ControlUtils.ToggleControlVisibility(LocationSpecificFields, true);
                    var departments = await DepartmentService.GetAllItemsForComboBox();
                    InitializeDepartmentComboBoxItems(departments);
                    break;

                case StringConstants.Categories.DEPARTMENT:
                    ControlUtils.ToggleControlVisibility(DepartmentSpecificFields, true);
                    InitializeClientComboBoxItems();
                    break;

                case StringConstants.Categories.EMPLOYMENT_STATUS:
                    break;


                default:
                    MessageBox.Show("Category is not allowed to use this feature. Please contact support for this error.", MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    break;
            }

            GetRequiredFields();
        }

        private void InitializeDepartmentComboBoxItems(List<Models.Department> items)
        {
            cmbDepartment.DataSource = items;
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "ID";
        }

        private void InitializeClientComboBoxItems()
        {
            cmbClient.DataSource = ClientService.GetClientsForComboBoxByStatus(StringConstants.Status.ACTIVE, true);
            cmbClient.DisplayMember = "Description";
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

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(RequiredFields))
            {
                switch (CategoryName)
                {
                    case StringConstants.Categories.POSITION:
                        var positionItemsList = await PositionService.GetItemsByClientID(Convert.ToInt32(cmbClient.SelectedValue));
                        var similarPositionCodesCount = positionItemsList.Where(w => txtCode.Text.ToUpper().Equals(w.Code)).Count();
                        if (similarPositionCodesCount > 0)
                        {
                            MessageBox.Show("This code has already been used. Please enter another code to continue.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        };
                        break;

                    case StringConstants.Categories.DEPARTMENT:
                        var departmentItemsList = await DepartmentService.GetItemsByClientID(Convert.ToInt32(cmbClient.SelectedValue));
                        var similarDepartmentCodesCount = departmentItemsList.Where(w => txtCode.Text.ToUpper().Equals(w.Code)).Count();
                        if (similarDepartmentCodesCount > 0)
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
            int clientID = Convert.ToInt32(cmbClient.SelectedValue);
            string code = txtCode.Text.ToUpper().Trim();
            string name = txtName.Text.Trim();
            string description = txtDescription.Text.Trim();
            string status = cmbStatus.Text;

            switch (CategoryName)
            {
                case StringConstants.Categories.CLIENT:
                    isAdded = await ClientService.AddClient(new()
                    {
                        Name = name,
                        Description = description,
                        Status = status
                    });
                    break;

                case StringConstants.Categories.CLASSIFICATION:
                    isAdded = await ClassificationService.AddClassification(new()
                    {
                        ClientID = clientID,
                        Name = name,
                        Description = description,
                        Status = status
                    });
                    break;

                case StringConstants.Categories.POSITION:
                    isAdded = await PositionService.Add(new()
                    {
                        ClientID = clientID,
                        Name = name,
                        Description = description,
                        Status = status,
                        Code = code,
                        DailySalaryRate = Convert.ToDecimal(txtDailySalaryRate.Text),
                        DailyBillingRate = Convert.ToDecimal(txtDailyBillingRate.Text),
                        MonthlySalaryRate = Convert.ToDecimal(txtMonthlySalaryRate.Text),
                        MonthlyBillingRate = Convert.ToDecimal(txtMonthlyBillingRate.Text)
                    });
                    break;

                case StringConstants.Categories.DEPARTMENT:
                    DepartmentService.Department AddForDepartment = new()
                    {
                        Code = code,
                        ClientID = clientID,
                        Name = name,
                        Description = description,
                        Status = status
                    };
                    isAdded = await DepartmentService.Add(AddForDepartment);
                    break;

                case StringConstants.Categories.LOCATION:
                    LocationService.Location AddForLocation = new()
                    {
                        Name = name,
                        Description = description,
                        Type = StringConstants.Type.USER_ENTRY,
                        Status = status,
                        DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue)
                    };
                    isAdded = await LocationService.Add(AddForLocation);
                    break;

                case StringConstants.Categories.EMPLOYMENT_STATUS:
                    EmploymentStatusService.EmploymentStatus AddForEmploymentStatus = new()
                    {
                        Name = name,
                        Description = description,
                        Status = status
                    };
                    isAdded = await EmploymentStatusService.Add(AddForEmploymentStatus);
                    break;

                case StringConstants.Categories.WAGE:
                    isAdded = await WageService.Add(new()
                    {
                        Name = name,
                        Description = description,
                        Status = status
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
                MessageBox.Show("Addition of item has failed, please try again.", MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToUpperCase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar)) e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }
}
