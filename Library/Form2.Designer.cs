namespace Library
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.BooksSection = new System.Windows.Forms.ToolStripMenuItem();
            this.EntryNewBook = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveBook = new System.Windows.Forms.ToolStripMenuItem();
            this.PurchaseRequest = new System.Windows.Forms.ToolStripMenuItem();
            this.TransactionSection = new System.Windows.Forms.ToolStripMenuItem();
            this.IssueBook = new System.Windows.Forms.ToolStripMenuItem();
            this.RenewBook = new System.Windows.Forms.ToolStripMenuItem();
            this.ReturnBook = new System.Windows.Forms.ToolStripMenuItem();
            this.RecordSection = new System.Windows.Forms.ToolStripMenuItem();
            this.StudentRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.BookRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.BookStats = new System.Windows.Forms.ToolStripMenuItem();
            this.TotalBooks = new System.Windows.Forms.ToolStripMenuItem();
            this.AllocatedBooks = new System.Windows.Forms.ToolStripMenuItem();
            this.RemainingBooks = new System.Windows.Forms.ToolStripMenuItem();
            this.CommonOperations = new System.Windows.Forms.ToolStripMenuItem();
            this.Reports = new System.Windows.Forms.ToolStripMenuItem();
            this.PromoteStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.SendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateStudentRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateBookRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(718, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 29);
            this.label1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(825, 416);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "User";
            // 
            // Menu
            // 
            this.Menu.Dock = System.Windows.Forms.DockStyle.None;
            this.Menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BooksSection,
            this.TransactionSection,
            this.RecordSection,
            this.BookStats,
            this.CommonOperations});
            this.Menu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.Menu.Location = new System.Drawing.Point(4, 3);
            this.Menu.Name = "Menu";
            this.Menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.Menu.Size = new System.Drawing.Size(664, 27);
            this.Menu.Stretch = false;
            this.Menu.TabIndex = 8;
            this.Menu.Text = "menuStrip1";
            // 
            // BooksSection
            // 
            this.BooksSection.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BooksSection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EntryNewBook,
            this.RemoveBook,
            this.PurchaseRequest});
            this.BooksSection.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BooksSection.ForeColor = System.Drawing.Color.Maroon;
            this.BooksSection.Name = "BooksSection";
            this.BooksSection.Size = new System.Drawing.Size(117, 23);
            this.BooksSection.Text = "Books Section";
            // 
            // EntryNewBook
            // 
            this.EntryNewBook.Name = "EntryNewBook";
            this.EntryNewBook.Size = new System.Drawing.Size(199, 24);
            this.EntryNewBook.Text = "Entry New Book";
            this.EntryNewBook.Click += new System.EventHandler(this.EntryNewBook_Click);
            // 
            // RemoveBook
            // 
            this.RemoveBook.Name = "RemoveBook";
            this.RemoveBook.Size = new System.Drawing.Size(199, 24);
            this.RemoveBook.Text = "Remove Book";
            this.RemoveBook.Click += new System.EventHandler(this.RemoveBook_Click);
            // 
            // PurchaseRequest
            // 
            this.PurchaseRequest.Name = "PurchaseRequest";
            this.PurchaseRequest.Size = new System.Drawing.Size(199, 24);
            this.PurchaseRequest.Text = "Purchase Request";
            this.PurchaseRequest.Click += new System.EventHandler(this.PurchaseRequest_Click);
            // 
            // TransactionSection
            // 
            this.TransactionSection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IssueBook,
            this.RenewBook,
            this.ReturnBook});
            this.TransactionSection.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransactionSection.ForeColor = System.Drawing.Color.Maroon;
            this.TransactionSection.Name = "TransactionSection";
            this.TransactionSection.Size = new System.Drawing.Size(152, 23);
            this.TransactionSection.Text = "Transaction Section";
            // 
            // IssueBook
            // 
            this.IssueBook.Name = "IssueBook";
            this.IssueBook.Size = new System.Drawing.Size(180, 24);
            this.IssueBook.Text = "Issue Book";
            this.IssueBook.Click += new System.EventHandler(this.IssueBook_Click);
            // 
            // RenewBook
            // 
            this.RenewBook.Name = "RenewBook";
            this.RenewBook.Size = new System.Drawing.Size(180, 24);
            this.RenewBook.Text = "Return Book";
            this.RenewBook.Click += new System.EventHandler(this.RenewBook_Click);
            // 
            // ReturnBook
            // 
            this.ReturnBook.Name = "ReturnBook";
            this.ReturnBook.Size = new System.Drawing.Size(180, 24);
            this.ReturnBook.Text = "Renew Book";
            this.ReturnBook.Click += new System.EventHandler(this.ReturnBook_Click);
            // 
            // RecordSection
            // 
            this.RecordSection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StudentRecord,
            this.BookRecord});
            this.RecordSection.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecordSection.ForeColor = System.Drawing.Color.Maroon;
            this.RecordSection.Name = "RecordSection";
            this.RecordSection.Size = new System.Drawing.Size(123, 23);
            this.RecordSection.Text = "Record Section";
            // 
            // StudentRecord
            // 
            this.StudentRecord.Name = "StudentRecord";
            this.StudentRecord.Size = new System.Drawing.Size(182, 24);
            this.StudentRecord.Text = "Student Record";
            this.StudentRecord.Click += new System.EventHandler(this.StudentRecord_Click);
            // 
            // BookRecord
            // 
            this.BookRecord.Name = "BookRecord";
            this.BookRecord.Size = new System.Drawing.Size(182, 24);
            this.BookRecord.Text = "Book Record";
            this.BookRecord.Click += new System.EventHandler(this.BookRecord_Click);
            // 
            // BookStats
            // 
            this.BookStats.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TotalBooks,
            this.AllocatedBooks,
            this.RemainingBooks});
            this.BookStats.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BookStats.ForeColor = System.Drawing.Color.Maroon;
            this.BookStats.Name = "BookStats";
            this.BookStats.Size = new System.Drawing.Size(102, 23);
            this.BookStats.Text = "Books Stats";
            // 
            // TotalBooks
            // 
            this.TotalBooks.Name = "TotalBooks";
            this.TotalBooks.Size = new System.Drawing.Size(197, 24);
            this.TotalBooks.Text = "Total Books";
            this.TotalBooks.Click += new System.EventHandler(this.TotalBooks_Click);
            // 
            // AllocatedBooks
            // 
            this.AllocatedBooks.Name = "AllocatedBooks";
            this.AllocatedBooks.Size = new System.Drawing.Size(197, 24);
            this.AllocatedBooks.Text = "Allocated Books";
            this.AllocatedBooks.Click += new System.EventHandler(this.AllocatedBooks_Click);
            // 
            // RemainingBooks
            // 
            this.RemainingBooks.Name = "RemainingBooks";
            this.RemainingBooks.Size = new System.Drawing.Size(197, 24);
            this.RemainingBooks.Text = "Remaining Books";
            this.RemainingBooks.Click += new System.EventHandler(this.RemainingBooks_Click);
            // 
            // CommonOperations
            // 
            this.CommonOperations.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Reports,
            this.PromoteStudent,
            this.SendEmail,
            this.uploadDataToolStripMenuItem,
            this.updateStudentRecordToolStripMenuItem,
            this.updateBookRecordToolStripMenuItem});
            this.CommonOperations.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommonOperations.ForeColor = System.Drawing.Color.Maroon;
            this.CommonOperations.Name = "CommonOperations";
            this.CommonOperations.Size = new System.Drawing.Size(158, 23);
            this.CommonOperations.Text = "Common Operations";
            // 
            // Reports
            // 
            this.Reports.Name = "Reports";
            this.Reports.Size = new System.Drawing.Size(234, 24);
            this.Reports.Text = "Reports";
            this.Reports.Click += new System.EventHandler(this.Reports_Click);
            // 
            // PromoteStudent
            // 
            this.PromoteStudent.Name = "PromoteStudent";
            this.PromoteStudent.Size = new System.Drawing.Size(234, 24);
            this.PromoteStudent.Text = "Promote Student";
            this.PromoteStudent.Click += new System.EventHandler(this.PromoteStudent_Click);
            // 
            // SendEmail
            // 
            this.SendEmail.Name = "SendEmail";
            this.SendEmail.Size = new System.Drawing.Size(234, 24);
            this.SendEmail.Text = "Send Email";
            this.SendEmail.Click += new System.EventHandler(this.SendEmail_Click);
            // 
            // uploadDataToolStripMenuItem
            // 
            this.uploadDataToolStripMenuItem.Name = "uploadDataToolStripMenuItem";
            this.uploadDataToolStripMenuItem.Size = new System.Drawing.Size(234, 24);
            this.uploadDataToolStripMenuItem.Text = "Upload Data";
            this.uploadDataToolStripMenuItem.Click += new System.EventHandler(this.uploadDataToolStripMenuItem_Click);
            // 
            // updateStudentRecordToolStripMenuItem
            // 
            this.updateStudentRecordToolStripMenuItem.Name = "updateStudentRecordToolStripMenuItem";
            this.updateStudentRecordToolStripMenuItem.Size = new System.Drawing.Size(234, 24);
            this.updateStudentRecordToolStripMenuItem.Text = "Update Student Record";
            this.updateStudentRecordToolStripMenuItem.Click += new System.EventHandler(this.updateStudentRecordToolStripMenuItem_Click);
            // 
            // updateBookRecordToolStripMenuItem
            // 
            this.updateBookRecordToolStripMenuItem.Name = "updateBookRecordToolStripMenuItem";
            this.updateBookRecordToolStripMenuItem.Size = new System.Drawing.Size(234, 24);
            this.updateBookRecordToolStripMenuItem.Text = "Update Book Record";
            this.updateBookRecordToolStripMenuItem.Click += new System.EventHandler(this.updateBookRecordToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::Library.Properties.Resources.lmslogo1;
            this.pictureBox1.Location = new System.Drawing.Point(841, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(302, 187);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.ForeColor = System.Drawing.Color.Maroon;
            this.panel1.Location = new System.Drawing.Point(275, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 187);
            this.panel1.TabIndex = 10;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(2, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(553, 130);
            this.label4.TabIndex = 1;
            this.label4.Text = " Center Of Computer Education Institute Of Professional Studies UoA";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label4.UseCompatibleTextRendering = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(37, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(479, 42);
            this.label3.TabIndex = 0;
            this.label3.Text = "Library Management System";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Menu);
            this.panel2.Location = new System.Drawing.Point(12, 191);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(706, 33);
            this.panel2.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Location = new System.Drawing.Point(578, 227);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(567, 428);
            this.panel3.TabIndex = 13;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Maroon;
            this.button1.Location = new System.Drawing.Point(232, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 42);
            this.button1.TabIndex = 13;
            this.button1.Text = "Notify";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(198, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 44);
            this.label6.TabIndex = 12;
            this.label6.Text = "To Do List";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(551, 324);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.comboBox3);
            this.panel4.Controls.Add(this.comboBox1);
            this.panel4.Controls.Add(this.comboBox2);
            this.panel4.Controls.Add(this.label7);
            this.panel4.ForeColor = System.Drawing.Color.Maroon;
            this.panel4.Location = new System.Drawing.Point(12, 231);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(560, 259);
            this.panel4.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(215, 197);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 42);
            this.button2.TabIndex = 20;
            this.button2.Text = "Issue";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(123, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 18);
            this.label10.TabIndex = 19;
            this.label10.Text = "Id";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(123, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 18);
            this.label9.TabIndex = 18;
            this.label9.Text = "Book";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(123, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 18);
            this.label8.TabIndex = 17;
            this.label8.Text = "Name";
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox3.ForeColor = System.Drawing.Color.Maroon;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(262, 135);
            this.comboBox3.MaxDropDownItems = 6;
            this.comboBox3.MaxLength = 6;
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 16;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.ForeColor = System.Drawing.Color.Maroon;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(262, 96);
            this.comboBox1.MaxDropDownItems = 6;
            this.comboBox1.MaxLength = 6;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.ForeColor = System.Drawing.Color.Maroon;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(262, 58);
            this.comboBox2.MaxDropDownItems = 6;
            this.comboBox2.MaxLength = 6;
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 14;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(181, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(202, 44);
            this.label7.TabIndex = 13;
            this.label7.Text = "Quick Issue";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.button3);
            this.panel5.Controls.Add(this.dataGridView2);
            this.panel5.Location = new System.Drawing.Point(12, 491);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(560, 164);
            this.panel5.TabIndex = 15;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Maroon;
            this.button3.Location = new System.Drawing.Point(243, 115);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 42);
            this.button3.TabIndex = 21;
            this.button3.Text = "Return";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(66, 8);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(420, 101);
            this.dataGridView2.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::Library.Properties.Resources.user_shape;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(719, 191);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(39, 33);
            this.button4.TabIndex = 17;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.Controls.Add(this.button6);
            this.panel6.Controls.Add(this.button5);
            this.panel6.Location = new System.Drawing.Point(758, 191);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(109, 33);
            this.panel6.TabIndex = 18;
            this.panel6.Visible = false;
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::Library.Properties.Resources.sign_out_option;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Location = new System.Drawing.Point(69, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(41, 33);
            this.button6.TabIndex = 1;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::Library.Properties.Resources.key;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Location = new System.Drawing.Point(1, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(41, 33);
            this.button5.TabIndex = 0;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.Controls.Add(this.button7);
            this.panel7.Controls.Add(this.textBox1);
            this.panel7.Location = new System.Drawing.Point(888, 191);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(257, 31);
            this.panel7.TabIndex = 19;
            this.panel7.Visible = false;
            // 
            // button7
            // 
            this.button7.BackgroundImage = global::Library.Properties.Resources._checked;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.Location = new System.Drawing.Point(213, 0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(41, 31);
            this.button7.TabIndex = 2;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.MaxLength = 8;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(204, 26);
            this.textBox1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Library.Properties.Resources.logos;
            this.pictureBox2.Location = new System.Drawing.Point(9, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(263, 187);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1165, 675);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MainMenuStrip = this.Menu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Librarin  Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem BooksSection;
        private System.Windows.Forms.ToolStripMenuItem EntryNewBook;
        private System.Windows.Forms.ToolStripMenuItem RemoveBook;
        private System.Windows.Forms.ToolStripMenuItem PurchaseRequest;
        private System.Windows.Forms.ToolStripMenuItem TransactionSection;
        private System.Windows.Forms.ToolStripMenuItem IssueBook;
        private System.Windows.Forms.ToolStripMenuItem RenewBook;
        private System.Windows.Forms.ToolStripMenuItem ReturnBook;
        private System.Windows.Forms.ToolStripMenuItem RecordSection;
        private System.Windows.Forms.ToolStripMenuItem StudentRecord;
        private System.Windows.Forms.ToolStripMenuItem BookRecord;
        private System.Windows.Forms.ToolStripMenuItem BookStats;
        private System.Windows.Forms.ToolStripMenuItem TotalBooks;
        private System.Windows.Forms.ToolStripMenuItem AllocatedBooks;
        private System.Windows.Forms.ToolStripMenuItem RemainingBooks;
        private System.Windows.Forms.ToolStripMenuItem CommonOperations;
        private System.Windows.Forms.ToolStripMenuItem Reports;
        private System.Windows.Forms.ToolStripMenuItem PromoteStudent;
        private System.Windows.Forms.ToolStripMenuItem SendEmail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
#pragma warning disable CS0108 // 'Form2.Menu' hides inherited member 'Form.Menu'. Use the new keyword if hiding was intended.
        public System.Windows.Forms.MenuStrip Menu;
#pragma warning restore CS0108 // 'Form2.Menu' hides inherited member 'Form.Menu'. Use the new keyword if hiding was intended.
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem uploadDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateStudentRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateBookRecordToolStripMenuItem;
    }
}