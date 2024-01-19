using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;

namespace LBPRDC.Source.Views.Categories
{
    public partial class CategoriesControl : UserControl
    {
        private string CurrentCategory;
        private const string NoneDepartmentName = "None";

        private Dictionary<Control, string> OriginalValues = new();
        private List<Control> RequiredFields;

        private readonly List<string> Categories;
        private readonly List<Control> CommonFields;
        private readonly List<Control> PositionSpecificFields;
        private readonly List<Control> LocationSpecificFields;
        private readonly List<Control> DepartmentSpecificFields;

        UserControl loadingControl = new ucLoading() { Dock = DockStyle.Fill };

        public CategoriesControl()
        {
            InitializeComponent();

            this.Controls.Add(loadingControl);
            loadingControl.BringToFront();

            Categories = new()
            {
                "Position",
                "Civil Status",
                "Department",
                "Location",
                "Employment Status"
            };

            CommonFields = new()
            {
                lblID,
                txtID,
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

            DepartmentSpecificFields = new()
            {
                lblCode,
                txtCode
            };

            CurrentCategory = Categories[0];
            OriginalValues = new();
            RequiredFields = new();

            InitializeCategoriesComboBoxItems();
        }

        public void PopulateTableAndFields()
        {
            ShowLoadingProgressBar(true);
            CurrentCategory = cmbCategories.SelectedItem.ToString();

            ControlUtils.ToggleControlsVisibilityInContainer(flowRightContent, false);
            ControlUtils.ToggleControlVisibility(CommonFields, true);
            btnHistory.Visible = false;

            dgvCategory.Columns.Clear();

            switch (CurrentCategory)
            {
                case "Position":
                    dgvCategory.DataSource = PositionService.GetAllItems();
                    ControlUtils.ToggleControlVisibility(PositionSpecificFields, true);
                    btnHistory.Visible = true;
                    break;

                case "Location":
                    dgvCategory.DataSource = LocationService.GetAllItemsForCategories()
                        .Where(w => w.ID != 1 && w.DepartmentName != NoneDepartmentName).ToList();
                    ControlUtils.ToggleControlVisibility(LocationSpecificFields, true);
                    break;

                case "Department":
                    dgvCategory.DataSource = DepartmentService.GetAllItems();
                    ControlUtils.ToggleControlVisibility(DepartmentSpecificFields, true);
                    break;

                case "Civil Status":
                    dgvCategory.DataSource = CivilStatusService.GetAllItems();
                    break;

                case "Employment Status":
                    dgvCategory.DataSource = EmploymentStatusService.GetAllItems();
                    break;
            }

            UpdateRequiredFields();
            ShowLoadingProgressBar(false);
        }

        private void CategoriesControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                PopulateTableAndFields();
            }
        }

        private void InitializeCategoriesComboBoxItems()
        {
            cmbCategories.DataSource = Categories;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            PopulateTableAndFields();
        }

        private void UpdateRequiredFields()
        {
            RequiredFields.Clear();
            foreach (Control control in flowRightContent.Controls)
            {
                if ((control is TextBox && control.AccessibleName != "Description") || control is ComboBox)
                {
                    RequiredFields.Add(control);
                }
            }
        }

        private void dgvCategory_SelectionChanged(object sender, EventArgs e)
        {
            if (this.Visible && dgvCategory.SelectedRows.Count > 0)
            {
                btnUpdate.Enabled = false;

                foreach (var kv in OriginalValues)
                {
                    kv.Key.TextChanged -= ControlValue_Changed;
                }

                var selectedRow = dgvCategory.SelectedRows[0];

                PopulateCommonTextFieldData(selectedRow);

                switch (CurrentCategory)
                {
                    case "Position":
                        PopulatePositionSpecificTextFieldData(selectedRow);
                        break;
                    case "Location":
                        PopulateLocationSpecificTextFieldData(selectedRow);
                        break;
                    case "Department":
                        PopulateDepartmentSpecificTextFieldDate(selectedRow);
                        break;
                }

                UpdateOriginalValues();
            }
        }

        private void PopulateCommonTextFieldData(DataGridViewRow data)
        {
            txtID.Text = data.Cells["ID"].Value.ToString();
            txtName.Text = data.Cells["Name"].Value.ToString();
            txtDescription.Text = data.Cells["Description"].Value.ToString();
            cmbStatus.SelectedItem = data.Cells["Status"].Value.ToString();
        }

        private void PopulatePositionSpecificTextFieldData(DataGridViewRow data)
        {
            txtCode.Text = data.Cells["Code"].Value.ToString();
            txtSalaryRate.Text = data.Cells["SalaryRate"].Value.ToString();
            txtBillingRate.Text = data.Cells["BillingRate"].Value.ToString();
        }

        private void PopulateLocationSpecificTextFieldData(DataGridViewRow data)
        {
            GetDeparmentComboBoxValue(Convert.ToInt32(data.Cells["DepartmentID"].Value));
        }

        private void GetDeparmentComboBoxValue(int value)
        {
            cmbDepartment.DataSource = DepartmentService.GetAllItemsForComboBox();
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "ID";
            cmbDepartment.SelectedValue = value;
        }

        private void PopulateDepartmentSpecificTextFieldDate(DataGridViewRow data)
        {
            txtCode.Text = data.Cells["Code"].Value.ToString();
        }

