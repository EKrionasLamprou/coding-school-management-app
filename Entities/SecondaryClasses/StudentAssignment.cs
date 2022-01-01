using System;

namespace SCS.Entities
{
    /// <summary>
    /// Represents a course assignment to be assigned to a student.
    /// </summary>
    public class StudentAssignment
    {
        /// <summary>
        /// The assignment of a student from a course.
        /// </summary>
        public CourseAssignment Assignment { get; set; }
        public Course Course { get; set; }
        /// <summary>
        /// The oral mark of the student.
        /// </summary>
        public byte? OralMark { get; set; }
        /// <summary>
        /// The total mark of the student.
        /// </summary>
        public byte? TotalMark { get; set; }
        

        public StudentAssignment(string title, string description, DateTime submitDate, Course course,
            byte? oralMark = null, byte? totalMark = null)
            : this(new CourseAssignment(new Assignment(title, description), submitDate, course), course, oralMark, totalMark) { }
        public StudentAssignment(Assignment assignment, DateTime submitDate, Course course,
            byte? oralMark = null, byte? totalMark = null)
            : this(new CourseAssignment(assignment, submitDate, course), course, oralMark, totalMark) { }
        public StudentAssignment(CourseAssignment assignment, Course course,
            byte? oralMark = null, byte? totalMark = null)
        {
            Assignment = assignment;
            Course = course;
            OralMark = oralMark;
            TotalMark = totalMark;
        }

        /// <summary>
        /// Returns the title and stream of the course as string.
        /// </summary>
        public override string ToString() => Assignment.ToString();

        // OPERATOR OVERLOADS
        public static bool operator ==(StudentAssignment a1, Assignment a2) => a1.Assignment == a2;
        public static bool operator !=(StudentAssignment a1, Assignment a2) => a1.Assignment != a2;
        public static bool operator ==(StudentAssignment a1, CourseAssignment a2) => a1.Assignment == a2 && a1.Course == a2.Course;
        public static bool operator !=(StudentAssignment a1, CourseAssignment a2) => a1.Assignment != a2 && a1.Course == a2.Course;
    }
}
