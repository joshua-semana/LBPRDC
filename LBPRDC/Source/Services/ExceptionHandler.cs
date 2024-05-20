using LBPRDC.Source.Config;
using System.Runtime.CompilerServices;

namespace LBPRDC.Source.Services
{
    internal class ExceptionHandler
    {
        public static bool HandleException(Exception ex, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            string errorMessage = $"An error occurred in {filePath} at line {lineNumber}: {ex.Message}\n\nIf the error persists, please restart the application.";
            MessageBox.Show(errorMessage, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }
}
