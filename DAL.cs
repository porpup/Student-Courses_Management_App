using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess {
    internal class Connect {

        private static String cliComConnectionString = GetConnectString();

        internal static String ConnectionString { get => cliComConnectionString; }

        private static String GetConnectString() {
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = "(local)";
            cs.InitialCatalog = "College1en";
            cs.UserID = "sa";
            cs.Password = "sysadm";
            return cs.ConnectionString;
        }
    }


    internal class DataTables {

        private static SqlDataAdapter adapterPrograms = InitAdapterPrograms();
        private static SqlDataAdapter adapterCourses = InitAdapterCourses();
        private static SqlDataAdapter adapterStudents = InitAdapterStudents();
        private static SqlDataAdapter adapterEnrollments = InitAdapterEnrollments();

        private static DataSet ds = InitDataSet();

        private static SqlDataAdapter InitAdapterPrograms() {
            SqlDataAdapter r = new SqlDataAdapter(
                "SELECT * FROM Programs",
                Connect.ConnectionString);

            SqlCommandBuilder builder = new SqlCommandBuilder(r);
            r.UpdateCommand = builder.GetUpdateCommand();

            return r;
        }

        private static SqlDataAdapter InitAdapterCourses() {
            SqlDataAdapter r = new SqlDataAdapter(
                "SELECT * FROM Courses",
                Connect.ConnectionString);

            SqlCommandBuilder builder = new SqlCommandBuilder(r);
            r.UpdateCommand = builder.GetUpdateCommand();

            return r;
        }

        private static SqlDataAdapter InitAdapterStudents() {
            SqlDataAdapter r = new SqlDataAdapter(
                "SELECT * FROM Students",
                Connect.ConnectionString);

            SqlCommandBuilder builder = new SqlCommandBuilder(r);
            r.UpdateCommand = builder.GetUpdateCommand();

            return r;
        }

        private static SqlDataAdapter InitAdapterEnrollments() {
            SqlDataAdapter r = new SqlDataAdapter(
                "SELECT * FROM Enrollments",
                Connect.ConnectionString);

            SqlCommandBuilder builder = new SqlCommandBuilder(r);
            r.UpdateCommand = builder.GetUpdateCommand();

            return r;
        }

        private static DataSet InitDataSet() {
            DataSet ds = new DataSet();
            loadPrograms(ds);
            loadCourses(ds);
            loadStudents(ds);
            loadEnrollments(ds);

            return ds;
        }

        private static void loadPrograms(DataSet ds) {

            adapterPrograms.Fill(ds, "Programs");

            ds.Tables["Programs"].Columns["ProgId"].AllowDBNull = false;
            ds.Tables["Programs"].Columns["ProgName"].AllowDBNull = false;

            ds.Tables["Programs"].PrimaryKey = new DataColumn[1]
                    { ds.Tables["Programs"].Columns["ProgId"]};
        }

        private static void loadCourses(DataSet ds) {
            adapterCourses.Fill(ds, "Courses");

            ds.Tables["Courses"].Columns["CId"].AllowDBNull = false;
            ds.Tables["Courses"].Columns["CName"].AllowDBNull = false;
            ds.Tables["Courses"].Columns["ProgId"].AllowDBNull = false;

            ds.Tables["Courses"].PrimaryKey = new DataColumn[1]
                    { ds.Tables["Courses"].Columns["CId"]};

            ForeignKeyConstraint FK_Programs_Courses = new ForeignKeyConstraint("FK_Programs_Courses",
                new DataColumn[]{
                    ds.Tables["Programs"].Columns["ProgId"]
                },
                new DataColumn[] {
                    ds.Tables["Courses"].Columns["ProgId"]
                }
            );
            FK_Programs_Courses.DeleteRule = Rule.Cascade;
            FK_Programs_Courses.UpdateRule = Rule.Cascade;
            ds.Tables["Courses"].Constraints.Add(FK_Programs_Courses);
        }

        private static void loadStudents(DataSet ds) {
            adapterStudents.Fill(ds, "Students");

            ds.Tables["Students"].Columns["StId"].AllowDBNull = false;
            ds.Tables["Students"].Columns["StName"].AllowDBNull = false;
            ds.Tables["Students"].Columns["ProgId"].AllowDBNull = false;

            ds.Tables["Students"].PrimaryKey = new DataColumn[1]
                    { ds.Tables["Students"].Columns["StId"]};

            ForeignKeyConstraint FK_Programs_Students = new ForeignKeyConstraint("FK_Programs_Students",
                new DataColumn[]{
                    ds.Tables["Programs"].Columns["ProgId"]
                },
                new DataColumn[] {
                    ds.Tables["Students"].Columns["ProgId"]
                }
            );
            FK_Programs_Students.DeleteRule = Rule.None;
            FK_Programs_Students.UpdateRule = Rule.Cascade;
            ds.Tables["Students"].Constraints.Add(FK_Programs_Students);
        }

        private static void loadEnrollments(DataSet ds) {
            adapterEnrollments.Fill(ds, "Enrollments");

            ds.Tables["Enrollments"].Columns["StId"].AllowDBNull = false;
            ds.Tables["Enrollments"].Columns["CId"].AllowDBNull = false;
            ds.Tables["Enrollments"].Columns["FinalNote"].AllowDBNull = true;

            ds.Tables["Enrollments"].PrimaryKey = new DataColumn[2]
                    { ds.Tables["Enrollments"].Columns["StId"],
                    ds.Tables["Enrollments"].Columns["CId"]};

            ForeignKeyConstraint FK_Enrolments_Students = new ForeignKeyConstraint("FK_Enrolments_Students",
                new DataColumn[]{
                    ds.Tables["Students"].Columns["StId"]
                },
                new DataColumn[] {
                    ds.Tables["Enrollments"].Columns["StId"]
                }
            );
            FK_Enrolments_Students.DeleteRule = Rule.Cascade;
            FK_Enrolments_Students.UpdateRule = Rule.Cascade;
            ds.Tables["Enrollments"].Constraints.Add(FK_Enrolments_Students);

            ForeignKeyConstraint FK_Enrolments_Courses = new ForeignKeyConstraint("FK_Enrolments_Courses",
                new DataColumn[]{
                    ds.Tables["Courses"].Columns["CId"]
                },
                new DataColumn[] {
                    ds.Tables["Enrollments"].Columns["CId"]
                }
            );
            FK_Enrolments_Courses.DeleteRule = Rule.None;
            FK_Enrolments_Courses.UpdateRule = Rule.None;
            ds.Tables["Enrollments"].Constraints.Add(FK_Enrolments_Courses);
        }


        internal static SqlDataAdapter getAdapterPrograms() {
            return adapterPrograms;
        }
        internal static SqlDataAdapter getAdapterCourses() {
            return adapterCourses;
        }
        internal static SqlDataAdapter getAdapterStudents() {
            return adapterStudents;
        }
        internal static SqlDataAdapter getAdapterEnrollments() {
            return adapterEnrollments;
        }
        internal static DataSet getDataSet() {
            return ds;
        }
    }


    internal class Programs {
        private static SqlDataAdapter adapter = DataTables.getAdapterPrograms();
        private static DataSet ds = DataTables.getDataSet();

        internal static DataTable GetPrograms() {
            return ds.Tables["Programs"];
        }

        internal static int UpdatePrograms() {
            if (!ds.Tables["Programs"].HasErrors) {
                return adapter.Update(ds.Tables["Programs"]);
            } else {
                return -1;
            }
        }
    }

    internal class Courses {
        private static SqlDataAdapter adapter = DataTables.getAdapterCourses();
        private static DataSet ds = DataTables.getDataSet();

        internal static DataTable GetCourses() {
            return ds.Tables["Courses"];
        }

        internal static int UpdateCourses() {
            if (!ds.Tables["Courses"].HasErrors) {
                return adapter.Update(ds.Tables["Courses"]);
            } else {
                return -1;
            }
        }
    }

    internal class Students {
        private static SqlDataAdapter adapter = DataTables.getAdapterStudents();
        private static DataSet ds = DataTables.getDataSet();

        internal static DataTable GetStudents() {
            return ds.Tables["Students"];
        }

        internal static int UpdateStudents() {
            if (!ds.Tables["Students"].HasErrors) {
                return adapter.Update(ds.Tables["Students"]);
            } else {
                return -1;
            }
        }
    }

    internal class Enrollments {
        private static SqlDataAdapter adapter = DataTables.getAdapterEnrollments();
        private static DataSet ds = DataTables.getDataSet();

        internal static DataTable GetEnrollments() {
            var dt = new DataTable();
            dt.Columns.Add("StId", typeof(string));
            dt.Columns.Add("StName", typeof(string));
            dt.Columns.Add("CId", typeof(string));
            dt.Columns.Add("CName", typeof(string));
            dt.Columns.Add("FinalNote", typeof(int));
            dt.Columns.Add("ProgId", typeof(string));
            dt.Columns.Add("ProgName", typeof(string));


            var enrollments = (
                from a in ds.Tables["Enrollments"].AsEnumerable()
                join b in ds.Tables["Students"].AsEnumerable() on a.Field<string>("StId") equals b.Field<string>("StId")
                join c in ds.Tables["Courses"].AsEnumerable() on a.Field<string>("CId") equals c.Field<string>("CId")
                join d in ds.Tables["Programs"].AsEnumerable() on c.Field<string>("ProgId") equals d.Field<string>("ProgId")
                select new {
                    StId = a.Field<string>("StId"),
                    StName = b.Field<string>("StName"),
                    CId = a.Field<string>("CId"),
                    CName = c.Field<string>("CName"),
                    FinalNote = a.Field<int?>("FinalNote"),
                    ProgId = d.Field<string>("ProgId"),
                    ProgName = d.Field<string>("ProgName")
                }
            ).ToList();


            foreach (var enroll in enrollments) {
                var newRow = dt.NewRow();

                newRow["StId"] = enroll.StId;
                newRow["StName"] = enroll.StName;
                newRow["CId"] = enroll.CId;
                newRow["CName"] = enroll.CName;
                newRow["ProgId"] = enroll.ProgId;
                newRow["ProgName"] = enroll.ProgName;

                if (enroll.FinalNote == null) {
                    newRow["FinalNote"] = DBNull.Value;
                } else {
                    newRow["FinalNote"] = enroll.FinalNote;
                }

                dt.Rows.Add(newRow);
            }

            return dt;
        }

        internal static DataTable GetEnrollmentsFromDB() {
            return ds.Tables["Enrollments"];
        }

        internal static int InsertRow(string studentId, string courseId) {
            var row = ds.Tables["Enrollments"].NewRow();
            row["StId"] = studentId;
            row["CId"] = courseId;
            ds.Tables["Enrollments"].Rows.Add(row);
            return UpdateEnrollments();
        }

        internal static int UpdateEnrollments() {
            if (!ds.Tables["Enrollments"].HasErrors) {
                return adapter.Update(ds.Tables["Enrollments"]);
            } else {
                return -1;
            }
        }

        internal static int InsertFinalNoteInRow(string studentId, string courseId, int finalNote) {
            var row = ds.Tables["Enrollments"].Rows.Find(new object[] { studentId, courseId });
            if (row != null) {
                row["FinalNote"] = finalNote;
                return UpdateEnrollments();
            } else {
                return -1;
            }
        }

    }

}
