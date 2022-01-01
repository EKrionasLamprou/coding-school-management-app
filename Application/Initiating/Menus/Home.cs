using System;
using static SCS.Initiating.Compoments;
using SCS.View.Menus;
using Pages;

namespace SCS.Initiating.Menus
{
    class Home : IInitiating
    {
        public void Initiate()
        {
            Action show;
            string description = "Press enter to select an option, or escape to exit.";
            string info = "Use the up and down arrow keys to navigate.";
            SelectList list = GetSelectList(description, info, MenuType.Exit);

            AddOption(list, "Courses", MenuType.CoursesTable);
            AddOption(list, "Students", MenuType.StudentsTable);
            AddOption(list, "Trainers", MenuType.TrainersTable);
            AddOption(list, "Assignments", MenuType.AssignmentsTable);
            AddOption(list, "Students per course", MenuType.StudentsPerCourseTable);
            AddOption(list, "Trainers per course", MenuType.TrainersPerCourseTable);
            AddOption(list, "Assignments per course", MenuType.AssignmentsPerCourseTable);
            AddOption(list, "Assignments per student per course", MenuType.AssignmentsPerStudentPerCourseTable);
            AddOption(list, "Show multiple course students", MenuType.MultipleCourseStudents);
            AddOption(list, "Find assignments by week", MenuType.AssignmentWeek);

            show = () =>
            {
                list.Render();
            };

            Collection.list[MenuType.Home] = new Menu(show);
        }
    }
}
