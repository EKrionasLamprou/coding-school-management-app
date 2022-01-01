using System;
using System.Collections.Generic;
using System.Linq;
using SCS.Entities;
using SCS.Controllers;
using Printer;
using Input;
using Input.Fields;
using static SCS.View.Menus.Navigator;
using static SCS.Controllers.Collections;
using System.Globalization;
using SCS.View.Menus;
using Pages;
using Pages.Tables;
using SCS.Initiating.Menus;

namespace SCS.Initiating
{
    /// <summary>
    /// Initiates the application menus.
    /// </summary>
    class Initiator
    {
        /// <summary>
        /// Initiates all the menus of the application.
        /// </summary>
        public void InitiateAll()
        {
            InitiateHome();
            InitiateTables();
            InitiateForms();
            InitiateMultipleCourseStudents();
            InitiateAssignmentWeek();
        }

        private void InitiateHome() => new Home().Initiate();

        private void InitiateTables()
        {
            new TableMenu(() => List.course.ShowTable(),
                MenuType.CoursesTable,
                "Courses", "course")
                .Initiate();

            new TableMenu(() => List.student.ShowTable(),
                MenuType.StudentsTable,
                "Students", "student")
                .Initiate();

            new TableMenu(() => List.trainer.ShowTable(),
                MenuType.TrainersTable,
                "Trainers", "trainer")
                .Initiate();

            new TableMenu(() => List.assignment.ShowTable(),
                MenuType.AssignmentsTable,
                "Assignments", "assignment")
                .Initiate();

            new TableMenu(() => new StudentsPerCourse().ShowTable(),
                MenuType.StudentsPerCourseTable,
                "Students per Course", "student", "course")
                .Initiate();

            new TableMenu(() => new TrainersPerCourse().ShowTable(),
                MenuType.TrainersPerCourseTable,
                "Trainers per Course", "trainer", "course")
                .Initiate();

            new TableMenu(() => new AssignmentsPerCourse().ShowTable(),
                MenuType.AssignmentsPerCourseTable,
                "Assignments per Course", "assignment", "course")
                .Initiate();

            AssignmentsPerStudentPerCourseTable();


            void AssignmentsPerStudentPerCourseTable()
            {
                string title = "Assignments per Student per Course";

                SelectList selList = new SelectList(
                    "Press enter to select an option, or escape to return.",
                    "Use the up and down arrow keys to navigate.",
                    new List<Option>
                    {
                        new Option("Edit student grades", new Action(() => GoTo(MenuType.GradesEdit))),
                    },
                    () => GoTo(MenuType.Home));

                Action show = () =>
                {
                    foreach (var course in courses)
                    {
                        Output.Print(course.ToString(), new Colours(ConsoleColor.Black, ConsoleColor.White));
                        new AssignmentsPerStudent(course).ShowTable();
                        Output.Print(lineBreaks: 2);
                    }
                    Output.Print(lineBreaks: 2);
                    selList.Render(); ;
                };

                Collection.list[MenuType.AssignmentsPerStudentPerCourseTable] = new Menu(show, title);
            }
        }

