namespace SCS
{
    enum MenuType
    {
        Exit = -1,
        Home,

        CoursesTable,
        CoursesFormAdd, CoursesFormUpdate, CoursesFormDelete,

        StudentsTable,
        StudentsFormAdd, StudentsFormUpdate, StudentsFormDelete,

        TrainersTable,
        TrainersFormAdd, TrainersFormUpdate, TrainersFormDelete,

        AssignmentsTable,
        AssignmentsFormAdd, AssignmentsFormUpdate, AssignmentsFormDelete,

        StudentsPerCourseTable,
        StudentsPerCourseAdd, StudentsPerCourseRemove,

        TrainersPerCourseTable,
        TrainersPerCourseAdd, TrainersPerCourseRemove,

        AssignmentsPerCourseTable,
        AssignmentsPerCourseAdd, AssignmentsPerCourseRemove,

        AssignmentsPerStudentPerCourseTable,
        GradesEdit,

        MultipleCourseStudents,

        AssignmentWeek,
    }
}
