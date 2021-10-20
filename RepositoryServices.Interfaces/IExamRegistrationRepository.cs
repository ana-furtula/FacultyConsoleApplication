using System;
using System.Collections.Generic;
using Domain;

namespace RepositoryServices.Interfaces
{
    public interface IExamRegistrationRepository
    {
        void Add(ExamRegistration examRegistration);
        void Update(string index, Guid subjectId, DateTime date, int grade, Guid professorId);
        void Delete(string index, Guid subjectId, DateTime date);
        ExamRegistration GetERByCredentials(string index, Guid subjectId, DateTime date);
        List<ExamRegistration> GetAll();

    }
}