        private void InitiateForms()
        {
            new FormMenu<Course>(List.course, MenuType.CoursesTable).Initiate();
            new FormMenu<Student>(List.student, MenuType.StudentsTable).Initiate();
            new FormMenu<Trainer>(List.trainer, MenuType.TrainersTable).Initiate();
            new FormMenu<Assignment>(List.assignment, MenuType.AssignmentsTable).Initiate();

            void StudentsPerCourse()
            {
                #region Add
                Action AddShow = new Action(() =>
                {
                    var cCtrl = Controllers.List.course;
                    var sCtrl = Controllers.List.student;
                    int cId;
                    int sId;
                    Course course;
                    Student[] availableStudents;

                    cCtrl.ShowTable();
                    Output.Print(lineBreaks: 2);
                    cId = AskNumber.GetInput(0, cCtrl.Collection.Count + 1, "Type the id of the course you want to add a student (enter 0 to cancel):");
                    if (cId == 0) GoTo(MenuType.StudentsPerCourseTable);
                    course = courses[--cId];

                    Output.Print(lineBreaks: 2);

                    availableStudents = sCtrl.Collection.Except(course.Students).ToArray();
                    sCtrl.ShowTable(availableStudents);
                    Output.Print(lineBreaks: 2);
                    sId = AskNumber.GetInput(0, availableStudents.Length + 1, "Type the id of the student you want to add to the course (enter 0 to cancel):");
                    if (sId == 0) GoTo(MenuType.StudentsPerCourseTable);

                    course.Students.Add(students[--sId]);

                    GoTo(MenuType.StudentsPerCourseTable);
                });

                Collection.list[MenuType.StudentsPerCourseAdd] = new Menu(AddShow);
                #endregion
                #region Remove
                Action RemoveShow = new Action(() =>
                {
                    var cCtrl = Controllers.List.course;
                    var sCtrl = Controllers.List.student;
                    int cId;
                    int sId;
                    Course course;
                    Student student;

                    cCtrl.ShowTable();
                    Output.Print(lineBreaks: 2);
                    cId = AskNumber.GetInput(0, cCtrl.Collection.Count + 1, "Type the id of the course you want to remove a student from (enter 0 to cancel):");
                    if (cId == 0) GoTo(MenuType.StudentsPerCourseTable);
                    course = courses[--cId];

                    sCtrl.ShowTable(course.Students.ToArray());
                    Output.Print(lineBreaks: 2);
                    sId = AskNumber.GetInput(0, course.Students.Count + 1, "Type the id of the student you want to remove from the course (enter 0 to cancel):");
                    if (sId == 0) GoTo(MenuType.StudentsPerCourseTable);
                    student = course.Students[--sId];

                    course.Students.Remove(student);

                    GoTo(MenuType.StudentsPerCourseTable);
                });

                Collection.list[MenuType.StudentsPerCourseRemove] = new Menu(RemoveShow);
                #endregion
            }

            void TrainersPerCourse()
            {
                #region Add
                Action AddShow = new Action(() =>
                {
                    var cCtrl = Controllers.List.course;
                    var tCtrl = Controllers.List.trainer;
                    int cId;
                    int tId;
                    Course course;
                    Trainer[] availableTrainers;

                    cCtrl.ShowTable();
                    Output.Print(lineBreaks: 2);
                    cId = AskNumber.GetInput(0, cCtrl.Collection.Count + 1, "Type the id of the course you want to add a trainer (enter 0 to cancel):");
                    if (cId == 0) GoTo(MenuType.TrainersPerCourseTable);

                    course = courses[--cId];

                    Output.Print(lineBreaks: 2);

                    availableTrainers = tCtrl.Collection.Except(course.Trainers).ToArray();
                    tCtrl.ShowTable(availableTrainers);
                    Output.Print(lineBreaks: 2);
                    tId = AskNumber.GetInput(0, availableTrainers.Length + 1, "Type the id of the trainer you want to add to the course (enter 0 to cancel):");
                    if (tId == 0) GoTo(MenuType.TrainersPerCourseTable);
                    
                    course.Trainers.Add(trainers[--tId]);

                    GoTo(MenuType.TrainersPerCourseTable);
                });

                Collection.list[MenuType.TrainersPerCourseAdd] = new Menu(AddShow);
                #endregion
                #region Remove
                Action RemoveShow = new Action(() =>
                {
                    var cCtrl = Controllers.List.course;
                    var tCtrl = Controllers.List.trainer;
                    int cId;
                    int tId;
                    Course course;
                    Trainer trainer;

                    cCtrl.ShowTable();
                    Output.Print(lineBreaks: 2);
                    cId = AskNumber.GetInput(0, cCtrl.Collection.Count + 1, "Type the id of the course you want to remove a trainer from (enter 0 to cancel):");
                    if (cId == 0) GoTo(MenuType.TrainersPerCourseTable);
                    course = courses[--cId];

                    tCtrl.ShowTable(course.Trainers.ToArray());
                    Output.Print(lineBreaks: 2);
                    tId = AskNumber.GetInput(0, course.Trainers.Count + 1, "Type the id of the trainer you want to remove from the course (enter 0 to cancel):");
                    if (tId == 0) GoTo(MenuType.TrainersPerCourseTable);
                    trainer = course.Trainers[--tId];

                    course.Trainers.Remove(trainer);

                    GoTo(MenuType.TrainersPerCourseTable);
                });

                Collection.list[MenuType.TrainersPerCourseRemove] = new Menu(RemoveShow);
                #endregion
            }

            void AssignmentsPerCourse()
            {
                #region Add
                Action AddShow = new Action(() =>
                {
                    var cCtrl = Controllers.List.course;
                    var aCtrl = Controllers.List.assignment;
                    int cId;
                    int aId;
                    Course course;
                    Assignment[] courseAssignments;
                    Assignment[] availableAssignments;
                    string submitDate;

                    cCtrl.ShowTable();
                    Output.Print(lineBreaks: 2);
                    cId = AskNumber.GetInput(0, cCtrl.Collection.Count + 1, "Type the id of the course you want to add an assignment (enter 0 to cancel):");
                    if (cId == 0) GoTo(MenuType.AssignmentsPerCourseTable);
                    course = courses[--cId];
                    courseAssignments = course.Assignments.Select(x => x.Assignment).ToArray();

                    Output.Print(lineBreaks: 2);

                    availableAssignments = aCtrl.Collection.Where(x => !courseAssignments.Contains(x)).ToArray();
                    aCtrl.ShowTable(availableAssignments);
                    Output.Print(lineBreaks: 2);
                    aId = AskNumber.GetInput(0, availableAssignments.Length + 1, "Type the id of the assignment you want to add to the course (enter 0 to cancel):");
                    if (aId == 0) GoTo(MenuType.AssignmentsPerCourseTable);
                    submitDate = new Input.Fields.Date(
                        "Enter the submition date of the assignment",
                        course.StartDate, course.EndDate, "DD/MM/YYYY"
                        ).GetInput();

                    course.Assignments.Add(new CourseAssignment(availableAssignments[--aId], Convert.ToDateTime(submitDate), course));

                    GoTo(MenuType.AssignmentsPerCourseTable);
                });

                Collection.list[MenuType.AssignmentsPerCourseAdd] = new Menu(AddShow);
                #endregion
                #region Remove
                Action RemoveShow = new Action(() =>
                {
                    var cCtrl = Controllers.List.course;
                    var aCtrl = Controllers.List.assignment;
                    int cId;
                    int aId;
                    Course course;
                    CourseAssignment assignment;
                    Assignment[] courseAssignments;

                    cCtrl.ShowTable();
                    Output.Print(lineBreaks: 2);
                    cId = AskNumber.GetInput(0, cCtrl.Collection.Count + 1, "Type the id of the course you want to remove an assignment from (enter 0 to cancel):");
                    if (cId == 0) GoTo(MenuType.AssignmentsPerCourseTable);
                    course = courses[--cId];

                    courseAssignments = course.Assignments.Select(x => x.Assignment).ToArray();
                    aCtrl.ShowTable(courseAssignments);
                    Output.Print(lineBreaks: 2);
                    aId = AskNumber.GetInput(0, course.Assignments.Count + 1, "Type the id of the assignment you want to remove from the course (enter 0 to cancel):");
                    if (aId == 0) GoTo(MenuType.AssignmentsPerCourseTable);
                    assignment = course.Assignments[--aId];

                    course.Assignments.RemoveAt(aId);

                    GoTo(MenuType.AssignmentsPerCourseTable);
                });

                Collection.list[MenuType.AssignmentsPerCourseRemove] = new Menu(RemoveShow);
                #endregion
            }
            void Grades()
            {
                Action show = new Action(() =>
                {
                    var cCtrl = Controllers.List.course;
                    var sCtrl = Controllers.List.student;
                    var aCtrl = Controllers.List.assignment;
                    int cId;
                    int sId;
                    int aId;
                    Course course;
                    Student student;
                    Assignment[] studentAssignments;
                    StudentAssignment assignment;
                    string input;
                    int? oralMark;
                    int? totalMark;


                    cCtrl.ShowTable();
                    Output.Print(lineBreaks: 2);
                    cId = AskNumber.GetInput(0, cCtrl.Collection.Count + 1, "Type the id of the course (enter 0 to cancel):");
                    if (cId == 0) GoTo(MenuType.AssignmentsPerStudentPerCourseTable);
                    course = courses[--cId];

                    Output.Print(lineBreaks: 2);

                    sCtrl.ShowTable(course.Students.ToArray());
                    Output.Print(lineBreaks: 2);
                    sId = AskNumber.GetInput(0, cCtrl.Collection.Count + 1, "Type the id of the student (enter 0 to cancel):");
                    if (sId == 0) GoTo(MenuType.AssignmentsPerStudentPerCourseTable);
                    student = course.Students[--sId];

                    studentAssignments = student.Assignments.Select(x => x.Assignment.Assignment).ToArray();
                    aCtrl.ShowTable(studentAssignments);
                    Output.Print(lineBreaks: 2);
                    aId = AskNumber.GetInput(0, studentAssignments.Length + 1, "Type the id of the assignment (enter 0 to cancel):");
                    if (aId == 0) GoTo(MenuType.AssignmentsPerStudentPerCourseTable);
                    assignment = student.Assignments[--aId];

                    input = new Number(
                        "Enter the oral mark from 0 to 100 (leave blank if the student has no mark yet)",
                        -1, 100, true).GetInput();
                    oralMark = string.IsNullOrEmpty(input) ? null : (int?)Convert.ToInt32(input);
                    input = new Number(
                        "Enter the total mark from 0 to 100 (leave blank if the student has no mark yet)",
                        -1, 100, true).GetInput();
                    totalMark = string.IsNullOrEmpty(input) ? null : (int?)Convert.ToInt32(input);

                    assignment.OralMark = (byte?)oralMark; 
                    assignment.TotalMark = (byte?)totalMark; 

                    GoTo(MenuType.AssignmentsPerStudentPerCourseTable);
                });
                Collection.list[MenuType.GradesEdit] = new Menu(show);
            }

            StudentsPerCourse(); TrainersPerCourse(); AssignmentsPerCourse();
            Grades();
        }

