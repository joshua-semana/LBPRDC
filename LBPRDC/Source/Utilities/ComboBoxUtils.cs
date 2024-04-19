namespace LBPRDC.Source.Utilities
{
    public static class ComboBoxUtils
    {
        public static void HandleMouseWheel(object sender, MouseEventArgs e)
        {
            // This will disable the mouse wheel scrolling of items
            ((HandledMouseEventArgs)e).Handled = true;
        }

        public static void HandleKeyDown(object sender, KeyEventArgs e)
        {
            // This will disable the arrow keys to navigate the items
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.Handled = true;
            }
        }
    }
}
