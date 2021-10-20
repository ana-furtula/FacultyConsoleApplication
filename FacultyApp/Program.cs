using System;
using Domain;
using FacultyApp.Controller;
using FacultyApp.View;
using InMemoryRepositoryServices;
using Microsoft.Extensions.DependencyInjection;
using RepositoryServices.Interfaces;
using SQLRepositoryServices;

namespace FacultyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var serviceProvider = CreateServiceProvider();
            Menu.ShowMenu(serviceProvider);
        }

        private static IServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IStudentRepository, SQLStudentRepository>();
            services.AddTransient<StudentController>();

            services.AddSingleton<IProfessorRepository, SQLProfessorRepository>();
            services.AddTransient<ProfessorController>();

            services.AddSingleton<ISubjectRepository, SQLSubjectRepository>();
            services.AddTransient<SubjectController>();

            services.AddSingleton<IExamRegistrationRepository, SQLExamRegistrationRepository>();
            services.AddTransient<ExamRegistrationController>();

            services.AddSingleton<StudentsMenu>();

            services.AddSingleton<ProfessorsMenu>();

            services.AddSingleton<SubjectsMenu>();

            services.AddSingleton<ExamRegistrationMenu>();


            return services.BuildServiceProvider();
        }

    }
}
