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

        public CategoriesControl()
        {
            InitializeComponent();
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

            CurrentCategory = Categories[0];
            OriginalValues = new();
            RequiredFields = new();

            InitializeCategoriesComboBoxItems();
        }

        private void CategoriesControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                PopulateTexfieldsByCategory();
            }
        }

        private void InitializeCategoriesComboBoxItems()
        {
            cmbCategories.DataSource = Categories;
        }

        private void InitializeDepartmentComboBoxItems()
        {
            cmbDepartment.DataSource = DepartmentService.GetAllItemsForComboBox();
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "ID";
        }

        private void PopulateTexfieldsByCategory()
        {
            CurrentCategory = cmbCategories.SelectedItem.ToString();

            ControlUtils.ToggleControlsVisibilityInContainer(flowRightContent, false);
            ControlUtils.ToggleControlVisibility(CommonFields, true);

            dgvCategory.Columns.Clear();

            switch (CurrentCategory)
            {
                case "Position":
                    dgvCategory.DataSource = PositionService.GetAllItems();
                    ControlUtils.ToggleControlVisibility(PositionSpecificFields, true);
                    break;

                case "Location":
                    dgvCategory.DataSource = LocationService.GetAllItemsForCategories()
                        .Where(w => w.ID != 1 && w.DepartmentName != NoneDepartmentName).ToList();
                    InitializeDepartmentComboBoxItems();
                    ControlUtils.ToggleControlVisibility(LocationSpecificFields, true);
                    break;

                case "Department":
                    dgvCategory.DataSource = DepartmentService.GetAllItems();
                    break;

                case "Civil Status":
                    dgvCategory.DataSource = CivilStatusService.GetAllItems();
                    break;

                case "Employment Status":
                    dgvCategory.DataSource = EmploymentStatusService.GetAllItems();
                    break;
            }

            UpdateRequiredFields();
        }

        private void UpdateRequiredFields()
        {
            RequiredFields.Clear();
            foreach (Control control in flowRightContent.Controls)
            {
                if (control is TextBox || control is ComboBox && control.AccessibleName != "Description")
                {
                    RequiredFields.Add(control);
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            PopulateTexfieldsByCategory();
        }

        private void dgvCategory_SelectionChanged(object sender, EventArgs e)
        {
            if (this.Visible && dgvCategory.SelectedRows.Count > 0)
            {
                btnUpdate.Enabled = false;

                foreach (var kv in OriginalValues)
                {
                    kv.Key.TextChanged -= ControlData_Changed;
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
            cmbDepartment.SelectedIndex = Convert.ToInt32(data.Cells["DepartmentID"].Value);
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
                kv.Key.TextChanged += ControlData_Changed;
            }
        }

        private void ControlData_Changed(object sender, EventArgs e)
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
    }
}
