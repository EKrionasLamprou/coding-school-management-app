using System.Collections.Generic;
using Pages.Tables;
using SCS.Entities;

namespace SCS.Controllers
{
    /// <summary>
    /// Contains methods that handle operations for trainers per course.
    /// </summary>
    class TrainersPerCourse : RelationshipController<Course>
    {
        public TrainersPerCourse()
        {
            table = new Table(new Dictionary<string, int>
            {
                { "Course", 30 },
                { "Type", 15 },
                { "Trainers", 45 },
            });
            collection = Collections.courses;
        }

        protected override void FillSubrows(Course entity)
        {
            int length = entity.Trainers.Count;
            string[][] trainers = new string[length][];
            for (int i = 1, j = 0; i < length; i++, j++)
            {
                Trainer trainer = entity.Trainers[i];
                trainers[j] = new string[] { "", "", trainer.ToString() };
            }
            table.AddSubrows(trainers);
        }

        protected override void GetMainRow(Course entity)
        {
            if (entity.Trainers.Count > 0)
            {
                table.AddRow(new string[] { entity.ToString(), entity.Type, entity.Trainers[0].ToString() });
            }
            else
            {
                table.AddRow(new string[] { entity.ToString(), entity.Type, "" });
            }
        }
    }
}
