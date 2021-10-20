using Domain;
using FacultyApp.Controller;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyApp.View
{
    public class ExamRegistrationMenu
    {
        public ExamRegistrationController ExamRegistrationController { get; set; }
        public StudentController StudentController { get; set; }
        public ProfessorController ProfessorController { get; set; }
        public SubjectController SubjectController { get; set; }

        public ExamRegistrationMenu(ExamRegistrationController examRegistrationController, StudentController studentController,
            ProfessorController professorController, SubjectController subjectController)
        {
            ExamRegistrationController = examRegistrationController;
            StudentController = studentController;
            ProfessorController = professorController;
            SubjectController = subjectController;
        }

        public void ShowMenu()
        {

            int ans;
            do
            {
                Console.WriteLine("0. Exit exam registrations");
                Console.WriteLine("1. Create exam registration");
                Console.WriteLine("2. Read exam registration");
                Console.WriteLine("3. Update exam registration");
                Console.WriteLine("4. Delete exam registration");
                Console.WriteLine("5. Read all exam registrations");

                bool ind = Int32.TryParse(Console.ReadLine(), out ans);
                Console.WriteLine();
                if (ind)
                {
                    switch (ans)
                    {
                        case 0:
                            break;
                        case 1:
                            CreateExamRegistration();
                            break;
                        case 2:
                            ReadExamRegistration();
                            break;
                        case 3:
                            UpdateExamRegistration();
                            break;
                        case 4:
                            DeleteExamRegistration();
                            break;
                        case 5:
                            ReadAllExamRegistrations();
                            break;
                        default:
                            Console.WriteLine("Bad request");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid request!");
                    ans = -1;
                }
            } while (ans != 0);

        }

        private void UpdateExamRegistration()
        {
            Console.WriteLine("Enter index: ");
            string index = Console.ReadLine();

            Console.WriteLine("Enter subject name: ");
            string subjectName = Console.ReadLine();

            var subject = SubjectController.FindSubject(subjectName);

            if (subject == null)
            {
                Console.WriteLine("Invalid subject");
                return;
            }

            Console.WriteLine("Enter date (1/1/2021) : ");
            DateTime date;
            bool ind = DateTime.TryParse(Console.ReadLine(), out date);

            if (!ind)
            {
                Console.WriteLine("Invalid date input.");
                return;
            }

            Console.WriteLine("Enter grade: ");
            int grade;
            ind = Int32.TryParse(Console.ReadLine(), out grade);
            if (!ind)
            {
                Console.WriteLine("Invalid grade input.");
                return;
            }

            Console.WriteLine("Enter professor's jmbg: ");
            string profJmbg = Console.ReadLine();

            var prof = ProfessorController.FindProfessor(profJmbg);

            if (prof == null)
            {
                Console.WriteLine("Invalid professor input");
                return;
            }

            Console.WriteLine();

            try
            {
                ExamRegistrationController.UpdateExamRegistration(index, subject.Id, date, grade, prof.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void DeleteExamRegistration()
        {
            Console.WriteLine("Enter index: ");
            string index = Console.ReadLine();
            Console.WriteLine("Enter subject name: ");
            string subjectName = Console.ReadLine();
            Console.WriteLine("Enter date (1/1/2021) : ");
            DateTime date;
            bool ind = DateTime.TryParse(Console.ReadLine(), out date);
            if (!ind)
            {
                Console.WriteLine("Invalid date input.");
                return;
            }
            Console.WriteLine();

            var subject = SubjectController.FindSubject(subjectName);
            if (subject == null) Console.WriteLine("Invalid subject");

            try
            {
                ExamRegistrationController.DeleteExamRegistration(index, subject.Id, date);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ReadExamRegistration()
        {
            Console.WriteLine("Enter index: ");
            string index = Console.ReadLine();

            Console.WriteLine("Enter subject name: ");
            string subjectName = Console.ReadLine();

            Console.WriteLine("Enter date (1/1/2021) : ");
            DateTime date;
            bool ind = DateTime.TryParse(Console.ReadLine(), out date);
            if (!ind)
            {
                Console.WriteLine("Invalid date input.");
                return;
            }

            Console.WriteLine();

            var subject = SubjectController.FindSubject(subjectName);
            if (subject == null) Console.WriteLine("Invalid subject");

            ExamRegistration examRegistration = ExamRegistrationController.FindExamRegistration(index, subject.Id, date);

            if (examRegistration != null) 
                Console.WriteLine(examRegistration.ToString());
            else 
                Console.WriteLine("Exam registration not found!");

            Console.WriteLine();
        }

        private void ReadAllExamRegistrations()
        {
            var ers = ExamRegistrationController.GetAllExamRegistrations();

            if (ers.Count == 0)
            {
                Console.WriteLine("0 exam registrations.");
                Console.WriteLine();
                return;
            }

            foreach (ExamRegistration er in ers)
            {
                Console.WriteLine(er);
            }

            Console.WriteLine();
        }

        private void CreateExamRegistration()
        {

            Console.WriteLine("Enter index: ");
            string index = Console.ReadLine();

            var student = StudentController.FindStudent(index);
            if (student == null)
            {
                Console.WriteLine("Invalid index input");
                return;
            }

            Console.WriteLine("Enter subject name: ");
            string subjectName = Console.ReadLine();

            var subject = SubjectController.FindSubject(subjectName);
            if (subject == null)
            {
                Console.WriteLine("Invalid subject input");
                return;
            }

            Console.WriteLine("Enter date (1/1/2021) : ");
            DateTime date;
            bool ind = DateTime.TryParse(Console.ReadLine(), out date);
            if (!ind)
            {
                Console.WriteLine("Invalid date input.");
                return;
            }

           /* Console.WriteLine("Enter grade: ");
            int grade;
            ind = Int32.TryParse(Console.ReadLine(), out grade);
            if (!ind)
            {
                Console.WriteLine("Invalid grade input.");
                return;
            }
            Console.WriteLine("Enter professor first name: ");
            string profFirstName = Console.ReadLine();
            Console.WriteLine("Enter professor last name: ");
            string profLastName = Console.ReadLine();*/

            try
            {
                ExamRegistrationController.AddExamRegistration(student.Indeks, subject.Id, date);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
