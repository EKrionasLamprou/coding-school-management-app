using System.Collections.Generic;
using Input.Fields;
using Pages.Tables;
using SCS.Entities;

namespace SCS.Controllers
{
    class TrainerController : Controller<Trainer>
    {
        public override List<Trainer> Collection { get; } = Collections.trainers;

        public TrainerController()
        {
            table = new Table(
               new Dictionary<string, int>
               {
                   { "First Name", 20 },
                   { "Last Name", 20 },
                   { "Subject", 25 },
               });
        }

        /// <summary>
        /// Converts the values of a trainer to strings and returns them as an array.
        /// </summary>
        /// <param name="entity">The trainer to convert the values from.</param>
        protected override string[] GetValuesAsStrings(Trainer entity) => new string[]
        {
            entity.FirstName,
            entity.LastName,
            entity.Subject,
        };

        /// <summary>
        /// Returns a trainer object constructed by converting the items of a string array to the corresponding values.
        /// </summary>
        public override Trainer ToObject(string[] parameters)
        {
            string firstName = parameters[0];
            string lastName = parameters[1];
            string subject = parameters[2];

            return new Trainer(firstName, lastName, subject);
        }

        /// <summary>
        /// Returns the input fields that match the values of the Trainer type.
        /// </summary>
        public override Field[] GetInputFields()
        {
            return new Field[]
            {
                new Name("Enter first name", 1, 30),
                new Name("Enter last name", 1, 30),
                new Text("Enter subject", 1, 30),
            };
        }
    }
}
