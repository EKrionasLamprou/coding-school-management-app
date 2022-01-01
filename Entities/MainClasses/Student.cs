using System;
using System.Collections.Generic;

namespace SCS.Entities
{
    /// <summary>
    /// Represents a school student.
    /// </summary>
    public class Student : Entity
    {
        /// <summary>
        /// The first name of the student.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The last name of the student.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// The student's date of birth.
        /// </summary>
        public DateTime Birthdate { get; set; }
        /// <summary>
        /// The student's school tuition fees.
        /// </summary>
        public float TuitionFees { get; set; }

        /// <summary>
        /// List of the student's assignments.
        /// </summary>
        public List<StudentAssignment> Assignments { get; set; } = new List<StudentAssignment>();

        public Student(string firstName, string lastName, string birthdate, float tuitionFees) :
            this(firstName, lastName, Convert.ToDateTime(birthdate), tuitionFees) { }
        public Student(string firstName, string lastName, DateTime birthdate, float tuitionFees)
        {
            FirstName = firstName; 
            LastName = lastName;
            Birthdate = birthdate;
            TuitionFees = tuitionFees;
        }

        /// <summary>
        /// Returns the fullname of the student as string.
        /// </summary>
        public override string ToString() => $"{FirstName} {LastName}";
    }
}
