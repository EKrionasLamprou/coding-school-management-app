namespace SCS.Controllers
{
    /// <summary>
    /// Stores the controllers of the applocation.
    /// </summary>
    static class List
    {
        public static CourseController course = new CourseController();
        public static StudentController student = new StudentController();
        public static TrainerController trainer = new TrainerController();
        public static AssignmentController assignment = new AssignmentController();
    }
}
