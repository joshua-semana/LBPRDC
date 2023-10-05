using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBPRDC.Source.Utilities
{
    internal class ExitConfirmationUtil
    {
        public static bool ConfirmExit()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit? Your account will be signed out, and any unsaved changes will be lost.", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return (result == DialogResult.Yes);
        }
    }
}
