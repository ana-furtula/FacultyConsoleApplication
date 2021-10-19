using FacultyApp.Controller;
using FacultyApp.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyApp.View
{
    public class Menu
    {
        private static IServiceProvider serviceProvider { get; set; }
        public static void showMenu()
        {
            serviceProvider = CreateServiceProvider();

            bool ind;
            int ans;
            do
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Students");
                Console.WriteLine("2. Professors");
                Console.WriteLine("3. Subjects");
                Console.WriteLine("4. Exam registrations");
                ind = Int32.TryParse(Console.ReadLine(), out ans);
                if (ind)
                {
                    Console.WriteLine();
                    switch (ans)
                    {
                        case 0:
                            break;
                        case 1:
                            StudentsMenu.ShowMenu(serviceProvider);
                            break;
                        case 2:
                            ProfessorsMenu.ShowMenu(serviceProvider);
                            break;
                         case 3:
                            SubjectMenu.ShowMenu(serviceProvider);
                             break;
                         case 4:
                            ExamRegistrationMenu.ShowMenu(serviceProvider);
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

        private static IServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IStudentRepository, InMemoryStudentRepository>();
            services.AddTransient<StudentController, StudentController>();

            services.AddSingleton<IProfessorRepository, InMemoryProfessorRepository>();
            services.AddTransient<ProfessorController, ProfessorController>();

            services.AddSingleton<ISubjectRepository, InMemorySubjectRepository>();
            services.AddTransient<SubjectController, SubjectController>();

            services.AddSingleton<IExamRegistrationRepository, InMemoryExamRegistrationRepository>();
            services.AddTransient<ExamRegistrationController, ExamRegistrationController>();

            return services.BuildServiceProvider();
        }

    }

}