        private void InitiateMultipleCourseStudents()
        {
            SelectList selectList = new SelectList("", "",
                new List<Option>() { new Option("Return", () => GoTo(MenuType.Home)) },
                () => GoTo(MenuType.Home));

            Action show = () =>
            {
                Table table = new Table(new Dictionary<string, int>
                {
                    { "Student", 30 },
                    { "Courses", 50 },
                });
                List<Student> studentsList = new List<Student>();
                List<Student> multiCourseStudents;

                foreach (var course in courses)
                {
                    studentsList.AddRange(course.Students);
                }

                multiCourseStudents = studentsList.GroupBy(x => x)
                                                  .Where(x => x.Count() > 1)
                                                  .Select(x => x.Key)
                                                  .ToList();
                foreach (var student in multiCourseStudents)
                {
                    string[] studentCourses = courses.Where(x => x.Students.Contains(student))
                                                     .Select(x => x.ToString())
                                                     .ToArray();
                    table.AddRow(new string[]
                    {
                    student.ToString(),
                    string.Join(", ", studentCourses),
                    });
                }

                if (table.Rows.Count > 0)
                {
                    table.Render();
                }
                else
                {
                    Output.Print("No students are enrolled in multiple courses.", new Colours(ConsoleColor.Gray));
                }
                selectList.Render();
            };
            Collection.list[MenuType.MultipleCourseStudents] = new Menu(show, "Students with multiple courses");
        }

