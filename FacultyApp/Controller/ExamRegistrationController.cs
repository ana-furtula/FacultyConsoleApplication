using Domain;
using RepositoryServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyApp.Controller
{
    public class ExamRegistrationController
    {
        public ExamRegistrationController(IExamRegistrationRepository examRegistrationRepository)
        {
            ExamRegistrationRepository = examRegistrationRepository;
        }

        public void AddExamRegistration(string index, Guid subjectId, DateTime date)
        {

            ExamRegistration er = new ExamRegistration(index, subjectId, date, null, null);
            try
            {
                ExamRegistrationRepository.Add(er);
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public List<ExamRegistration> GetAllExamRegistrations()
        {
            return ExamRegistrationRepository.GetAll();
        }

        public ExamRegistration FindExamRegistration(string index, Guid subjectId, DateTime date)
        {

            return ExamRegistrationRepository.GetERByCredentials(index, subjectId, date);

        }

        public void DeleteExamRegistration(string index, Guid subjectId, DateTime date)
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

        public void UpdateExamRegistration(string index, Guid subjectId, DateTime date, int grade, Guid profId)
        {
            try
            {
                ExamRegistrationRepository.Update(index, subjectId, date, grade, profId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private IExamRegistrationRepository ExamRegistrationRepository { get; }

    }
}
