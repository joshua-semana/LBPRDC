using Microsoft.VisualBasic;
using System;
using System.Text.Json;

namespace LBPRDC.Source.Utilities
{
    [Serializable]
    internal class UserPreference
    {
        public bool ShowEmployeeID { get; set; }
        public bool ShowName { get; set; }
        public NameFormat SelectedNameFormat { get; set; }
        public bool ShowGender { get; set; }
        public bool ShowEmploymentStatus { get; set; }
        public bool ShowClassification { get; set; }
        public bool ShowDepartment { get; set; }
        public bool ShowLocation { get; set; }
        public bool ShowEmailAddress { get; set; }
        public EmailFormat SelectedEmailFormat { get; set; }
        public bool ShowContactNumber { get; set; }
        public ContactFormat SelectedContactFormat { get; set; }
        public bool ShowPosition { get; set; }
        public PositionFormat SelectedPositionFormat { get; set; }
        public bool ShowSalaryRate { get; set; }
        public bool ShowBillingRate { get; set; }
        public bool ShowWageType { get; set; }

    }

    public enum NameFormat
    {
        Full1,
        Full2,
        FirstAndLastOnly,
        LastNameOnly,
        Separated
    }

    public enum EmailFormat
    {
        FirstOnly,
        Both
    }

    public enum ContactFormat
    {
        FirstOnly,
        Both
    }

    public enum PositionFormat
    {
        NameOnly,
        CodeOnly,
        Both
    }
}
