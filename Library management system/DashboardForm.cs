using System;
using System.Drawing;
using System.Windows.Forms;

namespace Library_management_system
{
    public partial class DashboardForm : Form
    {
        private DataGridView dgvBooks;
        private TextBox txtSearch;
        private Label lblTotalBooks;

        public DashboardForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
            ApplyTheme();
        }

        private void InitializeCustomComponents()
        {
            // Menu Events
            this.addNewStudentsToolStripMenuItem.Click += AddNewStudentsToolStripMenuItem_Click;
            this.viewStudentInfoToolStripMenuItem.Click += ViewStudentInfoToolStripMenuItem_Click;
            this.viewBooksToolStripMenuItem.Click += ViewBooksToolStripMenuItem_Click;
            this.issueBooksToolStripMenuItem.Click += IssueBooksToolStripMenuItem_Click;
            this.returnBooksToolStripMenuItem.Click += ReturnBooksToolStripMenuItem_Click;

            // 
            // txtSearch
            // 
            this.txtSearch = new TextBox();
            this.txtSearch.Location = new System.Drawing.Point(12, 40); // Below menu
            this.txtSearch.Size = new System.Drawing.Size(300, 25);
            this.txtSearch.PlaceholderText = "Search books by title or author...";
            this.txtSearch.TextChanged += new EventHandler(this.txtSearch_TextChanged);
            this.Controls.Add(this.txtSearch);

            //
            // lblTotalBooks
            //
            this.lblTotalBooks = new Label();
            this.lblTotalBooks.Location = new System.Drawing.Point(330, 42);
            this.lblTotalBooks.Size = new System.Drawing.Size(200, 25);
            this.lblTotalBooks.Text = "Total Books: 0";
            this.lblTotalBooks.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.Controls.Add(this.lblTotalBooks);

            // 
            // dgvBooks
            // 
            this.dgvBooks = new DataGridView();
            this.dgvBooks.Location = new System.Drawing.Point(12, 80);
            this.dgvBooks.Size = new System.Drawing.Size(760, 450);
            this.dgvBooks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBooks.AllowUserToAddRows = false;
            this.dgvBooks.AllowUserToDeleteRows = false;
            this.dgvBooks.ReadOnly = true;
            this.dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.Controls.Add(this.dgvBooks);

            // Load initial data
            LoadBooks();
        }

        private void ApplyTheme()
        {
            ThemeManager.ApplyTheme(this, "Library Management System - Dashboard");
            this.WindowState = FormWindowState.Maximized; 
            
            // Basic Form Event to ensure load
            this.Load += DashboardForm_Load;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void LoadBooks(string searchTerm = "")
        {
            DataManager.LoadData(); // Ensure latest data
            var books = DataManager.Books;

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                var filteredBooks = new System.Collections.Generic.List<Book>();
                foreach (var book in books)
                {
                    if (book.Title.ToLower().Contains(searchTerm) || 
                        book.Author.ToLower().Contains(searchTerm))
                    {
                        filteredBooks.Add(book);
                    }
                }
                dgvBooks.DataSource = null;
                dgvBooks.DataSource = filteredBooks;
                lblTotalBooks.Text = $"Total Books: {filteredBooks.Count}";
            }
            else
            {
                dgvBooks.DataSource = null;
                dgvBooks.DataSource = books;
                lblTotalBooks.Text = $"Total Books: {books.Count}";
            }

            // Customize columns if needed (optional, auto-generate usually works fine for simple POCOs)
            if (dgvBooks.Columns["PurchaseDate"] != null)
                dgvBooks.Columns["PurchaseDate"].DefaultCellStyle.Format = "d";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadBooks(txtSearch.Text);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void AddNewStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent addStudent = new AddStudent();
            addStudent.ShowDialog();
        }

        private void ViewStudentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStudents viewStudents = new ViewStudents();
            viewStudents.ShowDialog();
        }

        private void ViewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Since Dashboard *is* the view books, maybe just reset search?
            txtSearch.Clear();
            LoadBooks();
        }

        private void IssueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueBook issueBook = new IssueBook();
            issueBook.ShowDialog();
            LoadBooks(); // Refresh in case quantities changed
        }

        private void ReturnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnBook returnBook = new ReturnBook();
            returnBook.ShowDialog();
            LoadBooks(); // Refresh in case quantities changed
        }

        private void addNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewBook newBook = new AddNewBook();
            newBook.ShowDialog(); 
            // Refresh logic after adding content
            LoadBooks(txtSearch.Text);
        }
    }
}
