namespace LBPRDC.Source.Utilities
{
    internal class StatusCode
    {
        public enum LockState
        {
            Lock,
            Unlock
        }

        public enum EntryType
        {
            Regular,
            Custom
        }

        public enum TimeType
        {
            Regular,
            Overtime
        }

        public enum BillingRecordType
        {
            Temporary,
            Permanent
        }
    }
}
