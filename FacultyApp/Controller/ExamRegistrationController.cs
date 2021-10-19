using Domain;
using FacultyApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyApp.Controller
{
    class ExamRegistrationController
    {
        public ExamRegistrationController(IExamRegistrationRepository examRegistrationRepository)
        {
            ExamRegistrationRepository = examRegistrationRepository;
        }

        public void AddExamRegistration(string index, string subjectId, DateTime date, int grade, string profId,
            StudentController studentController, ProfessorController professorController,
            SubjectController subjectController)
        {

            if (studentController.FindStudent(index) != null && subjectController.FindSubject(subjectId) != null && professorController.FindProfessor(profId) != null)
            {
                ExamRegistration er = new ExamRegistration(index, subjectId, date, grade, profId);
                try
                {
                    ExamRegistrationRepository.Add(er);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                throw new Exception("Invalid input");
            }

        }

        public List<ExamRegistration> GetAllExamRegistrations()
        {
            return ExamRegistrationRepository.GetAll();
        }

        public ExamRegistration FindExamRegistration(string index, string subjectId, DateTime date)
        {

            return ExamRegistrationRepository.GetERByCredentials(index, subjectId, date);

        }

        public void DeleteExamRegistration(string index, string subjectId, DateTime date)
        {
            try
            {
                ExamRegistrationRepository.Delete(index, subjectId, date);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateExamRegistration(string index, string subjectId, DateTime date, int newGrade)
        {
            try
            {
                ExamRegistrationRepository.Update(index, subjectId, date, newGrade);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private IExamRegistrationRepository ExamRegistrationRepository { get; }

    }
}
