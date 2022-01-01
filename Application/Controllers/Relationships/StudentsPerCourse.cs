using System.Collections.Generic;
using Pages.Tables;
using SCS.Entities;

namespace SCS.Controllers
{
    /// <summary>
    /// Contains methods that handle operations for students per course.
    /// </summary>
    class StudentsPerCourse : RelationshipController<Course>
    {
        public StudentsPerCourse()
        {
            table = new Table(new Dictionary<string, int>
            {
                { "Course", 30 },
                { "Type", 15 },
                { "Students", 45 },
            });
            collection = Collections.courses;
        }

        protected override void FillSubrows(Course entity)
        {
            int length = entity.Students.Count;
            string[][] students = new string[length][];
            for (int i = 1, j = 0; i < length; i++, j++)
            {
                Student student = entity.Students[i];
                students[j] = new string[] { "", "", student.ToString() };
            }
            table.AddSubrows(students);
        }

        protected override void GetMainRow(Course entity)
        {
            if (entity.Students.Count > 0)
            {
                table.AddRow(new string[] { entity.ToString(), entity.Type, entity.Students[0].ToString() });
            }
            else
            {
                table.AddRow(new string[] { entity.ToString(), entity.Type, "" });
            }
        }
    }
}
