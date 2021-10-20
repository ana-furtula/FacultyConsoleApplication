using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using RepositoryServices.Interfaces;

namespace InMemoryRepositoryServices
{
    public class InMemoryExamRegistrationRepository : IExamRegistrationRepository
    {
        private List<ExamRegistration> _ers = new List<ExamRegistration>();
        public void Add(ExamRegistration examRegistration)
        {

            if(_ers.Contains(examRegistration))
                throw new Exception("Exam registration already exists.");

            _ers.Add(examRegistration);

        }

        public void Delete(string index, Guid subjectId, DateTime date)
        {
            ExamRegistration er = GetERByCredentials(index, subjectId, date);
            if (er == null) throw new Exception("Exam registration is not found!");
            if (er.IsLocked) throw new Exception("Exam registration cannot be deleted.");
            _ers.Remove(er);
        }

        public List<ExamRegistration> GetAll()
        {
            return _ers;
        }

        public ExamRegistration GetERByCredentials(string index, Guid subjectId, DateTime date)
        {
            return _ers?.FirstOrDefault(x => x.Index.Equals(index) && x.SubjectId.Equals(subjectId) && x.Date == date);
        }

        public void Update(string index, Guid subjectId, DateTime date, int grade, Guid professorId)
        {
            ExamRegistration er = GetERByCredentials(index, subjectId, date);

            if (er == null) 
                throw new Exception("Exam registration is not found!");
            if (er.IsLocked)
                throw new Exception("Exam registration cannot be changed.");
            er.Grade = grade;
            er.ProfId = professorId;
            er.IsLocked = true;
        }
    }
}
