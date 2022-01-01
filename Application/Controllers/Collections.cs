using System.Collections.Generic;
using SCS.Entities;

namespace SCS.Controllers
{
    /// <summary>
    /// Holds collections for the data entities.
    /// </summary>
    static class Collections
    {
        public static List<Course> courses = new List<Course>();
        public static List<Student> students = new List<Student>();
        public static List<Trainer> trainers = new List<Trainer>();
        public static List<Assignment> assignments = new List<Assignment>();
    }
}
