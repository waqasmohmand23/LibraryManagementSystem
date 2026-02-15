using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Library_management_system
{
    public partial class IssueBook : Form
    {
        private ComboBox cbStudent, cbBook;
        private TextBox txtName, txtDept, txtContact, txtEmail;
        private DateTimePicker dtpIssueDate;
        private Label lblMessage;

        public IssueBook()
        {
            InitializeComponent();
            ApplyTheme();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.Size = new Size(500, 500);

            int y = 20;
            int lblX = 20;
            int ctrlX = 150;

            // Student Selection
            this.Controls.Add(CreateLabel("Select Enrollment:", lblX, y));
            cbStudent = new ComboBox { Location = new Point(ctrlX, y), Size = new Size(250, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            cbStudent.SelectedIndexChanged += CbStudent_SelectedIndexChanged;
            this.Controls.Add(cbStudent);
            y += 40;

            // Auto-filled Student Details
            this.Controls.Add(CreateLabel("Student Name:", lblX, y));
            txtName = CreateReadOnlyTextBox(ctrlX, y);
            this.Controls.Add(txtName);
            y += 40;

            this.Controls.Add(CreateLabel("Department:", lblX, y));
            txtDept = CreateReadOnlyTextBox(ctrlX, y);
            this.Controls.Add(txtDept);
            y += 40;

            this.Controls.Add(CreateLabel("Contact:", lblX, y));
            txtContact = CreateReadOnlyTextBox(ctrlX, y);
            this.Controls.Add(txtContact);
            y += 40;

            this.Controls.Add(CreateLabel("Email:", lblX, y));
            txtEmail = CreateReadOnlyTextBox(ctrlX, y);
            this.Controls.Add(txtEmail);
            y += 40;

            // Book Selection
            this.Controls.Add(CreateLabel("Select Book:", lblX, y));
            cbBook = new ComboBox { Location = new Point(ctrlX, y), Size = new Size(250, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            this.Controls.Add(cbBook);
            y += 40;

            // Date
            this.Controls.Add(CreateLabel("Issue Date:", lblX, y));
            dtpIssueDate = new DateTimePicker { Location = new Point(ctrlX, y), Size = new Size(250, 25) };
            this.Controls.Add(dtpIssueDate);
            y += 50;

            // Buttons
            Button btnIssue = new Button { Text = "Issue Book", Location = new Point(ctrlX, y), Size = new Size(100, 30) };
            btnIssue.Click += BtnIssue_Click;
            this.Controls.Add(btnIssue);

            Button btnCancel = new Button { Text = "Cancel", Location = new Point(ctrlX + 120, y), Size = new Size(100, 30) };
            btnCancel.Click += (s, e) => this.Close();
            this.Controls.Add(btnCancel);
            
            y += 40;
            lblMessage = new Label { Location = new Point(lblX, y), Size = new Size(400, 30), ForeColor = Color.Red };
            this.Controls.Add(lblMessage);
        }

        private void ApplyTheme()
        {
            ThemeManager.ApplyTheme(this, "Issue Book");
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void LoadData()
        {
            DataManager.LoadData();
            cbStudent.Items.Clear();
            foreach (var s in DataManager.Students)
            {
                cbStudent.Items.Add(s.EnrollmentNo);
            }

            cbBook.Items.Clear();
            foreach (var b in DataManager.Books)
            {
                cbBook.Items.Add(b.Title);
            }
        }

        private void CbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStudent.SelectedItem == null) return;
            string enrollment = cbStudent.SelectedItem.ToString();
            var student = DataManager.Students.FirstOrDefault(s => s.EnrollmentNo == enrollment);
            if (student != null)
            {
                txtName.Text = student.Name;
                txtDept.Text = student.Department;
                txtContact.Text = student.Contact;
                txtEmail.Text = student.Email;
            }
        }

        private void BtnIssue_Click(object sender, EventArgs e)
        {
            if (cbStudent.SelectedItem == null || cbBook.SelectedItem == null)
            {
                MessageBox.Show("Please select both a student and a book.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string bookTitle = cbBook.SelectedItem.ToString();
            var book = DataManager.Books.FirstOrDefault(b => b.Title == bookTitle);

            if (book == null || book.Quantity <= 0)
            {
                MessageBox.Show("This book is not available (Out of Stock).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if student already has this book issued? (Optional, skipping for simple MVP)

            // Create Issue Record
            Issue issue = new Issue
            {
                StudentEnrollment = cbStudent.SelectedItem.ToString(),
                StudentName = txtName.Text,
                StudentDepartment = txtDept.Text,
                StudentContact = txtContact.Text,
                StudentEmail = txtEmail.Text,
                BookName = bookTitle,
                IssueDate = dtpIssueDate.Value,
                ReturnDate = null
            };

            DataManager.Issues.Add(issue);
            DataManager.SaveIssues();

            // Decrement Book Quantity
            book.Quantity--;
            DataManager.SaveBooks();

            MessageBox.Show("Book issued successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private Label CreateLabel(string text, int x, int y)
        {
            return new Label { Text = text, Location = new Point(x, y + 3), AutoSize = true };
        }

        private TextBox CreateReadOnlyTextBox(int x, int y)
        {
            return new TextBox { Location = new Point(x, y), Size = new Size(250, 25), ReadOnly = true, BackColor = SystemColors.Control };
        }
    }
}
