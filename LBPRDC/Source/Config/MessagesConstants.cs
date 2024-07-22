namespace LBPRDC.Source.Config
{
    internal class MessagesConstants
    {
        public const string ERROR = "Error";
        public const string UPDATE = "Update";
        public const string SUCCESS = "Success";
        public const string CONFIRMATION = "Confirmation";
        public const string INVALID_INPUT = "Invalid Input";

        public class Result
        {
            public const string SUCCESS_UPDATE_PERMISSIONS = "You have successfully updated the permission of this user role group.";
        }

        public class Operation
        {
            public const string ADD = "Add";
            public const string UPDATE = "Update";
            public const string DELETE = "Delete";
            public const string RESET_PASSWORD = "Reset Password";
            public const string ARCHIVE = "Archive";
        }

        public class Action
        {
            public const string UPDATE = "Update";
            public const string COLLECT = "Collect";
        }

        public class Error
        {
            public const string TITLE = "Error";
            public const string RETRIEVE_DATA = "There seems to be a problem retreiving the data. Please try again.";
            public const string ACTION = "There is a problem performing this action. Please try again.";
            public const string MISSING = "There are necessary information that are missing. Operation will be cancelled.";
            public const string MISSING_CLIENT = "Client information is missing. Operation will be cancelled.";
            public const string MISSING_BILLING = "Billing information is missing. Operation will be cancelled.";
            public const string MISSING_CLIENT_BILLING = "Client and billing information is missing. Operation will be cancelled.";
            public const string MISSING_ACCRUALS = "Accruals information is missing. Operation will be cancelled. Please upload accruals data to this billing.";
            public const string MISSING_EMPLOYEE = "Employee information is missing. Operation will be cancelled. Please try again.";
            public const string MISSING_USER = "User information is missing. Operation will be cancelled. Please try again.";
            public const string MISSING_USER_ROLES = "There are no user roles available, please add user roles first. Operation will be cancelled. Please try again.";
            public const string CANT_RETRIEVE = "Unable to retrieve information.";
        }

        public class Billing
        {
            public const string NEW = "New Billing";
            public const string EXIST = "This billing name has already been used. Please enter another billing name to continue.";
        }

        public class Update
        {
            public const string TITLE = "Update Confirmation";
            public const string QUESTION = "Are you sure you want to update this employee's information?";
            public const string SUCCESS = "You have successfully updated this employee's information.";
            public const string FAILED = "Update action is failed. Please try again.";
        }

        public class Add
        {
            public const string TITLE = "Add";
            public const string SUCCESS_BILLING = "You have successfully added a new billing.";
        }

        public class Cancel
        {
            public const string TITLE = "Cancel Confirmation";
            public const string QUESTION = "Are you sure you want to cancel this operation?";
        }

        public class Archive
        {
            public const string TITLE = "Archive";
            public const string ADD_TO_ARCHIVE = "Unable to archive the selected employee. Please try again.";
            public const string DELETE_ALL_EMPLOYEE_RECORD = "Unable to delete all of the record of the selected employee. Please try again.";
        }

        public class Logs
        {
            public const string TITLE_NEW_CATEGORY = "New Category Item";
            public const string TITLE_NEW_BILLING = "New Billing";
            public const string NEW_POSITION = "User added a new position with name of ";
            public const string UPDATE_POSITION = "This user updated an item under the position category with an ID of ";
            public const string NEW_BILLING = "User added a new billing record with a name of ";
        }

        public const string CONFIRMATION_CANCEL = MessagesConstants.Cancel.TITLE;
        public const string CONFIRMATION_CANCEL_QUESTION = MessagesConstants.Cancel.QUESTION;

        public const string ERROR_ACTION = "There is a problem performing this action. Please try again.";
        public const string ERROR_RETRIEVE_CLIENT = "There is a problem retrieving client information; therefore, it is unable to continue to proceed with this operation.";

        // START OF CATEGORIES CONTROL

        public const string CONFIRMATION_DELETE = "Are you sure you want to delete this item?";

        public const string SUCCESS_DELETE = "You have successfully deleted this category item.";

        public const string INVALID_CATEGORY_UPDATE = "This category item is being used and cannot be updated to inactive. These are the list of categories it is currently being used:";
        public const string INVALID_CATEGORY_DELETE = "This category item is being used and cannot be deleted. These are the list of categories it is currently being used:";
        public const string INVALID_OPERATION = "There are no operations matching your action.";

        // END OF CATEGORIES CONTROL

        // START OF HISTORY

        public const string FAILED_HISTORY_ADD = "Failed to add a new history for this employee.";

        // END OF HISTORY
    }
}
