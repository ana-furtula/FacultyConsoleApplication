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
        public static void ShowMenu(IServiceProvider serviceProvider)
        {
            var studentController = serviceProvider.GetRequiredService<StudentController>();

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
                            CreateStudent(studentController);
                            break;
                        case 2:
                            ReadStudent(studentController);
                            break;
                        case 3:
                            UpdateStudent(studentController);
                            break;
                        case 4:
                            DeleteStudent(studentController);
                            break;
                        case 5:
                            ReadAllStudents(studentController);
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

        static void CreateStudent(StudentController studentController)
        {
            try
            {
                Console.WriteLine("Enter first name: ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter last name: ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter index: ");
                string index = Console.ReadLine();

                studentController.AddStudent(firstName, lastName, index);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ReadStudent(StudentController studentController)
        {
            Console.WriteLine("Enter index: ");
            string indeks = Console.ReadLine();
            Console.WriteLine();
            try
            {
                Student s = studentController.FindStudent(indeks);
                if (s != null) Console.WriteLine(s.ToString());
                else Console.WriteLine("Student not found!");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void UpdateStudent(StudentController studentController)
        {
            Console.WriteLine("Enter old index: ");
            string oldIndex = Console.ReadLine();
            Console.WriteLine("Enter new index: ");
            string newIndex = Console.ReadLine();
            Console.WriteLine();

            try
            {
                studentController.UpdateStudent(oldIndex, newIndex);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        static void DeleteStudent(StudentController studentController)
        {
            Console.WriteLine("Enter index: ");
            string index = Console.ReadLine();
            Console.WriteLine();

            try
            {
                studentController.DeleteStudent(index);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ReadAllStudents(StudentController studentController)
        {
            var students = studentController.GetAllStudents();

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
