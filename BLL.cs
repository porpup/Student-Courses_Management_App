using System;
using System.Data;
using System.Linq;

namespace BusinessLayer {
    internal class Programs {
        internal static int UpdatePrograms() {

            return DataAccess.Programs.UpdatePrograms();
        }
    }

    internal class Courses {
        internal static int UpdateCourses() {

            return DataAccess.Courses.UpdateCourses();
        }
    }

    internal class Students {
        internal static int UpdateStudents() {

            return DataAccess.Students.UpdateStudents();
        }
    }

    internal class Enrollments {
        internal static void Insert(string studentId, string courseId) {
            var rowStudent = DataAccess.Students.GetStudents().Select($"StId = '{studentId}'").First();
            var rowCourse = DataAccess.Courses.GetCourses().Select($"CId = '{courseId}'").First();

            //A student can enrol only to courses in the student's program
            if (rowStudent["ProgId"].ToString() != rowCourse["ProgId"].ToString()) {
                throw new Exception($"Student {rowStudent["StName"].ToString()} is not enrolled in {rowCourse["ProgId"].ToString()}.");
            }

            DataAccess.Enrollments.InsertRow(studentId, courseId);

        }

        internal static void ModifyEnrollments(string studentId, string oldCourseId, string newCourseId) {
            DataRow[] studentEnrollments = DataAccess.Enrollments.GetEnrollments().Select($"StId = '{studentId}'");
            var rowStudent = DataAccess.Students.GetStudents().Select($"StId = '{studentId}'").First();
            var rowCourse = DataAccess.Courses.GetCourses().Select($"CId = '{newCourseId}'").First();

            if (!studentEnrollments.Any(x => x["CId"].ToString() == newCourseId)) {
                var enrollment = DataAccess.Enrollments.GetEnrollmentsFromDB().Select($"StId = '{studentId}' and CId = '{oldCourseId}'").First();
                if (enrollment["FinalNote"] == DBNull.Value) {
                    if (rowStudent["ProgId"].ToString() != rowCourse["ProgId"].ToString()) {
                        throw new Exception($"Student {rowStudent["StName"].ToString()} is not enrolled in {rowCourse["ProgId"].ToString()}.");
                    } else {
                        enrollment["CId"] = newCourseId;
                    }

                    DataAccess.Enrollments.UpdateEnrollments();
                } else {
                    throw new Exception($"This enrollment cannot be modified because the grade has already been registered, please remove the grade first.");
                }
            } else {
                throw new Exception($"Student ID {studentId} is already enrolled in course Id  {newCourseId}.");
            }
        }

        internal static void DeleteEnrollments(string studentId, string courseId) {
            var enrollment = DataAccess.Enrollments.GetEnrollmentsFromDB().Select($"StId = '{studentId}' and CId = '{courseId}'").First();
            if (enrollment["FinalNote"] == DBNull.Value) {
                enrollment.Delete();
                DataAccess.Enrollments.UpdateEnrollments();
            } else {
                throw new Exception($"This enrollment cannot be deleted because the grade has already been registered, please remove the grade first.");
            }
        }

        internal static void InsertFinalNote(string studentId, string courseId, string finalNote) {
            var enrollment = DataAccess.Enrollments.GetEnrollmentsFromDB().Select($"StId = '{studentId}' and CId = '{courseId}'").First();

            if (string.IsNullOrWhiteSpace(finalNote)) {
                enrollment["FinalNote"] = DBNull.Value;
            } else {
                if (decimal.TryParse(finalNote, out decimal note) && note > 0 && note <= 100) {
                    enrollment["FinalNote"] = note;
                } else {
                    throw new ArgumentException("Final Note should be between 1 and 100.");
                }
            }
            DataAccess.Enrollments.UpdateEnrollments();

        }

    }

}
