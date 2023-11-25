using System;
using System.Data;
using System.Windows.Forms;

namespace Project {
    public partial class Form3 : Form {

        string StId = String.Empty;
        string CId = String.Empty;
        public event EventHandler<string> RowSelectedEvent;

        public Form3() {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e) {
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

        public void setFinalNoteMenu(string StId, string CId, string FinalNote) {
            this.StId = StId;
            this.CId = CId;
            textBoxFinalNote.Text = FinalNote;
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
            var finalNote = textBoxFinalNote.Text;

            try {
                BusinessLayer.Enrollments.InsertFinalNote((string)studentId, (string)CIcourseId, finalNote);
                MessageBox.Show("Final Note added successfully");
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
