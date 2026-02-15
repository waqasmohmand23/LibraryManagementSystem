using System;
using System.Drawing;
using System.Windows.Forms;

namespace Library_management_system
{
    public partial class AddNewBook : Form
    {
        public AddNewBook()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            this.Text = "Add New Book";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void AddNewBook_Load(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtAuthor.Text) ||
                string.IsNullOrWhiteSpace(txtPublication.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!long.TryParse(txtPrice.Text, out long price) || price < 0)
            {
                MessageBox.Show("Invalid Price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!long.TryParse(txtQuantity.Text, out long quantity) || quantity < 0)
            {
                MessageBox.Show("Invalid Quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Book newBook = new Book
                {
                    Title = txtName.Text.Trim(),
                    Author = txtAuthor.Text.Trim(),
                    Publication = txtPublication.Text.Trim(),
                    PurchaseDate = dateTimePicker1.Value,
                    Price = price,
                    Quantity = quantity
                };

                DataManager.Books.Add(newBook);
                DataManager.SaveBooks();

                MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Option: Clear fields or close? Usually keeping open to add more is nice, but let's clear.
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtAuthor.Clear();
            txtPublication.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }
    }
}
