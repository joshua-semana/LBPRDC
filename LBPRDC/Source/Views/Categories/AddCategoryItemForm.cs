using LBPRDC.Source.Services;
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
        private readonly List<Control> ClientSpecificFields;
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

            ClientSpecificFields = new()
            {
                lblPayFrequency,
                cmbPayFrequency,
                lblCode,
                txtCode,
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
                    ControlUtils.ToggleControlVisibility(ClientSpecificFields, true);
                    InitializePayFrequencyComboBoxItems();
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

            AdjustFormSize(GetVisibleControlsCount(flowBody));
            CenterForm();
            GetRequiredFields();
        }

        private int GetVisibleControlsCount(Control control)
        {
            int count = 0;

            foreach (Control item in control.Controls)
            {
                if ((item is Label || item is TextBox) && item.Visible)
                {
                    count++;
                }
            }

            return count;
        }

        private void AdjustFormSize(int Count)
        {
            var multiplier = (Count / 2) * 57;
            this.Height = 227 + multiplier;
        }

        private void CenterForm()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(
                (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2
            );
        }

        private async void InitializePayFrequencyComboBoxItems()
        {
            cmbPayFrequency.DataSource = await PayFrequencyService.GetAllItemsForComboBox();
            cmbPayFrequency.DisplayMember = nameof(Models.PayFrequency.Name);
            cmbPayFrequency.ValueMember = nameof(Models.PayFrequency.ID);
            cmbPayFrequency.SelectedValue = PayFrequencyService.CurrentPayFrequencyID;
        }

        private async void InitializeClientComboBoxItems()
        {
            cmbClient.DataSource = await ClientService.GetAllItemsForComboBox(StringConstants.Status.ACTIVE);
            cmbClient.DisplayMember = nameof(Models.Client.Name);
            cmbClient.ValueMember = nameof(Models.Client.ID);
        }

        private void InitializeDepartmentComboBoxItems(List<Models.Department> items)
        {
            cmbDepartment.DataSource = items;
            cmbDepartment.DisplayMember = nameof(Models.Department.Name);
            cmbDepartment.ValueMember = nameof(Models.Department.ID);
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
                        var positionItemsList = await PositionService.GetItems(Convert.ToInt32(cmbClient.SelectedValue));
                        var similarPositionCodesCount = positionItemsList.Where(w => txtCode.Text.ToUpper().Equals(w.Code)).Count();
                        if (similarPositionCodesCount > 0)
                        {
                            MessageBox.Show("This code has already been used. Please enter another code to continue.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        };
                        break;

                    case StringConstants.Categories.DEPARTMENT:
                        var departmentItemsList = await DepartmentService.GetItems(Convert.ToInt32(cmbClient.SelectedValue));
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
                    isAdded = await ClientService.Add(new()
                    {
                        PayFrequencyID = Convert.ToInt32(cmbPayFrequency.SelectedValue),
                        Code = code,
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
                    isAdded = await DepartmentService.Add(new()
                    {
                        Code = code,
                        ClientID = clientID,
                        Name = name,
                        Description = description,
                        Status = status
                    });
                    break;

                case StringConstants.Categories.LOCATION:
                    isAdded = await LocationService.Add(new()
                    {
                        Name = name,
                        Description = description,
                        Type = StringConstants.Type.USER_ENTRY,
                        Status = status,
                        DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue)
                    });
                    break;

                case StringConstants.Categories.EMPLOYMENT_STATUS:
                    isAdded = await EmploymentStatusService.Add(new()
                    {
                        Name = name,
                        Description = description,
                        Status = status
                    });
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
