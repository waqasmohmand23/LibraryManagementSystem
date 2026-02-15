using System;
using System.Drawing;
using System.Windows.Forms;

namespace Library_management_system
{
    public partial class AddStudent : Form
    {
        private TextBox txtName, txtEnrollment, txtDepartment, txtContact, txtEmail;
        private Button btnSave, btnCancel;

        public AddStudent()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void InitializeComponent()
        {
            this.Size = new Size(400, 450);
            
            int y = 20;
            int lblX = 20;
            int txtX = 140;

            this.Controls.Add(CreateLabel("Student Name:", lblX, y));
            txtName = CreateTextBox(txtX, y);
            this.Controls.Add(txtName);
            y += 40;

            this.Controls.Add(CreateLabel("Enrollment No:", lblX, y));
            txtEnrollment = CreateTextBox(txtX, y);
            this.Controls.Add(txtEnrollment);
            y += 40;

            this.Controls.Add(CreateLabel("Department:", lblX, y));
            txtDepartment = CreateTextBox(txtX, y);
            this.Controls.Add(txtDepartment);
            y += 40;

            this.Controls.Add(CreateLabel("Contact:", lblX, y));
            txtContact = CreateTextBox(txtX, y);
            this.Controls.Add(txtContact);
            y += 40;

            this.Controls.Add(CreateLabel("Email:", lblX, y));
            txtEmail = CreateTextBox(txtX, y);
            this.Controls.Add(txtEmail);
            y += 60;

            // Buttons
            btnSave = new Button();
            btnSave.Text = "Save Info";
            btnSave.Location = new Point(50, y);
            btnSave.Size = new Size(100, 30);
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);

            btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Location = new Point(200, y);
            btnCancel.Size = new Size(100, 30);
            btnCancel.Click += (s, e) => this.Close();
            this.Controls.Add(btnCancel);
        }

        private Label CreateLabel(string text, int x, int y)
        {
            return new Label { Text = text, Location = new Point(x, y + 3), AutoSize = true };
        }

        private TextBox CreateTextBox(int x, int y)
        {
            return new TextBox { Location = new Point(x, y), Size = new Size(200, 25) };
        }

        private void ApplyTheme()
        {
            ThemeManager.ApplyTheme(this, "Add Student");
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || 
                string.IsNullOrWhiteSpace(txtEnrollment.Text) ||
                string.IsNullOrWhiteSpace(txtDepartment.Text))
            {
                MessageBox.Show("Please fill in Name, Enrollment, and Department.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Student student = new Student
            {
                Name = txtName.Text.Trim(),
                EnrollmentNo = txtEnrollment.Text.Trim(),
                Department = txtDepartment.Text.Trim(),
                Contact = txtContact.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };

            DataManager.Students.Add(student);
            DataManager.SaveStudents();

            MessageBox.Show("Student details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtEnrollment.Clear();
            txtDepartment.Clear();
            txtContact.Clear();
            txtEmail.Clear();
        }
    }
}
