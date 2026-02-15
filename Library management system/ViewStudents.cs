using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Library_management_system
{
    public partial class ViewStudents : Form
    {
        private DataGridView dgvStudents;
        private TextBox txtSearch;
        private Label lblTotal;

        public ViewStudents()
        {
            InitializeComponent();
            ApplyTheme();
            LoadStudents();
        }

        private void InitializeComponent()
        {
            this.Size = new Size(800, 600);

            // Search
            Label lblSearch = new Label { Text = "Search Enrollment/Name:", Location = new Point(12, 15), AutoSize = true };
            this.Controls.Add(lblSearch);

            txtSearch = new TextBox { Location = new Point(160, 12), Size = new Size(200, 25) };
            txtSearch.TextChanged += TxtSearch_TextChanged;
            this.Controls.Add(txtSearch);

            // Total Label
            lblTotal = new Label { Text = "Total Students: 0", Location = new Point(400, 15), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            this.Controls.Add(lblTotal);

            // Grid
            dgvStudents = new DataGridView();
            dgvStudents.Location = new Point(12, 50);
            dgvStudents.Size = new Size(760, 500);
            dgvStudents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.ReadOnly = true;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.Controls.Add(dgvStudents);
        }

        private void ApplyTheme()
        {
            ThemeManager.ApplyTheme(this, "View Students");
            this.WindowState = FormWindowState.Maximized;
        }

        private void LoadStudents(string searchTerm = "")
        {
            DataManager.LoadData();
            var students = DataManager.Students;

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                var filtered = new List<Student>();
                foreach (var s in students)
                {
                    if (s.Name.ToLower().Contains(searchTerm) || 
                        s.EnrollmentNo.ToLower().Contains(searchTerm))
                    {
                        filtered.Add(s);
                    }
                }
                dgvStudents.DataSource = null;
                dgvStudents.DataSource = filtered;
                lblTotal.Text = $"Total Students: {filtered.Count}";
            }
            else
            {
                dgvStudents.DataSource = null;
                dgvStudents.DataSource = students;
                lblTotal.Text = $"Total Students: {students.Count}";
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadStudents(txtSearch.Text);
        }
    }
}
