namespace Library_management_system
{
    partial class AddNewBook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewBook));
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            txtPublication = new TextBox();
            txtAuthor = new TextBox();
            txtName = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            label7 = new Label();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtQuantity = new TextBox();
            label5 = new Label();
            txtPrice = new TextBox();
            label6 = new Label();
            dateTimePicker1 = new DateTimePicker();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-2, 82);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(264, 392);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 192, 128);
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtPrice);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtQuantity);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtPublication);
            panel1.Controls.Add(txtAuthor);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(261, 82);
            panel1.Name = "panel1";
            panel1.Size = new Size(545, 391);
            panel1.TabIndex = 1;
            // 
            // txtPublication
            // 
            txtPublication.Location = new Point(166, 125);
            txtPublication.Name = "txtPublication";
            txtPublication.Size = new Size(291, 31);
            txtPublication.TabIndex = 5;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(166, 71);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(291, 31);
            txtAuthor.TabIndex = 4;
            // 
            // txtName
            // 
            txtName.Location = new Point(166, 21);
            txtName.Name = "txtName";
            txtName.Size = new Size(291, 31);
            txtName.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(7, 27);
            label1.Name = "label1";
            label1.Size = new Size(111, 25);
            label1.TabIndex = 0;
            label1.Text = "Book Name";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Wheat;
            panel2.Controls.Add(label7);
            panel2.Controls.Add(pictureBox2);
            panel2.Location = new Point(-2, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(808, 76);
            panel2.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(383, 17);
            label7.Name = "label7";
            label7.Size = new Size(171, 45);
            label7.TabIndex = 9;
            label7.Text = "Add Book";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(266, -3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(111, 76);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(7, 77);
            label2.Name = "label2";
            label2.Size = new Size(139, 25);
            label2.TabIndex = 6;
            label2.Text = "Author's Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(7, 131);
            label3.Name = "label3";
            label3.Size = new Size(108, 25);
            label3.TabIndex = 7;
            label3.Text = "Publication";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(3, 182);
            label4.Name = "label4";
            label4.Size = new Size(134, 25);
            label4.TabIndex = 8;
            label4.Text = "Purchase Date";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(166, 277);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(291, 31);
            txtQuantity.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(7, 231);
            label5.Name = "label5";
            label5.Size = new Size(54, 25);
            label5.TabIndex = 10;
            label5.Text = "Price";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(166, 225);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(291, 31);
            txtPrice.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(7, 283);
            label6.Name = "label6";
            label6.Size = new Size(87, 25);
            label6.TabIndex = 12;
            label6.Text = "Quantity";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "";
            dateTimePicker1.Location = new Point(166, 177);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(291, 31);
            dateTimePicker1.TabIndex = 13;
            dateTimePicker1.TabStop = false;
            dateTimePicker1.Value = new DateTime(2025, 8, 24, 21, 7, 45, 0);
            // 
            // btnSave
            // 
            btnSave.FlatStyle = FlatStyle.Popup;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(166, 339);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 14;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(345, 339);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddNewBook
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 476);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Name = "AddNewBook";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddNewBook";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox2;
        private TextBox txtPublication;
        private TextBox txtAuthor;
        private TextBox txtName;
        private Label label1;
        private Label label7;
        private Label label3;
        private Label label2;
        private Label label6;
        private TextBox txtPrice;
        private Label label5;
        private TextBox txtQuantity;
        private Label label4;
        private DateTimePicker dateTimePicker1;
        private Button btnCancel;
        private Button btnSave;
    }
}