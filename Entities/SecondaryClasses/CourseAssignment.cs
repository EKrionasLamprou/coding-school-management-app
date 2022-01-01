using System;

namespace SCS.Entities
{
    /// <summary>
    /// Represents a school assignment to be assigned to a course.
    /// </summary>
    public class CourseAssignment
    {
        /// <summary>
        /// The assignment of the course.
        /// </summary>
        public Assignment Assignment { get; set; }
        /// <summary>
        /// The submition date for the assignment.
        /// </summary>
        public DateTime SubmitDate { get; set; }
        /// <summary>
        /// The course that the assignment belongs to.
        /// </summary>
        public Course Course { get; set; }


        public CourseAssignment(Assignment assignment, string submitDate, Course course)
            : this(assignment, Convert.ToDateTime(submitDate), course) { }
        public CourseAssignment(string title, string description, string submitDate, Course course)
            : this(new Assignment(title, description), Convert.ToDateTime(submitDate), course) { }
        public CourseAssignment(string title, string description, DateTime submitDate, Course course)
            : this(new Assignment(title, description), submitDate, course) { }
        public CourseAssignment(Assignment assignment, DateTime submitDate, Course course)
        {
            Assignment = assignment;
            SubmitDate = submitDate;
            Course = course;
        }

        /// <summary>
        /// Returns the title and stream of the course as string.
        /// </summary>
        public override string ToString() => Assignment.ToString();

        // OPERATOR OVERLOADS
        public static bool operator ==(CourseAssignment a1, Assignment a2) => a1.Assignment == a2;
        public static bool operator !=(CourseAssignment a1, Assignment a2) => a1.Assignment != a2;
        public static bool operator ==(CourseAssignment a1, StudentAssignment a2) => a1 == a2.Assignment && a1.Course == a2.Course;
        public static bool operator !=(CourseAssignment a1, StudentAssignment a2) => a1 != a2.Assignment && a1.Course == a2.Course;
    }
}
