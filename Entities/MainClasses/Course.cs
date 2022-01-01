using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SCS.Entities
{
    /// <summary>
    /// Represents a school course.
    /// </summary>
    public class Course : Entity
    {
        /// <summary>
        /// True if course's type is full-time, false if it's part-time.
        /// </summary>
        public bool isFullTime;
        private CourseMembers members = new CourseMembers();

        /// <summary>
        /// The title of the course.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The codecamp stream that the course belongs to.
        /// </summary>
        public Stream Stream { get; set; }
        /// <summary>
        /// The start date of the course.
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// The end date of the course.
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// The type of the course as string. Full-Time or Part-Time.
        /// </summary>
        public string Type { get => isFullTime ? "Full-Time" : "Part-Time"; }

        /// <summary>
        /// A list of the course's students.
        /// </summary>
        public ObservableCollection<Student> Students { get => members.students; }
        /// <summary>
        /// A list of the course's trainers.
        /// </summary>
        public List<Trainer> Trainers { get => members.trainers; }
        /// <summary>
        /// A list of the course's assignments.
        /// </summary>
        public ObservableCollection<CourseAssignment> Assignments { get => members.assignments; }

        public Course(string title, short stream, bool isFullTime, string startDate, string endDate) : this(
            title, stream, isFullTime, Convert.ToDateTime(startDate), Convert.ToDateTime(endDate)) { }
        public Course(string title, short stream, bool isFullTime, DateTime startDate, DateTime endDate)
        {
            Title = title;
            Stream = new Stream(stream);
            this.isFullTime = isFullTime;
            StartDate = startDate;
            EndDate = endDate;
            members.parent = this;
        }

        /// <summary>
        /// Returns the title and stream of the course as string.
        /// </summary>
        public override string ToString() => $"{Title} ({Stream})";
    }
}
