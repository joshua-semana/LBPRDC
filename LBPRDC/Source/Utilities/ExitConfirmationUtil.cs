namespace LBPRDC.Source.Utilities
{
    internal class ExitConfirmationUtil
    {
        public static bool ConfirmExit()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit? Your account will be signed out, and any unsaved changes will be lost.", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return (result == DialogResult.Yes);
        }

        public static bool CloseProgress()
        {
            var output = MessageBox.Show("Are you sure you want to close this form? You have unsaved progress. Any unsaved changes will be lost.", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return output == DialogResult.Yes;
        }
    }
}
