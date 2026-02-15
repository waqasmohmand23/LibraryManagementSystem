using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Library_management_system
{
    public partial class ReturnBook : Form
    {
        private DataGridView dgvIssued;
        private TextBox txtSearchEnrollment;
        private Button btnReturn, btnCancel;
        private DateTimePicker dtpReturnDate;

        public ReturnBook()
        {
            InitializeComponent();
            ApplyTheme();
            LoadIssuedBooks();
        }

        private void InitializeComponent()
        {
            this.Size = new Size(800, 600);
            
            // Search
            this.Controls.Add(new Label { Text = "Enter Enrollment No:", Location = new Point(20, 20), AutoSize = true });
            txtSearchEnrollment = new TextBox { Location = new Point(150, 17), Size = new Size(200, 25) };
            txtSearchEnrollment.TextChanged += (s, e) => LoadIssuedBooks(txtSearchEnrollment.Text);
            this.Controls.Add(txtSearchEnrollment);

            // Grid
            dgvIssued = new DataGridView();
            dgvIssued.Location = new Point(20, 60);
            dgvIssued.Size = new Size(740, 350);
            dgvIssued.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvIssued.ReadOnly = true;
            dgvIssued.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIssued.AllowUserToAddRows = false;
            dgvIssued.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIssued.CellClick += DgvIssued_CellClick;
            this.Controls.Add(dgvIssued);

            // Return Panel
            int y = 430;
            this.Controls.Add(new Label { Text = "Return Date:", Location = new Point(200, y + 5), AutoSize = true });
            dtpReturnDate = new DateTimePicker { Location = new Point(300, y), Size = new Size(200, 25) };
            this.Controls.Add(dtpReturnDate);

            btnReturn = new Button { Text = "Return", Location = new Point(520, y), Size = new Size(100, 25) };
            btnReturn.Click += BtnReturn_Click;
            this.Controls.Add(btnReturn);

            btnCancel = new Button { Text = "Cancel", Location = new Point(640, y), Size = new Size(100, 25) };
            btnCancel.Click += (s, e) => this.Close();
            this.Controls.Add(btnCancel);
        }

        private void ApplyTheme()
        {
            ThemeManager.ApplyTheme(this, "Return Book");
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void LoadIssuedBooks(string enrollment = "")
        {
            DataManager.LoadData();
            var issued = DataManager.Issues.Where(i => i.ReturnDate == null).ToList();

            if (!string.IsNullOrWhiteSpace(enrollment))
            {
                issued = issued.Where(i => i.StudentEnrollment.ToLower().Contains(enrollment.ToLower())).ToList();
            }

            dgvIssued.DataSource = null;
            dgvIssued.DataSource = issued;
        }

        private void DgvIssued_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
               // Just selection, nothing special needed here as we use SelectedRows in BtnReturn
            }
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            if (dgvIssued.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book to return.", "Select Book", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedIssue = (Issue)dgvIssued.SelectedRows[0].DataBoundItem;
            
            // Update Issue
            selectedIssue.ReturnDate = dtpReturnDate.Value;
            DataManager.SaveIssues();

            // Increment Book Quantity
            var book = DataManager.Books.FirstOrDefault(b => b.Title == selectedIssue.BookName);
            if (book != null)
            {
                book.Quantity++;
                DataManager.SaveBooks();
            }

            MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadIssuedBooks(txtSearchEnrollment.Text);
        }
    }
}
