namespace LBPRDC.Source.Models
{
    public class AccessPermission
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        public class Permissions
        {
            public bool CanAccessBillingTab { get; set; } = false;
            public bool CanAccessEmployeesTab { get; set; } = false;
            public bool CanAccessCategoriesTab { get; set; } = false;
            public bool CanAccessLogsTab { get; set; } = false;
            public bool CanAccessAccountsTab { get; set; } = false;

            public bool CanAddEmployee { get; set; } = false;
            public bool CanEditEmployee { get; set; } = false;
            public bool CanUpdateEmployee { get; set; } = false;
            public bool CanArchiveEmployee { get; set; } = false;

            public bool CanAddCategoryItem { get; set; } = false;
            public bool CanUpdateCategoryItem { get; set; } = false;
            public bool CanDeleteCategoryItem { get; set; } = false;

            public bool CanViewClientsCategory { get; set; } = false;
            public bool CanViewClassificationsCategory { get; set; } = false;
            public bool CanViewWagesCategory { get; set; } = false;
            public bool CanViewPositionsCategory { get; set; } = false;
            public bool CanViewDepartmentsCategory { get; set; } = false;
            public bool CanViewLocationsCategory { get; set; } = false;
            public bool CanViewEmploymentStatusCategory { get; set; } = false;

            public bool CanAccessPermissions { get; set; } = false;
            public bool CanAddUser { get; set; } = false;
            public bool CanEditUser { get; set; } = false;
            public bool CanResetUserPassword { get; set; } = false;

            public bool CanAddBilling { get; set; } = false;
            public bool CanDuplicateBilling { get; set; } = false;
            public bool CanReleaseBilling { get; set; } = false;
            public bool CanUploadFileInBilling { get; set; } = false;
            public bool CanExportInBilling { get; set; } = false;
            public bool CanArchiveBilling { get; set; } = false;
            public bool CanUpdateBillingInformation { get; set; } = false;
        }
    }
}
