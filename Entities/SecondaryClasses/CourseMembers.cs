using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace SCS.Entities
{
    /// <summary>
    /// Represents the members of a course, containing lists for students, trainers and assignments and automatically updates them on list changes.
    /// </summary>
    class CourseMembers
    {
        /// <summary>
        /// The course that the members belong to.
        /// </summary>
        public Course parent;

        /// <summary>
        /// A list of the course's students.
        /// </summary>
        public ObservableCollection<Student> students = new ObservableCollection<Student>();
        /// <summary>
        /// A list of the course's trainers.
        /// </summary>
        public List<Trainer> trainers = new List<Trainer>();
        /// <summary>
        /// A list of the course's assignments.
        /// </summary>
        public ObservableCollection<CourseAssignment> assignments = new ObservableCollection<CourseAssignment>();

        public CourseMembers()
        {
            students.CollectionChanged += OnStudentChange;
            assignments.CollectionChanged += OnAssignmentChange;
        }

        // Updates the assignments, when there's a change in the student list.
        private void OnStudentChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            Student student;
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    student = students.Last();
                    AddStudentAssignments(student);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    student = (Student)e.OldItems[0];
                    RemoveStudentAssignments(student);
                    break;
            }
        }

        // Updates the students, when there's a change in the assignment list.
        private void OnAssignmentChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            CourseAssignment assignment;
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    assignment = assignments.Last();
                    AddStudentAssignment(assignment);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    assignment = (CourseAssignment)e.OldItems[0];
                    RemoveStudentAssignment(assignment);
                    break;
            }
        }

        private void AddStudentAssignments(Student student)
        {
            foreach (var assignment in assignments)
            {
                student.Assignments.Add(new StudentAssignment(assignment, parent));
            }
        }

        private void RemoveStudentAssignments(Student student)
        {
            for (int i = 0; i < student.Assignments.Count; i++)
            {
                var assignment = student.Assignments[i];
                if (assignment.Course == parent) student.Assignments.Remove(assignment);
            }
        }
        private void RemoveStudentAssignments(List<Student> students) =>
            students.ForEach(x => RemoveStudentAssignments(x));

        private void AddStudentAssignment(CourseAssignment assignment)
        {
            foreach (var student in students)
            {
                student.Assignments.Add(new StudentAssignment(assignment, parent));
            }
        }

        private void RemoveStudentAssignment(CourseAssignment assignment)
        {
            foreach (var student in students)
            {
                for (int i = 0; i < student.Assignments.Count; i++)
                {
                    var studentAssignment = student.Assignments[i];
                    if (studentAssignment == assignment)
                        student.Assignments.Remove(studentAssignment);
                }
            }
        }
    }
}
