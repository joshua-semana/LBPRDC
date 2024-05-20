using LBPRDC.Source.Config;

namespace LBPRDC.Source.Models
{
    public class Billing
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; } = "";
        public string OfficerName { get; set; } = "";
        public string OfficerPosition { get; set; } = "";
        public int Month { get; set; }
        public int Year { get; set; }
        public int Quarter { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ReleaseDate { get; set; } // Nullable
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string ConstantJSON { get; set; } = "";
        public string EditableJSON { get; set; } = "";
        public string AccrualsJSON { get; set; } = "";
        public string VerificationStatus { get; set; } = StringConstants.Status.UNVERIFIED;
        public bool IsEquipmentIncluded { get; set; } = false;
        public string Description { get; set; } = "";
        public string Status { get; set; } = StringConstants.Status.ACTIVE; // Active, Inactive (For Archive)
        public string LockStatus { get; set; } = StringConstants.Status.UNLOCK; // Lock, Unlock (If billing is released, lock the billing)

        public class Account
        {
            public int ID { get; set; }
            public int ClientID { get; set; }
            public int BillingID { get; set; }
            public string AccountNumber { get; set; } = "";
            public string EntryType { get; set; } = StringConstants.Type.REGULAR; // Regular or Custom or Equipment
            public string OfficialReceiptNumber { get; set; } = "";
            public string Classification { get; set; } = "";
            public decimal BilledValue { get; set; }
            public decimal NetBilling { get; set; }
            public decimal CollectedValue { get; set; }
            public DateTime? CollectionDate { get; set; } // Nullable
            public decimal Balance { get; set; }
            public string Purpose { get; set; } = "";
            public DateTime Timestamp { get; set; } = DateTime.Now;
            public string Remarks { get; set; } = "";

            public class Equipment
            {
                public int ID { get; set; }
                public int ClientID { get; set; }
                public int BillingID { get; set; }
                public string AccountNumber { get; set; } = "";
                public string EntryType { get; set; } = StringConstants.Type.EQUIPMENT; // Equipment Only
                public string OfficialReceiptNumber { get; set; } = "";
                public string Classification { get; set; } = "";
                public decimal BilledValue { get; set; }
                public decimal NetBilling { get; set; }
                public decimal CollectedValue { get; set; }
                public DateTime? CollectionDate { get; set; } // Nullable
                public decimal Balance { get; set; }
                public string Purpose { get; set; } = "";
                public DateTime Timestamp { get; set; } = DateTime.Now;
                public string Remarks { get; set; } = "Supplies and Equipment Billing";
            }
        }

        public class Record
        {
            public int ID { get; set; }
            public int ClientID { get; set; }
            public int BillingID { get; set; }
            public Guid Guid { get; set; }
            public string EntryType { get; set; } = StringConstants.Type.REGULAR;
            public string EmployeeID { get; set; } = "";
            public string FullName { get; set; } = "";
            public string Position { get; set; } = "";
            public string Department { get; set; } = "";
            public decimal SalaryRate { get; set; }
            public decimal BillingRate { get; set; }
            public string TimeDetailJSON { get; set; } = "";
            public string RegularAccountNumber { get; set; } = "";
            public string OvertimeAccountNumber { get; set; } = "";
            public decimal RegularBillingValue { get; set; }
            public decimal OvertimeBillingValue { get; set; }
            public decimal RegularCollectedValue { get; set; }
            public decimal OvertimeCollectedValue { get; set; }
            // TODO : Verify if these DateTimes are indeed Nullable
            public DateTime? RegularCollectedDate { get; set; }
            public DateTime? OvertimeCollectedDate { get; set; }
            public string TimekeepRemarks { get; set; } = "";
            public string UserRemarks { get; set; } = "";
            public string RegularAdjustmentRemarks { get; set; } = "";
            public string OvertimeAdjustmentRemarks { get; set; } = "";
            public string Description { get; set; } = "";
            public string Status { get; set; } = StringConstants.Status.NOT_RELEASED;
            public DateTime Timestamp { get; set; } = DateTime.Now;
            public Billing Billing { get; set; }

            public class View : Record
            {
                public string BillingName { get; set; } = "";
            }

            public class TotalGross
            {
                public string AccountNumber { get; set; } = "";
                public string Department { get; set; } = "";
                public decimal GrossBilling { get; set; }
            }
        }

        public class AccountsWithType
        {
            public string AccountNumber { get; set; } = "";
            public string EntryType { get; set; } = StringConstants.Type.REGULAR;
        }
    }
}
