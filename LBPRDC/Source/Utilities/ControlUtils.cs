using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBPRDC.Source.Utilities
{
    internal class ControlUtils
    {
        public static bool AreInputsEmpty(Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        return true;
                    }
                }
                // You can add more conditions for other types of controls (e.g., ComboBox, etc.) if needed
            }
            return false;
        }

        public static void ToggleInputState(Control container)
        {
            foreach(Control control in container.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Enabled = !textBox.Enabled;
                }
            }
        }
    }
}
