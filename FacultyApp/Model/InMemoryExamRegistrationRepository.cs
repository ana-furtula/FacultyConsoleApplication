using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace FacultyApp.Model
{
    public class InMemoryExamRegistrationRepository : IExamRegistrationRepository
    {
        private List<ExamRegistration> _ers = new List<ExamRegistration>();
        public void Add(ExamRegistration examRegistration)
        {

            foreach (ExamRegistration er in _ers)
            {
                if (examRegistration.Date.Date == er.Date.Date && examRegistration.ExamCode == er.ExamCode && examRegistration.Indeks == er.Indeks)
                {
                    throw new Exception("Exam registration already exists.");
                }
            }
            _ers.Add(examRegistration);

        }

        public void Delete(string index, string subjectId, DateTime date)
        {
            ExamRegistration er = GetERByCredentials(index, subjectId, date);
            if (er == null) throw new Exception("Exam registration is not found!");
            _ers.Remove(er);
        }

        public List<ExamRegistration> GetAll()
        {
            return _ers;
        }

        public ExamRegistration GetERByCredentials(string index, string subjectId, DateTime date)
        {
            return _ers?.FirstOrDefault(x => x.Indeks.Equals(index) && x.ExamCode.Equals(subjectId) && x.Date == date);
        }

        public void Update(string index, string subjectId, DateTime date, int newGrade)
        {
            ExamRegistration er = GetERByCredentials(index, subjectId, date);
            if (er == null) throw new Exception("Exam registration is not found!");
            if (newGrade >= 5 && newGrade <= 10) er.Grade = newGrade;
            else throw new Exception("Grade is not valid!");
        }
    }
}
