using System.Drawing;
using System.Windows.Forms;

namespace Library_management_system
{
    public static class ThemeManager
    {
        public static void ApplyTheme(Form form, string title)
        {
            form.Text = title;
            form.StartPosition = FormStartPosition.CenterScreen;
            
            // If it's a dialog (FixedDialog), we might not want to mess with borders too much, 
            // but for general forms:
            if (form.FormBorderStyle == FormBorderStyle.Sizable)
            {
                // form.WindowState = FormWindowState.Maximized; // Optional default
            }

            // Example generic styling for controls
            foreach (Control c in form.Controls)
            {
                if (c is Button btn)
                {
                    btn.Cursor = Cursors.Hand;
                    // btn.FlatStyle = FlatStyle.Flat;
                    // btn.FlatAppearance.BorderSize = 0;
                }
            }
        }
    }
}
