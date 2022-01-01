using System;
using System.Collections.Generic;
using Input.Fields;
using Pages;
using Pages.Tables;
using SCS.Entities;

namespace SCS.Controllers
{
    class StudentController : Controller<Student>
    {
        public override List<Student> Collection { get; } = Collections.students;

        public StudentController()
        {
            table = new Table(
                new Dictionary<string, int>
                {
                    { "First Name", 20 },
                    { "Last Name", 20 },
                    { "Birthdate", 15 },
                    { "Tuition Fees", 13 },
                });
        }

        /// <summary>
        /// Converts the values of a student to strings and returns them as an array.
        /// </summary>
        /// <param name="entity">The student to convert the values from.</param>
        protected override string[] GetValuesAsStrings(Student entity) => new string[]
        {
            entity.FirstName,
            entity.LastName,
            entity.Birthdate.ToString(Constants.DATE_FORMAT),
            entity.TuitionFees.ToString()
        };

        /// <summary>
        /// Returns a student object constructed by converting the items of a string array to the corresponding values.
        /// </summary>
        public override Student ToObject(string[] parameters)
        {
            string firstName = parameters[0];
            string lastName = parameters[1];
            string birthDate = parameters[2];
            int tuitionFees = Convert.ToInt32(parameters[3]);
            
            return new Student(firstName, lastName, birthDate, tuitionFees);
        }

        /// <summary>
        /// Returns the input fields that match the values of the Student type.
        /// </summary>
        public override Field[] GetInputFields()
        {
            DateTime today = DateTime.Today;
            DateTime minBDay = today.AddYears(-100);
            DateTime maxBDay = today.AddYears(-18);

            return new Field[]
            {
                new Name("Enter first name", 2, 30),
                new Name("Enter last name", 2, 30),
                new Date("Enter date of birth", minBDay, maxBDay, "DD/MM/YYYY"),
                new FloatNum("Enter tuition fees", 0f, 10_000f),
            };
        }
    }
}
