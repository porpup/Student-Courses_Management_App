using System;
using System.Windows.Forms;

namespace Project {
    public partial class Form1 : Form {

        bool isLoadedRow = false;
        public Form1() {
            InitializeComponent();
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bindingSource1.DataSource = DataAccess.Programs.GetPrograms();
            dataGridView1.DataSource = bindingSource1;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e) {
            BusinessLayer.Programs.UpdatePrograms();
        }

        private void bindingSource2_CurrentChanged(object sender, EventArgs e) {
            BusinessLayer.Courses.UpdateCourses();
        }

        private void bindingSource3_CurrentChanged(object sender, EventArgs e) {
            BusinessLayer.Students.UpdateStudents();
        }

        //private void bindingSource4_CurrentChanged(object sender, EventArgs e) {
        //    BusinessLayer.Enrollments.UpdateEnrollments();
        //}


        private void programsToolStripMenuItem_Click(object sender, EventArgs e) {
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bindingSource1.DataSource = DataAccess.Programs.GetPrograms();
            dataGridView1.DataSource = bindingSource1;
            isLoadedRow = false;
        }

        private void coursesToolStripMenuItem_Click(object sender, EventArgs e) {
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bindingSource2.DataSource = DataAccess.Courses.GetCourses();
            dataGridView1.DataSource = bindingSource2;
            isLoadedRow = false;
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e) {
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bindingSource3.DataSource = DataAccess.Students.GetStudents();
            dataGridView1.DataSource = bindingSource3;
            isLoadedRow = false;
        }

        private void enrollmentsToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!isLoadedRow) {
                isLoadedRow = true;
                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.AllowUserToDeleteRows = true;
                dataGridView1.RowHeadersVisible = true;
                dataGridView1.Dock = DockStyle.Fill;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                bindingSource4.DataSource = DataAccess.Enrollments.GetEnrollments();
                dataGridView1.DataSource = bindingSource4;
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e) {
            MessageBox.Show("Addition/Modification rejected!");
        }

        private void Form1_Load(object sender, EventArgs e) {
            dataGridView1.Dock = DockStyle.Fill;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e) {
            Form2 form2 = new Form2();
            form2.setButton1Text("Add");
            form2.ShowDialog();
        }

        private void modifyToolStripMenuItem_Click(object sender, EventArgs e) {
            if (dataGridView1.SelectedRows.Count == 0) {
                MessageBox.Show("Please select a row to Modify!");
                return;
            } else {
                Form2 form2 = new Form2();

                var selectedRow = dataGridView1.SelectedRows[0];
                string StId = selectedRow.Cells["StId"].Value.ToString();
                string CId = selectedRow.Cells["CId"].Value.ToString();

                form2.setModificationMenu(false, StId, CId);
                form2.setButton1Text("Modify");
                form2.ShowDialog();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            if (dataGridView1.SelectedRows.Count == 0) {
                MessageBox.Show("Please select a row to Delete!");
                return;
            } else {
                var selectedRow = dataGridView1.SelectedRows[0];

                try {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows) {
                        string StId = row.Cells["StId"].Value.ToString();
                        string CId = row.Cells["CId"].Value.ToString();

                        BusinessLayer.Enrollments.DeleteEnrollments(StId, CId);
                    }
                    MessageBox.Show("Delete Successful!");
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void manageFinalGradeToolStripMenuItem_Click(object sender, EventArgs e) {
            if (dataGridView1.SelectedRows.Count == 0) {
                MessageBox.Show("Please select a row to Modify!");
                return;
            } else {
                Form3 form3 = new Form3();

                var selectedRow = dataGridView1.SelectedRows[0];
                string StId = selectedRow.Cells["StId"].Value.ToString();
                string CId = selectedRow.Cells["CId"].Value.ToString();
                string FinalNote = selectedRow.Cells["FinalNote"].Value.ToString();

                form3.setFinalNoteMenu(StId, CId, FinalNote);
                form3.ShowDialog();
            }
        }

    }

}
