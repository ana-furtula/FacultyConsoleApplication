using Domain;
using FacultyApp.Controller;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyApp.View
{
    public class StudentsMenu
    {
        public StudentController StudentController { get; set; }

        public StudentsMenu(StudentController studentController)
        {
            StudentController = studentController;
        }

        public void ShowMenu()
        {
            int ans;
            bool ind;
            do
            {
                Console.WriteLine("0. Exit students");
                Console.WriteLine("1. Create student");
                Console.WriteLine("2. Read student");
                Console.WriteLine("3. Update student");
                Console.WriteLine("4. Delete student");
                Console.WriteLine("5. Read all students");

                ind = Int32.TryParse(Console.ReadLine(), out ans);
                Console.WriteLine();
                if (ind)
                {
                    switch (ans)
                    {
                        case 0:
                            break;
                        case 1:
                            CreateStudent();
                            break;
                        case 2:
                            ReadStudent();
                            break;
                        case 3:
                            UpdateStudent();
                            break;
                        case 4:
                            DeleteStudent();
                            break;
                        case 5:
                            ReadAllStudents();
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

        private void CreateStudent()
        {
            try
            {
                Console.WriteLine("Enter first name: ");
                string firstName = Console.ReadLine();

                Console.WriteLine("Enter last name: ");
                string lastName = Console.ReadLine();

                Console.WriteLine("Enter index: ");
                string index = Console.ReadLine();

                Console.WriteLine("Enter JMBG: ");
                string jmbg = Console.ReadLine();

                StudentController.AddStudent(firstName, lastName, index, jmbg);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ReadStudent()
        {
            Console.WriteLine("Enter index: ");
            string indeks = Console.ReadLine();
            Console.WriteLine();

            try
            {
                Student s = StudentController.FindStudent(indeks);
                if (s != null) Console.WriteLine(s.ToString());
                else Console.WriteLine("Student not found!");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void UpdateStudent()
        {
            Console.WriteLine("Enter index: ");
            string index = Console.ReadLine();
            Console.WriteLine("Enter new first name: ");
            string newFirstName = Console.ReadLine();
            Console.WriteLine();

            try
            {
                StudentController.UpdateStudent(index, newFirstName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private void DeleteStudent()
        {
            Console.WriteLine("Enter index: ");
            string index = Console.ReadLine();
            Console.WriteLine();

            try
            {
                StudentController.DeleteStudent(index);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ReadAllStudents()
        {
            var students = StudentController.GetAllStudents();

            if (students.Count == 0)
            {
                Console.WriteLine("0 students.");
                Console.WriteLine();
                return;
            }

            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();
        }

    }
}
