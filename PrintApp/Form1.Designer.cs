namespace PrintApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnGenerate = new Button();
            groupBox1 = new GroupBox();
            pictureBox1 = new PictureBox();
            groupBox2 = new GroupBox();
            rbParent = new RadioButton();
            rbStudent = new RadioButton();
            lblExcelPath = new Label();
            lblSelectImages = new Label();
            lblStatus = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(158, 18);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(140, 23);
            btnGenerate.TabIndex = 1;
            btnGenerate.Text = "GENERATE";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 56);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(800, 335);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(3, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(794, 313);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblStatus);
            groupBox2.Controls.Add(rbParent);
            groupBox2.Controls.Add(rbStudent);
            groupBox2.Controls.Add(lblExcelPath);
            groupBox2.Controls.Add(lblSelectImages);
            groupBox2.Controls.Add(btnGenerate);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(800, 56);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            // 
            // rbParent
            // 
            rbParent.AutoSize = true;
            rbParent.Location = new Point(84, 22);
            rbParent.Name = "rbParent";
            rbParent.Size = new Size(59, 19);
            rbParent.TabIndex = 4;
            rbParent.Text = "Parent";
            rbParent.UseVisualStyleBackColor = true;
            // 
            // rbStudent
            // 
            rbStudent.AutoSize = true;
            rbStudent.Checked = true;
            rbStudent.Location = new Point(12, 22);
            rbStudent.Name = "rbStudent";
            rbStudent.Size = new Size(66, 19);
            rbStudent.TabIndex = 3;
            rbStudent.TabStop = true;
            rbStudent.Text = "Student";
            rbStudent.UseVisualStyleBackColor = true;
            // 
            // lblExcelPath
            // 
            lblExcelPath.Location = new Point(408, 55);
            lblExcelPath.Name = "lblExcelPath";
            lblExcelPath.Size = new Size(0, 15);
            lblExcelPath.TabIndex = 2;
            // 
            // lblSelectImages
            // 
            lblSelectImages.AutoSize = true;
            lblSelectImages.Location = new Point(158, 84);
            lblSelectImages.Name = "lblSelectImages";
            lblSelectImages.Size = new Size(0, 15);
            lblSelectImages.TabIndex = 2;
            // 
            // lblStatus
            // 
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Location = new Point(304, 19);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(231, 23);
            lblStatus.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 391);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KING'S SCHOOL";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnGenerate;
        private GroupBox groupBox1;
        private PictureBox pictureBox1;
        private GroupBox groupBox2;
        private Label lblSelectImages;
        private Label lblExcelPath;
        private RadioButton rbParent;
        private RadioButton rbStudent;
        private Label lblStatus;
    }
}
