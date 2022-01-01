using System.Collections.Generic;
using System.Linq;
using Pages.Tables;
using SCS.Entities;
using static SCS.Constants;

namespace SCS.Controllers
{
    /// <summary>
    /// Contains methods that handle operations for assignments per student.
    /// </summary>
    class AssignmentsPerStudent : RelationshipController<Student>
    {
        Course course = null;

        public AssignmentsPerStudent(Course course = null)
        {
            table = new Table(new Dictionary<string, int>
            {
                { "Students", 20 },
                { "Assignments", 20 },
                { "Submition Dates", 16 },
                { "Oral Marks", 12 },
                { "Total Marks", 12 },
            });

            if (course is null)
            {
                collection = Collections.students;
            }
            else
            {
                collection = course.Students.ToList();
                this.course = course;
            }
        }

        protected override void FillSubrows(Student entity)
        {
            int length = entity.Assignments.Count;
            List<string[]> list = new List<string[]>();
            bool ignore = true; // ignores first entry to be put on the main row, instead of the subrow.

            for (int i = 0, j = 0; i < length; i++, j++)
            {
                StudentAssignment assignment = entity.Assignments[i];
                if (course == null || assignment.Course == course)
                {
                    if (ignore)
                    {
                        ignore = false;
                        continue;
                    }
                    string oralMark = assignment.OralMark is null ? "-" : assignment.OralMark.ToString();
                    string totalMark = assignment.TotalMark is null ? "-" : assignment.OralMark.ToString();

                    list.Add(
                    new string[]
                    {
                        "", assignment.ToString(),
                        assignment.Assignment.SubmitDate.ToString(DATE_FORMAT),
                        oralMark, totalMark,
                    });
                }
            }
            table.AddSubrows(list.ToArray());
        }

        protected override void GetMainRow(Student entity)
        {
            int firstIndex = course == null ?
                0 :
                entity.Assignments
                    .Select((value, index) => new { value, index })
                    .Where(pair => pair.value.Course == course)
                    .Select(pair => pair.index)
                    .FirstOrDefault();
            if (entity.Assignments.Count > 0 && entity.Assignments[firstIndex].Course == course)
            {

                StudentAssignment assignment = entity.Assignments[firstIndex];
                table.AddRow(new string[] { entity.ToString(), assignment.ToString(),
                        assignment.Assignment.SubmitDate.ToString(DATE_FORMAT),
                        assignment.OralMark.ToString(), assignment.TotalMark.ToString(),});
            }
            else
            {
                table.AddRow(new string[] { entity.ToString(), "", "", "", "" });
            }
        }
    }
}
