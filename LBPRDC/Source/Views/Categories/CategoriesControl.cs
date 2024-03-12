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
                "Clients",
                "Position",
                "Department",
                "Location",
                "Civil Status",
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
                cmbClient
            };

            CurrentCategory = Categories[0];
            OriginalValues = new();
            RequiredFields = new();

            InitializeCategoriesComboBoxItems();
        }

        public void PopulateTableAndFields()
        {
            ShowLoadingProgressBar(true);

            ControlUtils.ToggleControlsVisibilityInContainer(flowRightContent, false);
            ControlUtils.ToggleControlVisibility(CommonFields, true);
            cmbDepartment.Enabled = txtDescription.Enabled = cmbStatus.Enabled = true; // Hardcoded because of Location Item Selection change when Type is Default
            btnHistory.Visible = false;

            dgvCategory.Columns.Clear();

            switch (CurrentCategory)
            {
                case "Clients":
                    dgvCategory.DataSource = ClientService.GetClients();
                    break;

                case "Position":
                    dgvCategory.DataSource = PositionService.GetAllItems();
                    ControlUtils.ToggleControlVisibility(PositionSpecificFields, true);
                    btnHistory.Visible = true;
                    break;

                case "Department":
                    dgvCategory.DataSource = DepartmentService.GetAllItems();
                    ControlUtils.ToggleControlVisibility(DepartmentSpecificFields, true);
                    break;

                case "Location":
                    //dgvCategory.DataSource = LocationService.GetAllItemsForCategories()
                    //    .Where(w => w.ID != 1 && w.DepartmentName != NoneDepartmentName).ToList();
                    dgvCategory.DataSource = LocationService.GetAllItemsForCategories();
                    ControlUtils.ToggleControlVisibility(LocationSpecificFields, true);
                    break;

                case "Civil Status":
                    dgvCategory.DataSource = CivilStatusService.GetAllItems();
                    break;

                case "Employment Status":
                    dgvCategory.DataSource = EmploymentStatusService.GetAllItems();
                    break;
            }

            if (dgvCategory.Rows.Count <= 0)
            {
                flowRightContent.Enabled = false;
                flowFooterActions.Enabled = false;
                ControlUtils.ClearInputs(flowRightContent);
            }
            else
            {
                flowRightContent.Enabled = true;
                flowFooterActions.Enabled = true;
                UpdateRequiredFields();
                UpdateOriginalValues();
            }

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
            CurrentCategory = cmbCategories.Text.ToString();
            PopulateTableAndFields();
        }

        private void UpdateRequiredFields()
        {
            RequiredFields.Clear();
            foreach (Control control in flowRightContent.Controls)
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

        private void dgvCategory_SelectionChanged(object sender, EventArgs e)
        {
            if (this.Visible && dgvCategory.SelectedRows.Count > 0)
            {
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
                //UpdateRequiredFields();
                UpdateOriginalValues();
                btnUpdate.Enabled = false;
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
            GetClientComboBoxValue(Convert.ToInt32(data.Cells["ClientID"].Value));
            txtCode.Text = data.Cells["Code"].Value.ToString();
            txtSalaryRate.Text = data.Cells["SalaryRate"].Value.ToString();
            txtBillingRate.Text = data.Cells["BillingRate"].Value.ToString();
        }

        private void PopulateLocationSpecificTextFieldData(DataGridViewRow data)
        {
            bool isDefault = data.Cells["Type"].Value.ToString() == "DEFAULT";
            cmbDepartment.Enabled = txtDescription.Enabled = cmbStatus.Enabled = !isDefault;
            GetDeparmentComboBoxValue(Convert.ToInt32(data.Cells["DepartmentID"].Value));
        }

        private void GetDeparmentComboBoxValue(int value)
        {
            cmbDepartment.DataSource = DepartmentService.GetAllItemsForComboBox();
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "ID";
            cmbDepartment.SelectedValue = value;
        }

        private void GetClientComboBoxValue(int value)
        {
            cmbClient.DataSource = ClientService.GetClientsForComboBoxByStatus("Active", true);
            cmbClient.DisplayMember = "Name";
            cmbClient.ValueMember = "ID";
            cmbClient.SelectedValue = value;
        }

        private void PopulateDepartmentSpecificTextFieldDate(DataGridViewRow data)
        {
            GetClientComboBoxValue(Convert.ToInt32(data.Cells["ClientID"].Value));
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
            if (ControlUtils.AreRequiredFieldsFilled(RequiredFields))
            {
                var output = MessageBox.Show("Are you sure you want to update this item under this category?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (output == DialogResult.No) return;

                int ID = Convert.ToInt32(txtID.Text);
                string name = txtName.Text.Trim();
                string description = txtDescription.Text.Trim();
                string status = cmbStatus.Text;

                switch (CurrentCategory)
                {
                    case "Clients":
                        if (IsCategoryItemInUse()) { return; }

                        ClientService.Update(new()
                        {
                            ID = ID,
                            Name = name,
                            Description = description,
                            Status = status
                        });

                        break;

                    case "Civil Status":
                        if (IsCategoryItemInUse()) { return; }

                        CivilStatusService.Update(new()
                        {
                            ID = ID,
                            Name = name,
                            Description = description,
                            Status = status
                        });

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

                        if (IsCategoryItemInUse()) { return; }

                        DepartmentService.Update(new()
                        {
                            ID = ID,
                            ClientID = Convert.ToInt32(cmbClient.SelectedValue),
                            Code = txtCode.Text.ToUpper().Trim(),
                            Name = name,
                            Description = description,
                            Status = status
                        });

                        break;

                    case "Employment Status":
                        if (IsCategoryItemInUse()) { return; }

                        EmploymentStatusService.Update(new()
                        {
                            ID = ID,
                            Name = name,
                            Description = description,
                            Status = status
                        });

                        break;

                    case "Location":
                        if (IsCategoryItemInUse()) { return; }

                        LocationService.Update(new()
                        {
                            ID = ID,
                            Name = name,
                            Description = description,
                            Status = status,
                            DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue)
                        });

                        break;

                    case "Position":
                        var similarPositionCodes = PositionService.GetAllItems().Where(w => txtCode.Text.ToUpper().Equals(w.Code)).ToList();
                        if (similarPositionCodes.Count > 0 && txtCode.Text != OriginalValues[txtCode])
                        {
                            MessageBox.Show("This code has already been used. Please enter another code to continue.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        };

                        if (IsCategoryItemInUse()) { return; }

                        PositionService.Position UpdateForPosition = new()
                        {
                            ID = ID,
                            ClientID = Convert.ToInt32(cmbClient.SelectedValue),
                            Name = name,
                            Description = description,
                            Status = status,
                            Code = txtCode.Text.ToUpper().Trim(),
                            SalaryRate = Convert.ToDecimal(txtSalaryRate.Text),
                            BillingRate = Convert.ToDecimal(txtBillingRate.Text)
                        };
                        PositionService.Update(UpdateForPosition);

                        if (txtSalaryRate.Text != OriginalValues[txtSalaryRate] || txtBillingRate.Text != OriginalValues[txtBillingRate])
                        {
                            PositionService.RatesHistory newRates = new()
                            {
                                PositionID = ID,
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

        private bool IsCategoryItemInUse()
        {
            int ID = Convert.ToInt32(txtID.Text);
            string status = cmbStatus.Text;
            var originalStatus = OriginalValues[cmbStatus].ToString();

            if (status != originalStatus && status == "Inactive")
            {
                frmLoading form = new()
                {
                    StringListProcess = CurrentCategory switch
                    {
                        "Clients" => Task.Run(() => ClientService.GetExistenceByID(ID)),
                        "Department" => Task.Run(() => DepartmentService.GetExistenceByID(ID)),
                        "Location" => Task.Run(() => LocationService.GetExistenceByID(ID)),
                        "Position" => Task.Run(() => PositionService.GetExistenceByID(ID)),
                        "Civil Status" => Task.Run(() => CivilStatusService.GetExistenceByID(ID)),
                        "Employment Status" => Task.Run(() => EmploymentStatusService.GetExistenceByID(ID)),
                        _ => throw new NotImplementedException(),
                    }
                };

                DialogResult result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    bool clientInUse = form.StringListResult?.Count > 0;
                    if (clientInUse)
                    {
                        string tableNames = string.Join("\n", form.StringListResult);
                        MessageBox.Show($"This client is being used and cannot be updated to inactive. These are the categories it is being used:\n{tableNames}", "Update Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return true;
                    }
                }
                else if (result == DialogResult.Abort)
                {
                    MessageBox.Show("There is a problem retrieving information if this client is being used on other categories. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true; // Precautionary measure to make sure it will not continue to add the item
                }
            }
            return false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
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
            if (dgvCategory.SelectedRows.Count == 1)
            {
                PositionRatesHistory positionRatesHistory = new()
                {
                    PositionID = Convert.ToInt32(txtID.Text)
                };
                positionRatesHistory.ShowDialog();
            }
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentCategory = cmbCategories.Text.ToString();
            PopulateTableAndFields();
        }
    }
}
