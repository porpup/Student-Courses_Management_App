namespace Project {
    partial class Form3 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxStudentID = new System.Windows.Forms.ComboBox();
            this.comboBoxCourseID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxStudentName = new System.Windows.Forms.TextBox();
            this.textBoxCourseName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxFinalNote = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "Student ID";
            // 
            // comboBoxStudentID
            // 
            this.comboBoxStudentID.Enabled = false;
            this.comboBoxStudentID.FormattingEnabled = true;
            this.comboBoxStudentID.Location = new System.Drawing.Point(65, 119);
            this.comboBoxStudentID.Name = "comboBoxStudentID";
            this.comboBoxStudentID.Size = new System.Drawing.Size(244, 33);
            this.comboBoxStudentID.TabIndex = 6;
            this.comboBoxStudentID.SelectedIndexChanged += new System.EventHandler(this.comboBoxStudentID_SelectedIndexChanged);
            // 
            // comboBoxCourseID
            // 
            this.comboBoxCourseID.Enabled = false;
            this.comboBoxCourseID.FormattingEnabled = true;
            this.comboBoxCourseID.Location = new System.Drawing.Point(65, 257);
            this.comboBoxCourseID.Name = "comboBoxCourseID";
            this.comboBoxCourseID.Size = new System.Drawing.Size(244, 33);
            this.comboBoxCourseID.TabIndex = 7;
            this.comboBoxCourseID.SelectedIndexChanged += new System.EventHandler(this.comboBoxCourseID_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 33);
            this.label2.TabIndex = 8;
            this.label2.Text = "Course ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(417, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 33);
            this.label4.TabIndex = 9;
            this.label4.Text = "Student Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(417, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 33);
            this.label3.TabIndex = 10;
            this.label3.Text = "Course Name";
            // 
            // textBoxStudentName
            // 
            this.textBoxStudentName.Location = new System.Drawing.Point(423, 119);
            this.textBoxStudentName.Name = "textBoxStudentName";
            this.textBoxStudentName.ReadOnly = true;
            this.textBoxStudentName.Size = new System.Drawing.Size(379, 31);
            this.textBoxStudentName.TabIndex = 11;
            // 
            // textBoxCourseName
            // 
            this.textBoxCourseName.Location = new System.Drawing.Point(423, 257);
            this.textBoxCourseName.Name = "textBoxCourseName";
            this.textBoxCourseName.ReadOnly = true;
            this.textBoxCourseName.Size = new System.Drawing.Size(379, 31);
            this.textBoxCourseName.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(341, 519);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(221, 68);
            this.button1.TabIndex = 13;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxFinalNote
            // 
            this.textBoxFinalNote.Location = new System.Drawing.Point(385, 407);
            this.textBoxFinalNote.Name = "textBoxFinalNote";
            this.textBoxFinalNote.Size = new System.Drawing.Size(142, 31);
            this.textBoxFinalNote.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(379, 352);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 33);
            this.label5.TabIndex = 15;
            this.label5.Text = "Final Note";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 670);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxFinalNote);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxCourseName);
            this.Controls.Add(this.textBoxStudentName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxCourseID);
            this.Controls.Add(this.comboBoxStudentID);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxStudentID;
        private System.Windows.Forms.ComboBox comboBoxCourseID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxStudentName;
        private System.Windows.Forms.TextBox textBoxCourseName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxFinalNote;
        private System.Windows.Forms.Label label5;
    }
}