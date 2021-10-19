using System;
using System.Collections.Generic;
using Domain;

namespace FacultyApp.Model
{
    public interface IExamRegistrationRepository
    {
        public void Add(ExamRegistration examRegistration);
        public void Update(string index, string subjectId, DateTime date, int newGrade);
        public void Delete(string index, string subjectId, DateTime date);
        public ExamRegistration GetERByCredentials(string index, string subjectId, DateTime date);
        public List<ExamRegistration> GetAll();

    }
}
