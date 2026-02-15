using System;
using System.Drawing;
using System.Windows.Forms;

namespace Library_management_system
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            ThemeManager.ApplyTheme(this, "Library Management System - Sign Up");
            this.StartPosition = FormStartPosition.CenterParent; // Override to CenterParent
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            txtUsername.PlaceholderText = "Username";
            txtPassword.PlaceholderText = "Password";
            txtPassword.PasswordChar = '*';
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DataManager.Users.ContainsKey(username))
            {
                MessageBox.Show("Username already exists. Please try another.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Save new user with Hashed Password
            string hashedPassword = SecurityHelper.HashPassword(password);
            DataManager.Users[username] = hashedPassword;
            DataManager.SaveUsers();

            MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Close this form to return to Login
            this.Close();
        }
    }
}
