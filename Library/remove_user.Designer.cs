namespace Library
{
    partial class remove_user
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
            this.head = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.remove_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // head
            // 
            this.head.BackColor = System.Drawing.Color.Transparent;
            this.head.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.head.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.head.ForeColor = System.Drawing.Color.Maroon;
            this.head.Location = new System.Drawing.Point(13, 9);
            this.head.MaximumSize = new System.Drawing.Size(268, 39);
            this.head.MinimumSize = new System.Drawing.Size(268, 39);
            this.head.Name = "head";
            this.head.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.head.Size = new System.Drawing.Size(268, 39);
            this.head.TabIndex = 4;
            this.head.Text = "Remove A User Here";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(62, 48);
            this.label1.MaximumSize = new System.Drawing.Size(182, 39);
            this.label1.MinimumSize = new System.Drawing.Size(182, 39);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(182, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select A User";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.Color.Maroon;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(67, 90);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(182, 37);
            this.comboBox1.TabIndex = 6;
            // 
            // remove_button
            // 
            this.remove_button.BackColor = System.Drawing.Color.Transparent;
            this.remove_button.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.remove_button.FlatAppearance.BorderSize = 4;
            this.remove_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.remove_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remove_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remove_button.ForeColor = System.Drawing.Color.Maroon;
            this.remove_button.Location = new System.Drawing.Point(62, 145);
            this.remove_button.MaximumSize = new System.Drawing.Size(182, 46);
            this.remove_button.MinimumSize = new System.Drawing.Size(182, 46);
            this.remove_button.Name = "remove_button";
            this.remove_button.Size = new System.Drawing.Size(182, 46);
            this.remove_button.TabIndex = 7;
            this.remove_button.Text = "Remove User";
            this.remove_button.UseVisualStyleBackColor = false;
            this.remove_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // remove_user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(301, 233);
            this.Controls.Add(this.remove_button);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.head);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Name = "remove_user";
            this.Text = "remove_user";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label head;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button remove_button;
    }
}