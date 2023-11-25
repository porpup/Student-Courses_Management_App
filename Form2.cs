using System;
using System.Data;
using System.Windows.Forms;

namespace Project {
    public partial class Form2 : Form {

        string StId = String.Empty;
        string CId = String.Empty;
        public event EventHandler<string> RowSelectedEvent;

        public Form2() {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e) {
            comboBoxStudentID.DataSource = DataAccess.Students.GetStudents();
            comboBoxStudentID.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStudentID.DisplayMember = "StId";
            comboBoxStudentID.ValueMember = "StId";
            comboBoxStudentID.SelectedIndex = -1;

            comboBoxCourseID.DataSource = DataAccess.Courses.GetCourses();
            comboBoxCourseID.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCourseID.DisplayMember = "CId";
            comboBoxCourseID.ValueMember = "CId";
            comboBoxCourseID.SelectedIndex = -1;

            if (StId != String.Empty) {
                comboBoxStudentID.SelectedValue = StId;
                comboBoxCourseID.SelectedValue = CId;
            }
        }

        public void setModificationMenu(bool value, string StId, string CId) {
            comboBoxStudentID.Enabled = value;
            this.StId = StId;
            this.CId = CId;
        }

        public void setButton1Text(string str) {
            button1.Text = str;
        }

        private void comboBoxStudentID_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox comboBoxStudentID = (ComboBox)sender;
            textBoxStudentName.Text = comboBoxStudentID.SelectedItem != null ? ((DataRowView)comboBoxStudentID.SelectedItem)["StName"].ToString() : String.Empty;
        }

        private void comboBoxCourseID_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox comboBoxCourseID = (ComboBox)sender;
            textBoxCourseName.Text = comboBoxCourseID.SelectedItem != null ? ((DataRowView)comboBoxCourseID.SelectedItem)["CName"].ToString() : String.Empty;
        }

        private void button1_Click(object sender, EventArgs e) {
            var studentId = comboBoxStudentID.SelectedValue;
            var CIcourseId = comboBoxCourseID.SelectedValue;

            if (button1.Text == "Add") {
                try {
                    BusinessLayer.Enrollments.Insert((string)studentId, (string)CIcourseId);
                    MessageBox.Show("Enrollment added successfully");
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }

            }

            if (button1.Text == "Modify") {
                try {
                    BusinessLayer.Enrollments.ModifyEnrollments((string)studentId, this.CId, (string)CIcourseId);
                    MessageBox.Show("Enrollment modified successfully");
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
}
