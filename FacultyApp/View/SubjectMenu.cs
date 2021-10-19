using Domain;
using FacultyApp.Controller;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyApp.View
{
    public class SubjectMenu
    {
        public static void ShowMenu(IServiceProvider serviceProvider)
        {
            var subjectController = serviceProvider.GetRequiredService<SubjectController>();

            int ans;
            do
            {
                Console.WriteLine("0. Exit subjects");
                Console.WriteLine("1. Create subject");
                Console.WriteLine("2. Read subject");
                Console.WriteLine("3. Update subject");
                Console.WriteLine("4. Delete subject");
                Console.WriteLine("5. Read all subjects");

                bool ind = Int32.TryParse(Console.ReadLine(), out ans);
                Console.WriteLine();

                if (ind)
                {
                    switch (ans)
                    {
                        case 0:
                            break;
                        case 1:
                            CreateSubject(subjectController);
                            break;
                        case 2:
                            ReadSubject(subjectController);
                            break;
                        case 3:
                            UpdateSubject(subjectController);
                            break;
                        case 4:
                            DeleteSubject(subjectController);
                            break;
                        case 5:
                            ReadAllSubjects(subjectController);
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

        private static void DeleteSubject(SubjectController subjectController)
        {
            Console.WriteLine("Enter ID: ");
            string id = Console.ReadLine();
            Console.WriteLine();
            try
            {
                subjectController.DeleteSubject(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void UpdateSubject(SubjectController subjectController)
        {
            Console.WriteLine("Enter ID: ");
            string id = Console.ReadLine();
            Console.WriteLine("Enter new id: ");
            string newId = Console.ReadLine();
            Console.WriteLine();
            try
            {
                subjectController.UpdateSubject(id, newId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ReadSubject(SubjectController subjectController)
        {
            Console.WriteLine("Enter ID: ");
            string id = Console.ReadLine();
            Console.WriteLine();
            Subject subject = subjectController.FindSubject(id);

            if (subject != null) Console.WriteLine(subject.ToString());
            else Console.WriteLine("Exam not found!");
            Console.WriteLine();
        }

        private static void CreateSubject(SubjectController subjectController)
        {
            Console.WriteLine("Enter ID: ");
            string id = Console.ReadLine();
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter ESPB: ");
            int espb;
            bool ind = int.TryParse(Console.ReadLine(), out espb);

            if (!ind) throw new Exception("Invalid espb input.");

            try
            {
                subjectController.AddSubject(id, name, espb);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ReadAllSubjects(SubjectController subjectController)
        {
            var subjects = subjectController.GetAllSubjects();

            if (subjects.Count == 0)
            {
                Console.WriteLine("0 subjects.");
                Console.WriteLine();
                return;
            }

            foreach (Subject subject in subjects)
            {
                Console.WriteLine(subject);
            }
            Console.WriteLine();
        }
    }
}
