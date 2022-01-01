namespace SCS.Entities
{
    /// <summary>
    /// Represents a school trainer.
    /// </summary>
    public class Trainer : Entity
    {
        /// <summary>
        /// The first name of the trainer.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The last name of the trainer.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// The trainer's field of expertise.
        /// </summary>
        public string Subject { get; set; }

        public Trainer(string firstName, string lastName, string subject)
        {
            FirstName = firstName; 
            LastName = lastName;
            Subject = subject;
        }

        /// <summary>
        /// Returns the fullname of the student as string.
        /// </summary>
        public override string ToString() => $"{FirstName} {LastName}";
    }
}
