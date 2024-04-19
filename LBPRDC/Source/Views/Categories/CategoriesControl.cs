using LBPRDC.Source.Config;
using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using System.Reflection;

namespace LBPRDC.Source.Views.Categories
{
    public partial class CategoriesControl : UserControl
    {
        private string CurrentCategoryKey;

        //private Dictionary<Control, string> OriginalValues = new();
        private List<Control> RequiredFields;

        private readonly Dictionary<string, string> Categories = new(); // Key = "Property Value", Value = "Property Key" || Clients, CLIENT
        private readonly List<Control> CommonFields;
        private readonly List<Control> PositionSpecificFields;
        private readonly List<Control> LocationSpecificFields;
        private readonly List<Control> DepartmentSpecificFields;

        UserControl loadingControl = new ucLoading() { Dock = DockStyle.Fill };

        private List<Models.Department> DepartmentsList = new();
        private List<Models.Position> PositionsList = new();

        public CategoriesControl()
        {
            InitializeComponent();

            this.Controls.Add(loadingControl);
            loadingControl.BringToFront();

            // Reflection
            var categoryProps = typeof(StringConstants.Categories).GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (var property in categoryProps)
            {
                Categories.Add(property.GetValue(null)?.ToString(), property.Name);
            }

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

            CurrentCategoryKey = Categories.First().Key;
            //OriginalValues = new();
            RequiredFields = new();

            InitializeCategoriesComboBoxItems();
        }

