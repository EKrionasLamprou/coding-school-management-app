namespace SCS.Entities
{
    /// <summary>
    /// Represents a school assignment.
    /// </summary>
    public class Assignment : Entity
    {
        /// <summary>
        /// The title of the assignment.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// A short description of the assignment.
        /// </summary>
        public string Description { get; set; }

        public Assignment(string title, string description)
        {
            Title = title;
            Description = description;
        }

        /// <summary>
        /// Returns the title of the assignment as string.
        /// </summary>
        public override string ToString() => Title;

        // OPERATOR OVERLOADS
        public static bool operator ==(Assignment a1, CourseAssignment a2) => a1 == a2.Assignment;
        public static bool operator !=(Assignment a1, CourseAssignment a2) => a1 != a2.Assignment;
        public static bool operator ==(Assignment a1, StudentAssignment a2) => a1 == a2.Assignment;
        public static bool operator !=(Assignment a1, StudentAssignment a2) => a1 != a2.Assignment;
    }
}
