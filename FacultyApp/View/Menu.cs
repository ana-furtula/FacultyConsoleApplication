using FacultyApp.Controller;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyApp.View
{
    public class Menu
    {
        public static void ShowMenu(IServiceProvider serviceProvider)
        {
            bool ind;
            int ans;
            do
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Students");
                Console.WriteLine("2. Professors");
                Console.WriteLine("3. Subjects");
                Console.WriteLine("4. Exam registrations");
                ind = int.TryParse(Console.ReadLine(), out ans);
                if (ind)
                {
                    Console.WriteLine();
                    switch (ans)
                    {
                        case 0:
                            break;
                        case 1:
                            var studentsMenu = serviceProvider.GetRequiredService<StudentsMenu>();
                            studentsMenu.ShowMenu();
                            break;
                        case 2:
                            var professorsMenu = serviceProvider.GetRequiredService<ProfessorsMenu>();
                            professorsMenu.ShowMenu();
                            break;
                         case 3:
                            var subjectsMenu = serviceProvider.GetRequiredService<SubjectsMenu>();
                            subjectsMenu.ShowMenu();
                             break;
                         case 4:
                            var examRegistrationMenu = serviceProvider.GetRequiredService<ExamRegistrationMenu>();
                            examRegistrationMenu.ShowMenu();
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
    }

}