        public async void PopulateTableAndFields()
        {
            ShowLoadingProgressBar(true);

            ControlUtils.ToggleControlsVisibilityInContainer(flowRightContent, false);
            ControlUtils.ToggleControlVisibility(CommonFields, true);
            btnDelete.Enabled = txtName.Enabled = cmbDepartment.Enabled = txtDescription.Enabled = cmbStatus.Enabled = cmbClient.Enabled = true; // Hardcoded because of Location Item Selection change when Type is Default
            btnHistory.Visible = false;

            dgvCategory.Columns.Clear();

            switch (CurrentCategoryKey)
            {
                case StringConstants.Categories.CLIENT:
                    dgvCategory.DataSource = ClientService.GetClients();
                    break;

                case StringConstants.Categories.POSITION:
                    PositionsList.Clear();
                    PositionsList = await PositionService.GetAllItems();
                    dgvCategory.DataSource = PositionsList;
                    ControlUtils.ToggleControlVisibility(PositionSpecificFields, true);
                    btnHistory.Visible = true;
                    cmbClient.Enabled = false;
                    break;

                case StringConstants.Categories.DEPARTMENT:
                    DepartmentsList.Clear();
                    DepartmentsList = await DepartmentService.GetAllItems();
                    dgvCategory.DataSource = DepartmentsList;
                    ControlUtils.ToggleControlVisibility(DepartmentSpecificFields, true);
                    cmbClient.Enabled = false;
                    break;

                case StringConstants.Categories.LOCATION:
                    dgvCategory.DataSource = LocationService.GetAllItems();
                    ControlUtils.ToggleControlVisibility(LocationSpecificFields, true);
                    break;

                case StringConstants.Categories.CIVIL_STATUS:
                    dgvCategory.DataSource = CivilStatusService.GetAllItems();
                    break;

                case StringConstants.Categories.EMPLOYMENT_STATUS:
                    dgvCategory.DataSource = EmploymentStatusService.GetAllItems();
                    break;

                case StringConstants.Categories.WAGE:
                    dgvCategory.DataSource = await WageService.GetWagesAsync();
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
                //UpdateOriginalValues();
                //UpdateRequiredFields();
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
            cmbCategories.DataSource = Categories.Keys.ToList();
            cmbCategories.MouseWheel += ComboBoxUtils.HandleMouseWheel;
            cmbCategories.KeyDown += ComboBoxUtils.HandleKeyDown;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            CurrentCategoryKey = cmbCategories.Text.ToString();
            PopulateTableAndFields();
        }

        private void UpdateRequiredFields()
        {
            RequiredFields.Clear();
            foreach (Control control in flowRightContent.Controls)
            {
                if (control.Visible == true)
                {
                    if ((control is TextBox && control.AccessibleName != "Description") || control is System.Windows.Forms.ComboBox)
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
                //foreach (var kv in OriginalValues)
                //{
                //    kv.Key.TextChanged -= ControlValue_Changed;
                //}

                var selectedRow = dgvCategory.SelectedRows[0];

                PopulateCommonTextFieldData(selectedRow);

                switch (CurrentCategoryKey)
                {
                    case StringConstants.Categories.POSITION:
                        PopulatePositionSpecificTextFieldData(selectedRow);
                        break;
                    case StringConstants.Categories.LOCATION:
                        PopulateLocationSpecificTextFieldData(selectedRow);
                        break;
                    case StringConstants.Categories.DEPARTMENT:
                        PopulateDepartmentSpecificTextFieldDate(selectedRow);
                        break;
                }
                UpdateRequiredFields();
                //UpdateOriginalValues();
                //btnUpdate.Enabled = false;
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
            var code = data.Cells["Code"].Value.ToString();
            var salaryRate = data.Cells["SalaryRate"].Value.ToString();
            var billingRate = data.Cells["BillingRate"].Value.ToString();

            txtCode.Text = code;
            txtCode.Tag = code;
            txtSalaryRate.Text = salaryRate;
            txtSalaryRate.Tag = salaryRate;
            txtBillingRate.Text = billingRate;
            txtBillingRate.Tag = billingRate;
        }

        private void PopulateLocationSpecificTextFieldData(DataGridViewRow data)
        {
            bool isDefault = data.Cells["Type"].Value.ToString() == StringConstants.Type.DEFAULT;
            btnDelete.Enabled = txtName.Enabled = cmbDepartment.Enabled = txtDescription.Enabled = cmbStatus.Enabled = !isDefault;
            GetDeparmentComboBoxValue(Convert.ToInt32(data.Cells["DepartmentID"].Value));
        }

        private void PopulateDepartmentSpecificTextFieldDate(DataGridViewRow data)
        {
            GetClientComboBoxValue(Convert.ToInt32(data.Cells["ClientID"].Value));
            txtCode.Text = data.Cells["Code"].Value.ToString();
            txtCode.Tag = data.Cells["Code"].Value.ToString();
        }

        private async void GetDeparmentComboBoxValue(int value)
        {
            cmbDepartment.DataSource = await DepartmentService.GetAllItemsForComboBox();
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "ID";
            cmbDepartment.SelectedValue = value;
        }

        private void GetClientComboBoxValue(int value)
        {
            cmbClient.DataSource = ClientService.GetClientsForComboBoxByStatus(StringConstants.Status.ACTIVE, true);
            cmbClient.DisplayMember = "Description";
            cmbClient.ValueMember = "ID";
            cmbClient.SelectedValue = value;
        }

        //private void UpdateOriginalValues()
        //{
        //    OriginalValues.Clear();
        //    foreach (Control control in flowRightContent.Controls)
        //    {
        //        if (control is TextBox || control is System.Windows.Forms.ComboBox)
        //        {
        //            if (control.Visible == true)
        //            {
        //                OriginalValues.Add(control, control.Text);
        //            }
        //        }
        //    }

        //    foreach (var kv in OriginalValues)
        //    {
        //        kv.Key.TextChanged += ControlValue_Changed;
        //    }
        //}

        //private void ControlValue_Changed(object sender, EventArgs e)
        //{
        //    bool anyControlValueChanged = OriginalValues.Any(kv =>
        //    {
        //        if (kv.Key is TextBox textBox)
        //        {
        //            return textBox.Text != kv.Value;
        //        }
        //        if (kv.Key is System.Windows.Forms.ComboBox comboBox)
        //        {
        //            return comboBox.Text != kv.Value;
        //        }
        //        return false;
        //    });

        //    btnUpdate.Enabled = anyControlValueChanged;
        //}

        private void ValidateInputIfNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.' || (e.KeyChar == '.' && (sender as TextBox)?.Text.Contains('.') == true)) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCategory.Rows.Count < 1 && dgvCategory.SelectedRows.Count < 1)
            {
                return;
            }

            if (CurrentCategoryKey == StringConstants.Categories.LOCATION)
            {
                if (dgvCategory.SelectedRows[0].Cells["Type"].Value.ToString() == StringConstants.Type.DEFAULT)
                {
                    MessageBox.Show("You are not allowed to edit this default item.", MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (ControlUtils.AreRequiredFieldsFilled(RequiredFields))
            {
                var output = MessageBox.Show("Are you sure you want to update this item under this category?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (output == DialogResult.No) return;

                int ID = Convert.ToInt32(txtID.Text);
                string name = txtName.Text.Trim();
                string description = txtDescription.Text.Trim();
                string status = cmbStatus.Text;

                var (InUse, CategoryList) = IsCategoryItemInUse(StringConstants.Operations.UPDATE);

                if (InUse && CurrentCategoryKey == StringConstants.Categories.DEPARTMENT)
                {
                    if (CategoryList != null && CategoryList.Contains("Employee"))
                    {
                        MessageBox.Show($"{MessagesConstants.INVALID_CATEGORY_DELETE}\n\n{string.Join("\n", "Employee")}", MessagesConstants.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (InUse)
                {
                    MessageBox.Show($"{MessagesConstants.INVALID_CATEGORY_UPDATE}\n\n{string.Join("\n", CategoryList)}", MessagesConstants.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool isUpdated = false;

                switch (CurrentCategoryKey)
                {
                    case StringConstants.Categories.CLIENT:
                        isUpdated = await ClientService.Update(new()
                        {
                            ID = ID,
                            Name = name,
                            Description = description,
                            Status = status
                        });

                        break;

                    case StringConstants.Categories.POSITION:
                        var similarPositionCodes = PositionsList.Where(w => txtCode.Text.ToUpper().Equals(w.Code)).ToList();
                        //if (similarPositionCodes.Count > 0 && txtCode.Text != OriginalValues[txtCode])
                        if (similarPositionCodes.Count > 0 && txtCode.Text != txtCode.Tag.ToString())
                        {
                            MessageBox.Show("This code has already been used. Please enter another code to continue.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        };

                        isUpdated = await PositionService.Update(new()
                        {
                            ID = ID,
                            ClientID = Convert.ToInt32(cmbClient.SelectedValue),
                            Name = name,
                            Description = description,
                            Status = status,
                            Code = txtCode.Text.ToUpper().Trim(),
                            SalaryRate = Convert.ToDecimal(txtSalaryRate.Text),
                            BillingRate = Convert.ToDecimal(txtBillingRate.Text)
                        });

                        if (txtSalaryRate.Text != txtSalaryRate.Tag.ToString() || txtBillingRate.Text != txtBillingRate.Tag.ToString())
                        {
                            PositionService.AddRatesHistory(new()
                            {
                                PositionID = ID,
                                SalaryRate = Convert.ToDecimal(txtSalaryRate.Text),
                                BillingRate = Convert.ToDecimal(txtBillingRate.Text)
                            });
                        };

                        break;

                    case StringConstants.Categories.DEPARTMENT:
                        if (txtCode.Text.ToUpper() == "OT")
                        {
                            MessageBox.Show("The code 'OT' cannot be used; please try another code.", "Invalid Code Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        var similarDepartmentCodes = DepartmentsList.Where(w => txtCode.Text.ToUpper().Equals(w.Code)).ToList();
                        //if (similarDepartmentCodes.Count > 0 && txtCode.Text != OriginalValues[txtCode])
                        if (similarDepartmentCodes.Count > 0 && txtCode.Text != txtCode.Tag.ToString())
                        {
                            MessageBox.Show("This code has already been used. Please enter another code to continue.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        };

                        isUpdated = await DepartmentService.Update(new()
                        {
                            ID = ID,
                            ClientID = Convert.ToInt32(cmbClient.SelectedValue),
                            Code = txtCode.Text.ToUpper().Trim(),
                            Name = name,
                            Description = description,
                            Status = status
                        });

                        break;

                    case StringConstants.Categories.LOCATION:
                        isUpdated = await LocationService.Update(new()
                        {
                            ID = ID,
                            Name = name,
                            Description = description,
                            Status = status,
                            DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue)
                        });

                        break;

                    case StringConstants.Categories.CIVIL_STATUS:
                        isUpdated = await CivilStatusService.Update(new()
                        {
                            ID = ID,
                            Name = name,
                            Description = description,
                            Status = status
                        });

                        break;

                    case StringConstants.Categories.EMPLOYMENT_STATUS:
                        isUpdated = await EmploymentStatusService.Update(new()
                        {
                            ID = ID,
                            Name = name,
                            Description = description,
                            Status = status
                        });

                        break;

                    case StringConstants.Categories.WAGE:
                        isUpdated = await WageService.Update(new()
                        {
                            ID = ID,
                            Name = name,
                            Description = description,
                            Status = status
                        });

                        break;

                    default:
                        MessageBox.Show("Please make sure that the text in the category combo box matches in the codebase swith case for update.", "Developer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                if (isUpdated)
                {
                    PopulateTableAndFields();
                }
                else
                {
                    MessageBox.Show(MessagesConstants.Update.FAILED, MessagesConstants.Update.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult output = MessageBox.Show(MessagesConstants.CONFIRMATION_DELETE, MessagesConstants.CONFIRMATION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (output == DialogResult.No)
            {
                return;
            }

            int itemID = Convert.ToInt32(txtID.Text);

            var (InUse, CategoryList) = IsCategoryItemInUse(StringConstants.Operations.DELETE);

            if (InUse && CategoryList != null)
            {
                if (CurrentCategoryKey == StringConstants.Categories.DEPARTMENT && CategoryList.Count == 1 && CategoryList.Contains(StringConstants.Categories.LOCATION))
                {
                    await LocationService.RemoveDefaultByDepartmentID(itemID);
                }
                else
                {
                    MessageBox.Show($"{MessagesConstants.INVALID_CATEGORY_DELETE}\n\n{string.Join("\n", CategoryList.Distinct())}", MessagesConstants.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            var tableNames = typeof(StringConstants.DBTableNames).GetFields(BindingFlags.Public | BindingFlags.Static);

            string? tableName = tableNames.First(f => f.Name == Categories[CurrentCategoryKey]).GetValue(null)?.ToString();

            frmLoading form = new()
            {
                BooleanProcess = Task.Run(() => UtilityService.Delete(tableName, itemID))
            };

            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                MessageBox.Show(MessagesConstants.SUCCESS_DELETE, MessagesConstants.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopulateTableAndFields();
            }
            else if (result == DialogResult.Abort)
            {
                MessageBox.Show(MessagesConstants.ERROR_ACTION, MessagesConstants.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private (bool InUse, List<string>? CategoryList) IsCategoryItemInUse(string operation)
        {
            int ID = Convert.ToInt32(txtID.Text);
            var status = cmbStatus.Text;
            //var originalStatus = OriginalValues[cmbStatus].ToString();

            //if ((operation == StringConstants.Operations.UPDATE && status != originalStatus && status == StringConstants.Status.INACTIVE) || operation == StringConstants.Operations.DELETE)
            if ((operation == StringConstants.Operations.UPDATE && status == StringConstants.Status.INACTIVE) || operation == StringConstants.Operations.DELETE)
            {
                frmLoading form = new()
                {
                    StringListProcess = CurrentCategoryKey switch
                    {
                        StringConstants.Categories.CLIENT => Task.Run(() => ClientService.GetExistenceByID(ID)),
                        StringConstants.Categories.POSITION => Task.Run(() => PositionService.GetExistenceByID(ID)),
                        StringConstants.Categories.DEPARTMENT => Task.Run(() => DepartmentService.GetExistenceByID(ID)),
                        StringConstants.Categories.LOCATION => Task.Run(() => LocationService.GetExistenceByID(ID)),
                        StringConstants.Categories.CIVIL_STATUS => Task.Run(() => CivilStatusService.GetExistenceByID(ID)),
                        StringConstants.Categories.EMPLOYMENT_STATUS => Task.Run(() => EmploymentStatusService.GetExistenceByID(ID)),
                        StringConstants.Categories.WAGE => Task.Run(() => WageService.GetExistenceByID(ID)),
                        _ => throw new NotImplementedException(),
                    }
                };

                DialogResult result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    bool categoryItemInUse = form.StringListResult?.Count > 0;
                    if (categoryItemInUse)
                    {
                        var tableNames = form.StringListResult;
                        return (true, tableNames);
                    }
                }
                else if (result == DialogResult.Abort)
                {
                    MessageBox.Show("There is a problem retrieving information if this client is being used on other categories. Please try again.", MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return (true, null); // Precautionary measure to make sure it will not continue to add the item
                }
            }
            return (false, null);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCategoryItemForm addCategoryItemForm = new()
            {
                ParentControl = this,
                CategoryName = CurrentCategoryKey
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
            CurrentCategoryKey = cmbCategories.Text.ToString();
            PopulateTableAndFields();
        }
    }
}
