using System.Collections.Generic;
using SCS.Entities;
using SCS.Controllers;
using static SCS.Controllers.Collections;

namespace SCS
{
    /// <summary>
    /// Loads synthetic data.
    /// </summary>
    class SyntheticData
    {
        public void Load()
        {
            CourseController courseCtrl = List.course;
            StudentController studentCtrl = List.student;
            TrainerController trainerCtrl = List.trainer;
            AssignmentController assignmentCtrl = List.assignment;

            #region Courses
            Course c1 = new Course("GDScript", 16, false, "14-02-2022", "14-08-2022");
            Course c2 = new Course("C++", 16, true, "15-02-2022", "15-05-2022");
            Course c3 = new Course("C#", 16, true, "15-02-2022", "15-05-2022");
            Course c4 = new Course("C#", 16, false, "15-02-2022", "15-08-2022");
            Course c5 = new Course("Java", 16, true, "16-02-2022", "16-05-2022");
            Course c6 = new Course("Python", 16, false, "16-02-2022", "16-08-2022");
            Course c7 = new Course("JavaScript", 16, false, "17-02-2022", "17-08-2022");
            Course c8 = new Course("C++", 17, true, "15-05-2022", "15-08-2022");
            Course c9 = new Course("C#", 17, true, "15-05-2022", "15-08-2022");
            Course c10 = new Course("Java", 17, true, "16-05-2022", "16-08-2022");
            Course c11 = new Course("Python", 17, false, "16-05-2022", "16-11-2022");
            Course c12 = new Course("JavaScript", 17, false, "17-05-2022", "17-11-2022");
            Course c13 = new Course("JavaScript", 17, true, "17-05-2022", "17-08-2022");

            courseCtrl.Add(new Course[] { c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13 });
            #endregion

            #region Students
            Student s1 = new Student("Takis", "Mpekas", "04/05/1952", 2500);
            Student s2 = new Student("Dimitrios", "Dimitriou", "01/02/2003", 2250);
            Student s3 = new Student("Alexandra", "Gouvala", "02/12/1992", 2500);
            Student s4 = new Student("Spuros", "Dimas", "02/02/1980", 2500);
            Student s5 = new Student("Anastasia", "Ioannou", "15/04/1999", 2250);
            Student s6 = new Student("Ilias", "Mpekris", "22/08/1995", 0);
            Student s7 = new Student("Andreas", "Rokos", "18/09/1991", 2500);
            Student s8 = new Student("Iosif", "Kateplagos", "11/04/1994", 2250);
            Student s9 = new Student("Evridiki", "Jajic", "12/01/1995", 2500);
            Student s10 = new Student("Velissarios", "Romas", "06/05/1998", 2250);
            Student s11 = new Student("Nikolaos", "Giannelis", "09/05/1994", 2500);
            Student s12 = new Student("Anna", "Psomadeli", "10/05/1998", 2250);
            Student s13 = new Student("Theofanis", "Psomadelis", "10/05/1998", 2250);
            Student s14 = new Student("Spuros", "Koutras", "15/02/1992", 2500);
            Student s15 = new Student("Georgios", "Nikolaou", "30/05/1990", 2500);
            Student s16 = new Student("Aleka", "Maniati", "24/11/1989", 2250);
            Student s17 = new Student("Ahmed", "Ramadan", "21/12/1994", 2500);
            Student s18 = new Student("Exarhos", "Chrisalis", "21/12/1994", 2250);
            Student s19 = new Student("Simeon", "Varnalou", "01/11/2000", 2250);
            Student s20 = new Student("Anna-Maria", "Pappa", "20/04/1999", 2500);
            Student s21 = new Student("Nikolaos", "Rigas", "10/08/1996", 2500);
            Student s22 = new Student("Alexios", "Dokos", "16/05/1994", 2500);
            Student s23 = new Student("Panagiotis", "Domianos", "25/01/1997", 2250);
            Student s24 = new Student("Stavros", "Diakos", "15/05/1995", 2500);
            Student s25 = new Student("Maria", "Louka", "12/11/1993", 2500);
            Student s26 = new Student("Nadia", "Mania", "08/09/1995", 2250);
            Student s27 = new Student("Evanthia", "Kritikou", "08/09/1989", 2500);
            Student s28 = new Student("Filippos", "Filippou", "12/04/1993", 2500);
            Student s29 = new Student("Alexandros", "Madelis", "18/05/1992", 2500);
            Student s30 = new Student("Theano", "Skotia", "10/09/1994", 2250);
            Student s31 = new Student("Konstantinos", "Passas", "30/03/1988", 2500);
            Student s32 = new Student("Anastasios", "Liras", "10/12/1990", 2500);
            Student s33 = new Student("Mihail", "Karatekas", "15/06/1992", 2250);
            Student s34 = new Student("Georgios", "Tsopanis", "10/09/1993", 2250);
            Student s35 = new Student("Nikolaos", "Valsamos", "12/01/1990", 2250);
            Student s36 = new Student("Athanasia", "Xatzidaki", "10/04/1994", 2250);
            Student s37 = new Student("Konstantina", "Tsirlioti", "14/07/1990", 2250);
            Student s38 = new Student("Sara", "Alekou", "04/11/1987", 2250);
            Student s39 = new Student("Marios", "Sampas", "12/06/1975", 2250);
            Student s40 = new Student("Foteini", "Ipsilou", "26/06/1989", 2250);
            Student s41 = new Student("Vasilios", "Gennaios", "22/04/1999", 2250);
            Student s42 = new Student("Thanassios", "Irakliotis", "29/04/1993", 2250);
            Student s43 = new Student("Georgia", "Rokka", "03/12/2001", 2250);
            Student s44 = new Student("Stefania", "Kosta", "25/01/1999", 2250);
            Student s45 = new Student("Christos", "Souliotis", "11/05/1992", 2250);
            Student s46 = new Student("Manos", "Papathanasis", "18/02/1990", 2250);
            
            studentCtrl.Add(new Student[]
                {
                    s1, s2, s3, s4, s5, s6, s7, s8, s9, s10,
                    s11, s12, s13, s14, s15, s16, s17, s18, s19, s20,
                    s21, s22, s23, s24, s25, s26, s27, s28, s29, s30,
                    s31, s32, s33, s34, s35, s36, s37, s38, s39, s40,
                    s41, s42, s43, s44, s45, s46,
                });
            #endregion

            #region Trainers
            Trainer t1 = new Trainer("Juan", "Garcia", "Game Development");
            Trainer t2 = new Trainer("Mario", "Ricci", "C");
            Trainer t3 = new Trainer("Mpampis", "Fanellos", "C++, C#");
            Trainer t4 = new Trainer("Ioanna", "Porfurou", "Python, Machine Learning");
            Trainer t5 = new Trainer("Maria", "Pitta", "Java");
            Trainer t6 = new Trainer("Stelios", "Vikos", "Javascript, HTML/CSS");

            trainerCtrl.Add(new Trainer[] { t1, t2, t3, t4, t5, t6 });
            #endregion

            #region Assignments
            Assignment a1 = new Assignment("Calucator", "Make a simple calculator that can add, subtract, multiply and divide.");
            Assignment a2 = new Assignment("Flight tickets", "Make an application/website, simulating airplane tickets purchase.");
            Assignment a3 = new Assignment("School management program", "Make an application/website, for managing school data.");
            Assignment a4 = new Assignment("Database", "Design an ERD and make a program that sends SQL queries to a database.");
            Assignment a5 = new Assignment("API", "Make an application/website that reads data from an API");
            Assignment a6 = new Assignment("Ordering Pizza", "Make an application/website where the user chooses the ingredients and orders a pizza.");
            Assignment a7 = new Assignment("Programmers' Tinder", "Make an application/website that matches programmers, based on their interests.");
            Assignment a8 = new Assignment("2D game", "Make a small 2D game.");
            Assignment a9 = new Assignment("3D game", "Make a small 3D game.");

            assignmentCtrl.Add(new Assignment[] { a1, a2, a3, a4, a5, a6, a7, a8, a9 });
            #endregion

            #region Students to Courses
            courseCtrl.AddStudents(c1, new List<Student> { s1, s2, s3, s4 });
            courseCtrl.AddStudents(c2, new List<Student> { s5, s6, s7, s8, s9, s10, s11 });
            courseCtrl.AddStudents(c3, new List<Student> { s1, s12, s13, s14, s15, s16 });
            courseCtrl.AddStudents(c4, new List<Student> { s17, s18, s19, s20, s21, s22 });
            courseCtrl.AddStudents(c5, new List<Student> { s20, s23, s24, s25, s26, s27 });
            courseCtrl.AddStudents(c6, new List<Student> { s28, s29, s30, s31, s32 });
            courseCtrl.AddStudents(c7, new List<Student> { s33, s34, s35 });
            courseCtrl.AddStudents(c8, new List<Student> { s36, s37 });
            courseCtrl.AddStudents(c9, new List<Student> { s38, s39 });
            courseCtrl.AddStudents(c10, new List<Student> { s40, s41 });
            courseCtrl.AddStudents(c11, new List<Student> { s40, s42, s43 });
            courseCtrl.AddStudents(c12, new List<Student> { s44, s45, s46 });
            #endregion

            #region Trainers to Courses
            courseCtrl.AddTrainer(c1, t1);
            courseCtrl.AddTrainers(c2, new List<Trainer> { t2, t3 });
            courseCtrl.AddTrainer(c3, t3);
            courseCtrl.AddTrainer(c4, t3);
            courseCtrl.AddTrainer(c5, t5);
            courseCtrl.AddTrainer(c6, t4);
            courseCtrl.AddTrainer(c7, t6);
            courseCtrl.AddTrainer(c8, t2);
            courseCtrl.AddTrainer(c9, t3);
            courseCtrl.AddTrainer(c10, t5);
            courseCtrl.AddTrainer(c11, t4);
            courseCtrl.AddTrainer(c12, t6);
            courseCtrl.AddTrainer(c13, t6);
            #endregion

            #region Assignments to Courses
            courseCtrl.AddAssignments(c1, new List<CourseAssignment>
            {
                new CourseAssignment(a8, "14-02-2022", c1),
                new CourseAssignment(a9, "14-04-2022", c1),
            });
            courseCtrl.AddAssignments(c2, new List<CourseAssignment>
            {
                new CourseAssignment(a1, "28-02-2022", c2),
                new CourseAssignment(a2, "10-03-2022", c2),
                new CourseAssignment(a3, "15-03-2022", c2),
                new CourseAssignment(a4, "30-03-2022", c2),
                new CourseAssignment(a5, "15-04-2022", c2),
                new CourseAssignment(a6, "30-04-2022", c2),
                new CourseAssignment(a7, "15-05-2022", c2),
            });
            courseCtrl.AddAssignments(c3, new List<CourseAssignment>
            {
                new CourseAssignment(a1, "28-02-2022", c3),
                new CourseAssignment(a2, "10-03-2022", c3),
                new CourseAssignment(a3, "15-03-2022", c3),
                new CourseAssignment(a4, "30-03-2022", c3),
                new CourseAssignment(a5, "15-04-2022", c3),
                new CourseAssignment(a6, "30-04-2022", c3),
                new CourseAssignment(a7, "15-05-2022", c3),
            });
            courseCtrl.AddAssignments(c4, new List<CourseAssignment>
            {
                new CourseAssignment(a1, "05-03-2022", c4),
                new CourseAssignment(a2, "15-03-2022", c4),
                new CourseAssignment(a3, "15-04-2022", c4),
                new CourseAssignment(a4, "15-05-2022", c4),
                new CourseAssignment(a5, "15-06-2022", c4),
                new CourseAssignment(a6, "15-07-2022", c4),
                new CourseAssignment(a7, "15-08-2022", c4),
            });
            courseCtrl.AddAssignments(c5, new List<CourseAssignment>
            {
                new CourseAssignment(a1, "28-02-2022", c5),
                new CourseAssignment(a2, "10-03-2022", c5),
                new CourseAssignment(a3, "15-03-2022", c5),
                new CourseAssignment(a4, "30-03-2022", c5),
                new CourseAssignment(a5, "15-04-2022", c5),
                new CourseAssignment(a6, "30-04-2022", c5),
                new CourseAssignment(a7, "16-05-2022", c5),
            });
            courseCtrl.AddAssignments(c6, new List<CourseAssignment>
            {
                new CourseAssignment(a1, "05-03-2022", c6),
                new CourseAssignment(a2, "16-03-2022", c6),
                new CourseAssignment(a3, "16-04-2022", c6),
                new CourseAssignment(a4, "16-05-2022", c6),
                new CourseAssignment(a5, "16-06-2022", c6),
                new CourseAssignment(a6, "16-07-2022", c6),
                new CourseAssignment(a7, "16-08-2022", c6),
            });
            courseCtrl.AddAssignments(c7, new List<CourseAssignment>
            {
                new CourseAssignment(a1, "05-03-2022", c7),
                new CourseAssignment(a2, "17-03-2022", c7),
                new CourseAssignment(a3, "17-04-2022", c7),
                new CourseAssignment(a4, "17-05-2022", c7),
                new CourseAssignment(a5, "17-06-2022", c7),
                new CourseAssignment(a6, "17-07-2022", c7),
                new CourseAssignment(a7, "17-08-2022", c7),
            });
            courseCtrl.AddAssignments(c8, new List<CourseAssignment>
            {
                new CourseAssignment(a1, "30-05-2022", c8),
                new CourseAssignment(a2, "10-06-2022", c8),
                new CourseAssignment(a3, "15-06-2022", c8),
                new CourseAssignment(a4, "30-06-2022", c8),
                new CourseAssignment(a5, "15-07-2022", c8),
                new CourseAssignment(a6, "30-07-2022", c8),
                new CourseAssignment(a7, "15-08-2022", c8),
            });
            courseCtrl.AddAssignments(c9, new List<CourseAssignment>
            {
                new CourseAssignment(a1, "30-05-2022", c9),
                new CourseAssignment(a2, "10-06-2022", c9),
                new CourseAssignment(a3, "15-06-2022", c9),
                new CourseAssignment(a4, "30-06-2022", c9),
                new CourseAssignment(a5, "15-07-2022", c9),
                new CourseAssignment(a6, "30-07-2022", c9),
                new CourseAssignment(a7, "15-08-2022", c9),
            });
            courseCtrl.AddAssignments(c10, new List<CourseAssignment>
            {
                new CourseAssignment(a1, "30-05-2022", c10),
                new CourseAssignment(a2, "10-06-2022", c10),
                new CourseAssignment(a3, "15-06-2022", c10),
                new CourseAssignment(a4, "30-06-2022", c10),
                new CourseAssignment(a5, "15-07-2022", c10),
                new CourseAssignment(a6, "30-07-2022", c10),
                new CourseAssignment(a7, "16-08-2022", c10),
            });
            courseCtrl.AddAssignments(c11, new List<CourseAssignment>
            {
                new CourseAssignment(a1, "03-06-2022", c11),
                new CourseAssignment(a2, "16-06-2022", c11),
                new CourseAssignment(a3, "16-07-2022", c11),
                new CourseAssignment(a4, "16-08-2022", c11),
                new CourseAssignment(a5, "16-09-2022", c11),
                new CourseAssignment(a6, "16-10-2022", c11),
                new CourseAssignment(a7, "16-11-2022", c11),
            });
            courseCtrl.AddAssignments(c12, new List<CourseAssignment>
            {
                new CourseAssignment(a1, "03-06-2022", c12),
                new CourseAssignment(a2, "17-06-2022", c12),
                new CourseAssignment(a3, "17-07-2022", c12),
                new CourseAssignment(a4, "17-08-2022", c12),
                new CourseAssignment(a5, "17-09-2022", c12),
                new CourseAssignment(a6, "17-10-2022", c12),
                new CourseAssignment(a7, "17-11-2022", c12),
            });
            #endregion

            #region Student Marks
            s1.Assignments[0].OralMark = 99; s1.Assignments[0].TotalMark = 97;
            s2.Assignments[0].OralMark = 89; s2.Assignments[0].TotalMark = 80;
            s3.Assignments[0].OralMark = 94; s3.Assignments[0].TotalMark = 94;
            s4.Assignments[0].OralMark = 89; s4.Assignments[0].TotalMark = 87;

            s5.Assignments[0].OralMark = 89; s5.Assignments[0].TotalMark = 75;
            s5.Assignments[1].OralMark = 87; s5.Assignments[1].TotalMark = 76;
            s5.Assignments[2].OralMark = 70; s5.Assignments[2].TotalMark = 67;
            s5.Assignments[3].OralMark = 85; s5.Assignments[3].TotalMark = 76;
            s5.Assignments[4].OralMark = 98; s5.Assignments[4].TotalMark = 86;
            s6.Assignments[0].OralMark = 88; s6.Assignments[0].TotalMark = 87;
            s6.Assignments[1].OralMark = 87; s6.Assignments[1].TotalMark = 76;
            s6.Assignments[2].OralMark = 76; s6.Assignments[2].TotalMark = 87;
            s6.Assignments[3].OralMark = 78; s6.Assignments[3].TotalMark = 85;
            s6.Assignments[4].OralMark = 97; s6.Assignments[4].TotalMark = 76;
            s7.Assignments[0].OralMark = 98; s7.Assignments[0].TotalMark = 85;
            s7.Assignments[1].OralMark = 89; s7.Assignments[1].TotalMark = 86;
            s7.Assignments[2].OralMark = 76; s7.Assignments[2].TotalMark = 87;
            s7.Assignments[3].OralMark = 97; s7.Assignments[3].TotalMark = 99;
            s7.Assignments[4].OralMark = 87; s7.Assignments[4].TotalMark = 98;
            s8.Assignments[0].OralMark = 97; s8.Assignments[0].TotalMark = 98;
            s8.Assignments[1].OralMark = 99; s8.Assignments[1].TotalMark = 97;
            s8.Assignments[2].OralMark = 88; s8.Assignments[2].TotalMark = 78;
            s8.Assignments[3].OralMark = 97; s8.Assignments[3].TotalMark = 97;
            s8.Assignments[4].OralMark = 98; s8.Assignments[4].TotalMark = 87;
            s9.Assignments[0].OralMark = 78; s9.Assignments[0].TotalMark = 67;
            s9.Assignments[1].OralMark = 87; s9.Assignments[1].TotalMark = 67;
            s9.Assignments[2].OralMark = 67; s9.Assignments[2].TotalMark = 76;
            s9.Assignments[3].OralMark = 97; s9.Assignments[3].TotalMark = 89;
            s9.Assignments[4].OralMark = 86; s9.Assignments[4].TotalMark = 78;
            s10.Assignments[0].OralMark = 76; s10.Assignments[0].TotalMark = 78;
            s10.Assignments[1].OralMark = 86; s10.Assignments[1].TotalMark = 76;
            s10.Assignments[2].OralMark = 87; s10.Assignments[2].TotalMark = 87;
            s10.Assignments[3].OralMark = 65; s10.Assignments[3].TotalMark = 86;
            s10.Assignments[4].OralMark = 87; s10.Assignments[4].TotalMark = 68;
            s11.Assignments[0].OralMark = 53; s11.Assignments[0].TotalMark = 87;
            s11.Assignments[1].OralMark = 76; s11.Assignments[1].TotalMark = 86;
            s11.Assignments[2].OralMark = 87; s11.Assignments[2].TotalMark = 87;
            s11.Assignments[3].OralMark = 98; s11.Assignments[3].TotalMark = 87;
            s11.Assignments[4].OralMark = 79; s11.Assignments[4].TotalMark = 67;

            s1.Assignments[2].OralMark = 98; s1.Assignments[2].TotalMark = 99;
            s1.Assignments[3].OralMark = 97; s1.Assignments[3].TotalMark = 98;
            s1.Assignments[4].OralMark = 96; s1.Assignments[4].TotalMark = 95;
            s12.Assignments[0].OralMark = 89; s12.Assignments[0].TotalMark = 99;
            s12.Assignments[1].OralMark = 98; s12.Assignments[1].TotalMark = 68;
            s12.Assignments[2].OralMark = 97; s12.Assignments[2].TotalMark = 58;
            s13.Assignments[0].OralMark = 98; s13.Assignments[0].TotalMark = 89;
            s13.Assignments[1].OralMark = 78; s13.Assignments[1].TotalMark = 87;
            s13.Assignments[2].OralMark = 98; s13.Assignments[2].TotalMark = 97;
            s14.Assignments[0].OralMark = 97; s14.Assignments[0].TotalMark = 99;
            s14.Assignments[1].OralMark = 98; s14.Assignments[1].TotalMark = 98;
            s14.Assignments[2].OralMark = 100; s14.Assignments[2].TotalMark = 100;
            s15.Assignments[0].OralMark = 98; s15.Assignments[0].TotalMark = 97;
            s15.Assignments[1].OralMark = 97; s15.Assignments[1].TotalMark = 98;
            s15.Assignments[2].OralMark = 96; s15.Assignments[2].TotalMark = 97;
            s16.Assignments[0].OralMark = 95; s16.Assignments[0].TotalMark = 96;
            s16.Assignments[1].OralMark = 75; s16.Assignments[1].TotalMark = 60;
            s16.Assignments[2].OralMark = 87; s16.Assignments[2].TotalMark = 87;

            s17.Assignments[0].OralMark = 89; s17.Assignments[0].TotalMark = 92;
            s18.Assignments[0].OralMark = 97; s18.Assignments[0].TotalMark = 99;
            s19.Assignments[0].OralMark = 96; s19.Assignments[0].TotalMark = 95;
            s20.Assignments[0].OralMark = 95; s20.Assignments[0].TotalMark = 93;
            s21.Assignments[0].OralMark = 49; s21.Assignments[0].TotalMark = 46;
            s22.Assignments[0].OralMark = 96; s22.Assignments[0].TotalMark = 90;

            s20.Assignments[7].OralMark = 98; s20.Assignments[7].TotalMark = 97;
            s20.Assignments[8].OralMark = 89; s20.Assignments[8].TotalMark = 93;
            s20.Assignments[9].OralMark = 96; s20.Assignments[9].TotalMark = 93;
            s23.Assignments[0].OralMark = 98; s23.Assignments[0].TotalMark = 78;
            s23.Assignments[1].OralMark = 96; s23.Assignments[1].TotalMark = 86;
            s23.Assignments[2].OralMark = 98; s23.Assignments[2].TotalMark = 93;
            s24.Assignments[0].OralMark = 68; s24.Assignments[0].TotalMark = 67;
            s24.Assignments[1].OralMark = 67; s24.Assignments[1].TotalMark = 65;
            s24.Assignments[2].OralMark = 87; s24.Assignments[2].TotalMark = 78;
            s25.Assignments[0].OralMark = 87; s25.Assignments[0].TotalMark = 87;
            s25.Assignments[1].OralMark = 87; s25.Assignments[1].TotalMark = 88;
            s25.Assignments[2].OralMark = 95; s25.Assignments[2].TotalMark = 89;
            s26.Assignments[0].OralMark = 97; s26.Assignments[0].TotalMark = 68;
            s26.Assignments[1].OralMark = 79; s26.Assignments[1].TotalMark = 58;
            s26.Assignments[2].OralMark = 57; s26.Assignments[2].TotalMark = 78;
            s27.Assignments[0].OralMark = 100; s27.Assignments[0].TotalMark = 100;
            s27.Assignments[1].OralMark = 100; s27.Assignments[1].TotalMark = 99;
            s27.Assignments[2].OralMark = 99; s27.Assignments[2].TotalMark = 98;

            s28.Assignments[0].OralMark = 86; s28.Assignments[0].TotalMark = 89;
            s29.Assignments[0].OralMark = 87; s29.Assignments[0].TotalMark = 87;
            s30.Assignments[0].OralMark = 97; s30.Assignments[0].TotalMark = 99;
            s31.Assignments[0].OralMark = 98; s31.Assignments[0].TotalMark = 98;
            s32.Assignments[0].OralMark = 97; s32.Assignments[0].TotalMark = 97;

            s33.Assignments[0].OralMark = 100; s33.Assignments[0].TotalMark = 100;
            s34.Assignments[0].OralMark = 98; s34.Assignments[0].TotalMark = 89;
            s35.Assignments[0].OralMark = 48; s35.Assignments[0].TotalMark = 37;
            #endregion
        }
    }
}
