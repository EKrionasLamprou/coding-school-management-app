using System.Collections.Generic;
using Pages.Tables;
using SCS.Entities;
using static SCS.Constants;

namespace SCS.Controllers
{
    /// <summary>
    /// Contains methods that handle operations for assignments per course.
    /// </summary>
    class AssignmentsPerCourse : RelationshipController<Course>
    {
        public AssignmentsPerCourse()
        {
            table = new Table(new Dictionary<string, int>
            {
                { "Course", 30 },
                { "Type", 15 },
                { "Assignments", 45 },
                { "Submition Date", 25 },
            });
            collection = Collections.courses;
        }

        protected override void FillSubrows(Course entity)
        {
            int length = entity.Assignments.Count;
            string[][] assignments = new string[length][];
            for (int i = 1, j = 0; i < length; i++, j++)
            {
                CourseAssignment assignment = entity.Assignments[i];
                assignments[j] = new string[]
                { "", "", assignment.ToString(), assignment.SubmitDate.ToString(DATE_FORMAT) };
            }
            table.AddSubrows(assignments);
        }

        protected override void GetMainRow(Course entity)
        {
            if (entity.Assignments.Count > 0)
            {
                table.AddRow(new string[]
                {
                    entity.ToString(), entity.Type,
                    entity.Assignments[0].ToString(), entity.Assignments[0].SubmitDate.ToString(DATE_FORMAT)
                });
            }
            else
            {
                table.AddRow(new string[] { entity.ToString(), entity.Type, "", "" });
            }
        }
    }
}
