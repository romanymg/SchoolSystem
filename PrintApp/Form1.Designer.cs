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
            lblStatus = new Label();
            rbParent = new RadioButton();
            rbStudent = new RadioButton();
            lblSelectImages = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            rbAll = new RadioButton();
            rbNotPrinted = new RadioButton();
            txtCode = new TextBox();
            label1 = new Label();
            panel3 = new Panel();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox2.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // btnGenerate
            // 
            btnGenerate.FlatStyle = FlatStyle.Flat;
            btnGenerate.Location = new Point(11, 116);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(457, 23);
            btnGenerate.TabIndex = 1;
            btnGenerate.Text = "GENERATE";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 177);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(480, 214);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(3, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(474, 192);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(panel3);
            groupBox2.Controls.Add(panel2);
            groupBox2.Controls.Add(panel1);
            groupBox2.Controls.Add(lblStatus);
            groupBox2.Controls.Add(btnGenerate);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(480, 177);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            // 
            // lblStatus
            // 
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Location = new Point(11, 142);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(457, 23);
            lblStatus.TabIndex = 6;
            // 
            // rbParent
            // 
            rbParent.AutoSize = true;
            rbParent.Location = new Point(75, 3);
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
            rbStudent.Location = new Point(3, 3);
            rbStudent.Name = "rbStudent";
            rbStudent.Size = new Size(66, 19);
            rbStudent.TabIndex = 3;
            rbStudent.TabStop = true;
            rbStudent.Text = "Student";
            rbStudent.UseVisualStyleBackColor = true;
            // 
            // lblSelectImages
            // 
            lblSelectImages.AutoSize = true;
            lblSelectImages.Location = new Point(136, 3);
            lblSelectImages.Name = "lblSelectImages";
            lblSelectImages.Size = new Size(0, 15);
            lblSelectImages.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(rbStudent);
            panel1.Controls.Add(rbParent);
            panel1.Location = new Point(13, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(455, 27);
            panel1.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(rbAll);
            panel2.Controls.Add(rbNotPrinted);
            panel2.Location = new Point(13, 45);
            panel2.Name = "panel2";
            panel2.Size = new Size(455, 27);
            panel2.TabIndex = 8;
            // 
            // rbAll
            // 
            rbAll.AutoSize = true;
            rbAll.Location = new Point(3, 3);
            rbAll.Name = "rbAll";
            rbAll.Size = new Size(39, 19);
            rbAll.TabIndex = 3;
            rbAll.Text = "All";
            rbAll.UseVisualStyleBackColor = true;
            // 
            // rbNotPrinted
            // 
            rbNotPrinted.AutoSize = true;
            rbNotPrinted.Checked = true;
            rbNotPrinted.Location = new Point(75, 3);
            rbNotPrinted.Name = "rbNotPrinted";
            rbNotPrinted.Size = new Size(86, 19);
            rbNotPrinted.TabIndex = 4;
            rbNotPrinted.TabStop = true;
            rbNotPrinted.Text = "Not Printed";
            rbNotPrinted.UseVisualStyleBackColor = true;
            // 
            // txtCode
            // 
            txtCode.BorderStyle = BorderStyle.FixedSingle;
            txtCode.Location = new Point(43, 3);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(409, 23);
            txtCode.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(2, 6);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 10;
            label1.Text = "Code";
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(txtCode);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(lblSelectImages);
            panel3.Location = new Point(11, 78);
            panel3.Name = "panel3";
            panel3.Size = new Size(457, 32);
            panel3.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 391);
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
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnGenerate;
        private GroupBox groupBox1;
        private PictureBox pictureBox1;
        private GroupBox groupBox2;
        private Label lblSelectImages;
        private RadioButton rbParent;
        private RadioButton rbStudent;
        private Label lblStatus;
        private Panel panel2;
        private RadioButton rbAll;
        private RadioButton rbNotPrinted;
        private Panel panel1;
        private TextBox txtCode;
        private Label label1;
        private Panel panel3;
    }
}
