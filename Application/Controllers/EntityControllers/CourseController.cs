using System;
using System.Collections.Generic;
using Input.Fields;
using Pages.Tables;
using SCS.Entities;

namespace SCS.Controllers
{
    class CourseController : Controller<Course>
    {
        public override List<Course> Collection { get; } = Collections.courses;

        public CourseController()
        {
            table = new Table(
                new Dictionary<string, int>
                {
                    { "Title", 20 },
                    { "Stream", 15 },
                    { "Type", 15 },
                    { "Start Date", 15 },
                    { "End Date", 15 },
                });
        }

        /// <summary>
        /// Converts the values of a course to strings and returns them as an array.
        /// </summary>
        /// <param name="entity">The course to convert the values from.</param>
        protected override string[] GetValuesAsStrings(Course entity) => new string[]
        {
            entity.Title,
            entity.Stream.ToString(),
            entity.Type,
            entity.StartDate.ToString(Constants.DATE_FORMAT),
            entity.EndDate.ToString(Constants.DATE_FORMAT),
        };

        /// <summary>
        /// Returns a course object constructed by converting the items of a string array to the corresponding values.
        /// </summary>
        public override Course ToObject(string[] parameters)
        {
            string title = parameters[0];
            short stream = Convert.ToInt16(parameters[1]);
            bool isFullTime = parameters[2] == "Full-Time";
            
            string[] dates = parameters[3].Split(" - ");
            DateTime startDate = Convert.ToDateTime(dates[0]);
            DateTime endDate = Convert.ToDateTime(dates[1]);

            return new Course(title, stream, isFullTime, startDate, endDate);
        }

        /// <summary>
        /// Returns the input fields that match the values of the Course type.
        /// </summary>
        public override Field[] GetInputFields()
        {
            return new Field[]
            {
                new Text("Enter title", 1, 30),
                new Number("Enter stream", 1, 1000),
                new Choice("Choose type", new string[]
                    { "Part-Time", "Full-Time" }),
                new DateSpan(
                    "Enter a start date",
                    "Enter an end date",
                    "01/01/2000", "01/01/2035",
                    new TimeSpan(100, 0, 0, 0),
                    new TimeSpan(500, 0, 0, 0),
                    "DD/MM/YYYY"),
            };
        }

        public void AddStudent(Course course, Student student) => course.Students.Add(student);
        public void AddStudents(Course course, List<Student> students)
            => students.ForEach(x => AddStudent(course, x));

        public void AddTrainer(Course course, Trainer trainer) => course.Trainers.Add(trainer);
        public void AddTrainers(Course course, List<Trainer> trainers)
            => trainers.ForEach(x => AddTrainer(course, x));

        public void AddAssignment(Course course, CourseAssignment assignment) => course.Assignments.Add(assignment);
        public void AddAssignments(Course course, List<CourseAssignment> assignments)
            => assignments.ForEach(x => AddAssignment(course, x));
    }
}