        private void UpdateOriginalValues()
        {
            OriginalValues.Clear();
            foreach (Control control in flowRightContent.Controls)
            {
                if (control is TextBox || control is ComboBox)
                {
                    OriginalValues.Add(control, control.Text);
                }
            }

            foreach (var kv in OriginalValues)
            {
                kv.Key.TextChanged += ControlValue_Changed;
            }
        }

        private void ControlValue_Changed(object sender, EventArgs e)
        {
            bool anyControlValueChanged = OriginalValues.Any(kv =>
            {
                if (kv.Key is TextBox textBox)
                {
                    return textBox.Text != kv.Value;
                }
                if (kv.Key is ComboBox comboBox)
                {
                    return comboBox.Text != kv.Value;
                }
                return false;
            });

            btnUpdate.Enabled = anyControlValueChanged;
        }

        private void ValidateInputIfNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.' || (e.KeyChar == '.' && (sender as TextBox)?.Text.Contains('.') == true)) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var output = MessageBox.Show("Are you sure you want to update this item under this category?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (output == DialogResult.No) return;

            if (ControlUtils.AreRequiredFieldsFilled(RequiredFields))
            {
                switch (CurrentCategory)
                {
                    case "Civil Status":

                        CivilStatusService.CivilStatus UpdateForCivilStatus = new()
                        {
                            ID = Convert.ToInt32(txtID.Text),
                            Name = txtName.Text.ToUpper().Trim(),
                            Description = txtDescription.Text.ToUpper().Trim(),
                            Status = cmbStatus.Text
                        };
                        CivilStatusService.Update(UpdateForCivilStatus);
                        break;

                    case "Department":
                        if (txtCode.Text.ToUpper() == "OT")
                        {
                            MessageBox.Show("The code 'OT' cannot be used; please try another code.", "Invalid Code Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        var similarDepartmentCodes = DepartmentService.GetAllItems().Where(w => txtCode.Text.ToUpper().Equals(w.Code)).ToList();
                        if (similarDepartmentCodes.Count > 0 && txtCode.Text != OriginalValues[txtCode])
                        {
                            MessageBox.Show("This code has already been used. Please enter another code to continue.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        };
                        DepartmentService.Department UpdateForDepartment = new()
                        {
                            ID = Convert.ToInt32(txtID.Text),
                            Code = txtCode.Text.ToUpper().Trim(),
                            Name = txtName.Text.Trim(),
                            Description = txtDescription.Text.ToUpper().Trim(),
                            Status = cmbStatus.Text
                        };
                        DepartmentService.Update(UpdateForDepartment);
                        break;

                    case "Employment Status":
                        EmploymentStatusService.EmploymentStatus UpdateForEmploymentStatus = new()
                        {
                            ID = Convert.ToInt32(txtID.Text),
                            Name = txtName.Text.ToUpper().Trim(),
                            Description = txtDescription.Text.ToUpper().Trim(),
                            Status = cmbStatus.Text
                        };
                        EmploymentStatusService.Update(UpdateForEmploymentStatus);
                        break;

                    case "Location":
                        LocationService.Location UpdateForLocation = new()
                        {
                            ID = Convert.ToInt32(txtID.Text),
                            Name = txtName.Text.Trim(),
                            Description = txtDescription.Text.ToUpper().Trim(),
                            Status = cmbStatus.Text,
                            DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue)
                        };
                        LocationService.Update(UpdateForLocation);
                        break;

                    case "Position":
                        var similarPositionCodes = PositionService.GetAllItems().Where(w => txtCode.Text.ToUpper().Equals(w.Code)).ToList();
                        if (similarPositionCodes.Count > 0 && txtCode.Text != OriginalValues[txtCode])
                        {
                            MessageBox.Show("This code has already been used. Please enter another code to continue.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        };

                        PositionService.Position UpdateForPosition = new()
                        {
                            ID = Convert.ToInt32(txtID.Text),
                            Name = txtName.Text.Trim(),
                            Description = txtDescription.Text.ToUpper().Trim(),
                            Status = cmbStatus.Text,
                            Code = txtCode.Text.ToUpper().Trim(),
                            SalaryRate = Convert.ToDecimal(txtSalaryRate.Text),
                            BillingRate = Convert.ToDecimal(txtBillingRate.Text)
                        };
                        PositionService.Update(UpdateForPosition);

                        if (txtSalaryRate.Text != OriginalValues[txtSalaryRate] || txtBillingRate.Text != OriginalValues[txtBillingRate])
                        {
                            PositionService.RatesHistory newRates = new()
                            {
                                PositionID = Convert.ToInt32(txtID.Text),
                                SalaryRate = Convert.ToDecimal(txtSalaryRate.Text),
                                BillingRate = Convert.ToDecimal(txtBillingRate.Text)
                            };
                            PositionService.AddRatesHistory(newRates);
                        };
                        break;

                    default:
                        MessageBox.Show("Please make sure that the text in the category combo box matches in the codebase swith case for update.", "Developer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                PopulateTableAndFields();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var CurrentVisibleControls = ControlUtils.GetVisibleControls(flowRightContent);
            AddCategoryItemForm addCategoryItemForm = new()
            {
                ParentControl = this,
                CategoryName = CurrentCategory
            };
            addCategoryItemForm.ShowDialog();
        }

        private void ShowLoadingProgressBar(bool state)
        {
            loadingControl.Visible = state;
            pnlRight.Enabled = !state;
        }

        private void ToUpperCase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar)) e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            PositionRatesHistory positionRatesHistory = new()
            {
                PositionID = Convert.ToInt32(txtID.Text)
            };
            positionRatesHistory.ShowDialog();
        }
    }
}
