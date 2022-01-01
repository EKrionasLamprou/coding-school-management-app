using System.Collections.Generic;
using Input.Fields;
using Pages.Tables;
using SCS.Entities;

namespace SCS.Controllers
{
    class AssignmentController : Controller<Assignment>
    {
        public override List<Assignment> Collection { get; } = Collections.assignments;

        public AssignmentController()
        {
            table = new Table(
                new Dictionary<string, int>
                {
                    { "Title", 25 },
                    { "Description", 85 },
                });
        }

        /// <summary>
        /// Converts the values of a course to strings and returns them as an array.
        /// </summary>
        /// <param name="entity">The course to convert the values from.</param>
        protected override string[] GetValuesAsStrings(Assignment entity) => new string[]
        {
            entity.Title,
            entity.Description,
        };

        /// <summary>
        /// Returns an assignment object constructed by converting the items of a string array to the corresponding values.
        /// </summary>
        public override Assignment ToObject(string[] parameters)
        {
            string title = parameters[0];
            string description = parameters[1];

            return new Assignment(title, description);
        }

        /// <summary>
        /// Returns the input fields that match the values of the entity type.
        /// </summary>
        public override Field[] GetInputFields()
        {
            return new Field[]
            {
                new Text("Enter title", 1, 30),
                new Text("Enter description", 1, 250),
            };
        }
    }
}
