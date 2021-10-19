using Domain;
using FacultyApp.Controller;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyApp.View
{
    public class ProfessorsMenu
    {
        public static void ShowMenu(IServiceProvider serviceProvider)
        {
            var professorController = serviceProvider.GetRequiredService<ProfessorController>();

            int ans;

            do
            {
                Console.WriteLine("0. Exit professors");
                Console.WriteLine("1. Create");
                Console.WriteLine("2. Read");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. Delete");
                Console.WriteLine("5. Read all professors");
                bool ind = Int32.TryParse(Console.ReadLine(), out ans);
                Console.WriteLine();
                if (ind)
                {
                    switch (ans)
                    {
                        case 0:
                            break;
                        case 1:
                            CreateProfessor(professorController);
                            break;
                        case 2:
                            ReadProfessor(professorController);
                            break;
                        case 3:
                            UpdateProfessor(professorController);
                            break;
                        case 4:
                            DeleteProfessor(professorController);
                            break;
                        case 5:
                            ReadAllProfessors(professorController);
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

        private static void DeleteProfessor(ProfessorController professorController)
        {
            Console.WriteLine("Enter ID: ");
            string id = Console.ReadLine();
            Console.WriteLine();
            try
            {
                professorController.DeleteProfessor(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void UpdateProfessor(ProfessorController professorController)
        {
            Console.WriteLine("Enter ID: ");
            string id = Console.ReadLine();
            Console.WriteLine("Enter new ID: ");
            string newId = Console.ReadLine();
            Console.WriteLine();
            try
            {
                professorController.UpdateProfessor(id, newId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private static void ReadProfessor(ProfessorController professorController)
        {
            Console.WriteLine("Enter ID: ");
            string id = Console.ReadLine();
            Console.WriteLine();

            try
            {
                Professor prof = professorController.FindProfessor(id);

                if (prof != null) Console.WriteLine(prof.ToString());
                else Console.WriteLine("Professor not found!");
                Console.WriteLine();

            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void CreateProfessor(ProfessorController professorController)
        {
            Console.WriteLine("Enter first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter ID: ");
            string id = Console.ReadLine();
            try
            {
                professorController.AddProfessor(firstName, lastName, id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ReadAllProfessors(ProfessorController professorController)
        {
            var profs = professorController.GetAllProfessors();

            if (profs.Count == 0)
            {
                Console.WriteLine("0 professors.");
                Console.WriteLine();
                return;
            }

            foreach (Professor prof in profs)
            {
                Console.WriteLine(prof);
            }
            Console.WriteLine();
        }

    }
}
