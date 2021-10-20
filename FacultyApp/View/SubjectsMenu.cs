using Domain;
using FacultyApp.Controller;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyApp.View
{
    public class SubjectsMenu
    {
        public SubjectController SubjectController { get; set; }

        public SubjectsMenu(SubjectController subjectController)
        {
            SubjectController = subjectController;
        }

        public void ShowMenu()
        {

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
                            CreateSubject();
                            break;
                        case 2:
                            ReadSubject();
                            break;
                        case 3:
                            UpdateSubject();
                            break;
                        case 4:
                            DeleteSubject();
                            break;
                        case 5:
                            ReadAllSubjects();
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

        private void DeleteSubject()
        {
            Console.WriteLine("Enter subject name: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            try
            {
                SubjectController.DeleteSubject(name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void UpdateSubject()
        {
            Console.WriteLine("Enter subject name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter new subject name: ");
            string newName = Console.ReadLine();
            Console.WriteLine();
            try
            {
                SubjectController.UpdateSubject(name, newName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ReadSubject()
        {
            Console.WriteLine("Enter subject name: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            Subject subject = SubjectController.FindSubject(name);

            if (subject != null) Console.WriteLine(subject.ToString());
            else Console.WriteLine("Subject not found!");
            Console.WriteLine();
        }

        private void CreateSubject()
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter ESPB: ");
            int espb;
            bool ind = int.TryParse(Console.ReadLine(), out espb);
            if (!ind) 
                throw new Exception("Invalid espb input.");

            Console.WriteLine("Enter semester: ");
            int semester;
            ind = int.TryParse(Console.ReadLine(), out semester);
            if (!ind) 
                throw new Exception("Invalid semester input.");

            try
            {
                SubjectController.AddSubject(name, espb, semester);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ReadAllSubjects()
        {
            var subjects = SubjectController.GetAllSubjects();

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
