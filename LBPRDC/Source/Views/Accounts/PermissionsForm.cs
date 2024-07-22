using LBPRDC.Source.Config;
using LBPRDC.Source.Models;
using LBPRDC.Source.Services;
using LBPRDC.Source.Views.Accounts;

namespace LBPRDC.Source.Views.Categories
{
    public partial class PermissionsForm : Form
    {
        public AccountsControl? ParentAccountsControl { get; set; }

        private List<RolePermission.View>? CurrentUserRolePermissionList = new();

        public PermissionsForm()
        {
            InitializeComponent();
        }

        private async void PermissionsForm_Load(object sender, EventArgs e)
        {
            var userRoleCount = await FetchAndPopulateUserRolesCollection();

            if (userRoleCount == 0)
            {
                MessageBox.Show(MessagesConstants.Error.MISSING_USER_ROLES, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            FetchPermissionsByUserRole();
        }

        private async Task<int> FetchAndPopulateUserRolesCollection()
        {
            cmbUserRoles.SelectedIndexChanged -= cmbUserRoles_SelectedIndexChanged;

            var userRoles = await UserRoleService.GetItemsForComboBox(WithDefault: false, ExcludeAdmin: true);
            cmbUserRoles.DataSource = userRoles;
            cmbUserRoles.DisplayMember = nameof(UserRole.Name);
            cmbUserRoles.ValueMember = nameof(UserRole.ID);

            cmbUserRoles.SelectedIndexChanged += cmbUserRoles_SelectedIndexChanged;

            return userRoles.Count;
        }

        private async void FetchPermissionsByUserRole()
        {
            flowPermissions.Controls.Clear();
            var currentUserPermissions = await RolePermissionService.GetAllPermission(Convert.ToInt32(cmbUserRoles.SelectedValue));
            CurrentUserRolePermissionList = currentUserPermissions;
            await FetchAndPopulateCurrentUserRolePermissions(currentUserPermissions);
        }

        private async Task FetchAndPopulateCurrentUserRolePermissions(List<RolePermission.View> CurrentUserRolePermissions)
        {
            var allPermissions = await AccessPermissionService.GetAllPermissions();

            foreach (var groupedPermissions in allPermissions.GroupBy(gb => gb.Description))
            {
                Label label = new()
                {
                    Text = string.IsNullOrWhiteSpace(groupedPermissions.Key) ? "Uncategorized" : groupedPermissions.Key,
                    Font = new Font(this.Font, FontStyle.Bold),
                    AutoSize = true,
                    Padding = new Padding(0, 8, 0, 8),
                    Margin = new Padding(0)
                };

                flowPermissions.Controls.Add(label);

                foreach (var permission in groupedPermissions.OrderBy(ob => ob.Name))
                {
                    var matchedPermission = CurrentUserRolePermissions.Where(w => w.AccessPermissionName == permission.Name).FirstOrDefault();

                    CheckBox checkBox = new()
                    {
                        Tag = permission.ID,
                        Text = $"{permission.ID} - {Utilities.StringFormat.CamelCaseToSpaced(permission.Name)}",
                        AutoSize = true,
                        Checked = matchedPermission != null
                    };

                    flowPermissions.Controls.Add(checkBox);
                }
            }
        }

        private void cmbUserRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            FetchPermissionsByUserRole();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (CurrentUserRolePermissionList == null)
            {
                MessageBox.Show(MessagesConstants.Error.ACTION, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var CurrentUserPermissions = CurrentUserRolePermissionList.Select(s => s.AccessPermissionID).ToList();
            var CheckedItemsList = GetCheckedItemsInControl(flowPermissions);

            var currentUserRoleID = Convert.ToInt32(cmbUserRoles.SelectedValue);
            var permissionsToAdd = CheckedItemsList.Except(CurrentUserPermissions).ToList();
            var permissionsToDelete = CurrentUserPermissions.Except(CheckedItemsList).ToList();

            var isUpdated = await RolePermissionService.UpdatePermissions(currentUserRoleID, permissionsToAdd, permissionsToDelete);

            if (isUpdated)
            {
                FetchPermissionsByUserRole();
                MessageBox.Show(MessagesConstants.Result.SUCCESS_UPDATE_PERMISSIONS, MessagesConstants.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(MessagesConstants.Error.ACTION, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<int> GetCheckedItemsInControl(Control container)
        {
            List<int> checkedItems = new();

            foreach (var control in container.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    checkedItems.Add(Convert.ToInt32(checkBox.Tag));
                }
            }

            return checkedItems;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
