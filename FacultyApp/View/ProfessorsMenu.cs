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
        public ProfessorController ProfessorController { get; set; }
        public ProfessorsMenu(ProfessorController professorController)
        {
            ProfessorController = professorController;
        }

        public void ShowMenu()
        {

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
                            CreateProfessor();
                            break;
                        case 2:
                            ReadProfessor();
                            break;
                        case 3:
                            UpdateProfessor();
                            break;
                        case 4:
                            DeleteProfessor();
                            break;
                        case 5:
                            ReadAllProfessors();
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

        private void DeleteProfessor()
        {
            Console.WriteLine("Enter jmbg: ");
            string jmbg = Console.ReadLine();

            Console.WriteLine();

            try
            {
                ProfessorController.DeleteProfessor(jmbg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void UpdateProfessor()
        {
            Console.WriteLine("Enter JMBG: ");
            string jmbg = Console.ReadLine();

            Console.WriteLine("Enter new first name: ");
            string newFirstName = Console.ReadLine();

            Console.WriteLine();

            try
            {
                ProfessorController.UpdateProfessor(jmbg, newFirstName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private void ReadProfessor()
        {
            Console.WriteLine("Enter JMBG: ");
            string jmbg = Console.ReadLine();
          
            Console.WriteLine();

            try
            {
                Professor prof = ProfessorController.FindProfessor(jmbg);

                if (prof != null) Console.WriteLine(prof.ToString());
                else Console.WriteLine("Professor not found!");
                Console.WriteLine();

            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void CreateProfessor()
        {
            Console.WriteLine("Enter first name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter last name: ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter JMBG: ");
            string jmbg = Console.ReadLine();

            try
            {
                ProfessorController.AddProfessor(firstName, lastName, jmbg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ReadAllProfessors()
        {
            var profs = ProfessorController.GetAllProfessors();

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
