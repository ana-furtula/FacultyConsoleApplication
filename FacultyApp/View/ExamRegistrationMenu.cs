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
        public static void ShowMenu(IServiceProvider serviceProvider)
        { 
            var examRegistrationController = serviceProvider.GetRequiredService<ExamRegistrationController>();
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
                            var studentController = serviceProvider.GetRequiredService<StudentController>();
                            var professorController = serviceProvider.GetRequiredService<ProfessorController>();
                            var subjectController = serviceProvider.GetRequiredService<SubjectController>();
                            CreateExamRegistration(studentController, professorController, subjectController, examRegistrationController);
                            break;
                        case 2:
                            ReadExamRegistration(examRegistrationController);
                            break;
                        case 3:
                            UpdateExamRegistration(examRegistrationController);
                            break;
                        case 4:
                            DeleteExamRegistration(examRegistrationController);
                            break;
                        case 5:
                            ReadAllExamRegistrations(examRegistrationController);
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

        private static void UpdateExamRegistration(ExamRegistrationController examRegistrationController)
        {
            Console.WriteLine("Enter index: ");
            string index = Console.ReadLine();
            Console.WriteLine("Enter subjectId: ");
            string subjectId = Console.ReadLine();
            Console.WriteLine("Enter date (1/1/2021) : ");
            DateTime date;
            bool ind = DateTime.TryParse(Console.ReadLine(), out date);
            if (!ind)
            {
                Console.WriteLine("Invalid date input.");
                return;
            }
            Console.WriteLine("Enter new grade: ");
            int newGrade;
            ind = Int32.TryParse(Console.ReadLine(), out newGrade);
            if (!ind)
            {
                Console.WriteLine("Invalid grade input.");
                return;
            }
            Console.WriteLine();
            try
            {
                examRegistrationController.UpdateExamRegistration(index, subjectId, date, newGrade);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void DeleteExamRegistration(ExamRegistrationController examRegistrationController)
        {
            Console.WriteLine("Enter index: ");
            string index = Console.ReadLine();
            Console.WriteLine("Enter subject ID: ");
            string subjectId = Console.ReadLine();
            Console.WriteLine("Enter date (1/1/2021) : ");
            DateTime date;
            bool ind = DateTime.TryParse(Console.ReadLine(), out date);
            if (!ind)
            {
                Console.WriteLine("Invalid date input.");
                return;
            }
            Console.WriteLine();
            try
            {
                examRegistrationController.DeleteExamRegistration(index, subjectId, date);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ReadExamRegistration(ExamRegistrationController examRegistrationController)
        {
            Console.WriteLine("Enter index: ");
            string index = Console.ReadLine();
            Console.WriteLine("Enter subjectId: ");
            string subjectId = Console.ReadLine();
            Console.WriteLine("Enter date (1/1/2021) : ");
            DateTime date;
            bool ind = DateTime.TryParse(Console.ReadLine(), out date);
            if (!ind)
            {
                Console.WriteLine("Invalid date input.");
                return;
            }
            Console.WriteLine();

            ExamRegistration examRegistration = examRegistrationController.FindExamRegistration(index, subjectId, date);

            if (examRegistration != null) Console.WriteLine(examRegistration.ToString());
            else Console.WriteLine("Exam registration not found!");
            Console.WriteLine();
        }

        private static void ReadAllExamRegistrations(ExamRegistrationController examRegistrationController)
        {
            var ers = examRegistrationController.GetAllExamRegistrations();

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

        private static void CreateExamRegistration(StudentController studentController, ProfessorController professorController, SubjectController subjectController, ExamRegistrationController examRegistrationController)
        {
            Console.WriteLine("Enter index: ");
            string index = Console.ReadLine();
            Console.WriteLine("Enter exam ID: ");
            string examId = Console.ReadLine();
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
            Console.WriteLine("Enter professor ID: ");
            string profId = Console.ReadLine();
            try
            {
                examRegistrationController.AddExamRegistration(index, examId, date, grade, profId, studentController, professorController, subjectController);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
