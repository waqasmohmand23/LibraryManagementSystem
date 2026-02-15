using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Library_management_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataManager.LoadData(); // Load data on startup
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            ThemeManager.ApplyTheme(this, "Library Management System - Login");
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Simple UI cleanup
            txtUsername.PlaceholderText = "Username";
            txtPassword.PlaceholderText = "Password";
            txtPassword.PasswordChar = '*';
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Removed manual MouseEnter/MouseClick handlers as PlaceholderText handles this natively in modern .NET

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (DataManager.Users.ContainsKey(username))
            {
                string storedHash = DataManager.Users[username];
                if (SecurityHelper.VerifyPassword(password, storedHash))
                {
                // Login successful
                DashboardForm dash = new DashboardForm();
                this.Hide();
                dash.ShowDialog(); // Use ShowDialog to block until Dashboard closes
                this.Close(); // Close login after dashboard is done (or handle re-show if logout is implemented)
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUpForm sign = new SignUpForm();
            this.Hide();
            sign.ShowDialog(); // Show Signup modally
            this.Show(); // Re-show login when Signup closes
        }
    }
}