        private void InitiateAssignmentWeek()
        {
            Action show = new Action(() =>
            {
                string input = new Date(
                    "Enter a date, to get all the student assignments of that week",
                    new DateTime(2000, 1, 1), new DateTime(2100, 1, 1), "DD-MM-YYYY").GetInput();
                DateTime inputDate = Convert.ToDateTime(input);
                Calendar cal = CultureInfo.InvariantCulture.Calendar;
                DateTime weekDate = inputDate.Date.AddDays(-1 * (int)cal.GetDayOfWeek(inputDate));
                var weekAssignments = new List<(Student, StudentAssignment)>();

                Table table = new Table(new Dictionary<string, int>
                {
                    { "Student", 40 },
                    { "Course", 20 },
                    { "Assignment", 30 },
                    { "Submit Date", 15 },
                });

                foreach (var student in students)
                {
                    foreach (var assignment in student.Assignments)
                    {
                        if (assignment.OralMark is null || assignment.TotalMark is null)
                        {
                            DateTime assignmentDate = assignment.Assignment.SubmitDate;
                            DateTime assignmentWeekDate = assignmentDate.Date.AddDays(-1 * (int)cal.GetDayOfWeek(assignmentDate));
                            if (assignmentWeekDate == weekDate)
                            {
                                weekAssignments.Add((student, assignment));
                            }
                        }
                    }
                }

                weekAssignments.OrderBy(x => x.Item2.Assignment.SubmitDate);

                foreach (var assignment in weekAssignments)
                {
                    table.AddRow(new string[]
                    { 
                        assignment.Item1.ToString(),
                        assignment.Item2.Course.ToString(),
                        assignment.Item2.ToString(),
                        assignment.Item2.Assignment.SubmitDate.ToString(Constants.DATE_FORMAT),
                    });
                }

                table.Render();

                Output.Print(lineBreaks: 2);

                new SelectList("Press ENTER to enter another date",
                    "Press ESCAPE to return to main menu",
                    new List<Option>() { new Option("Enter another date.", new Action(() => GoTo(MenuType.AssignmentWeek))) },
                    new Action(() => GoTo(MenuType.Home))).Render();
            });
            Collection.list[MenuType.AssignmentWeek] = new Menu(show);
        }
    }
}
