using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace FacultyApp.Model
{
    public class InMemorySubjectRepository : ISubjectRepository
    {
        private List<Subject> _subjects = new List<Subject>();

        public void Add(Subject subject)
        {
            if (GetSubjectByCredentials(subject.Id) != null) throw new Exception("Subject with this ID already exists!");
            _subjects.Add(subject);
        }

        public void Delete(string id)
        {
            Subject subject = GetSubjectByCredentials(id);
            if (subject == null) throw new Exception("Subject is not found!");
            _subjects.Remove(subject);
        }

        public List<Subject> GetAll()
        {
            return _subjects;
        }

        public Subject GetSubjectByCredentials(string id)
        {
            return _subjects == null ? null : _subjects.FirstOrDefault(x => x.Id == id);
        }

        public void Update(string id, string newId)
        {
            Subject subject = GetSubjectByCredentials(id);
            if (subject == null) throw new Exception("Subject is not found!");
            if (GetSubjectByCredentials(newId) != null) throw new Exception("Subject with this code already exists!");
            subject.Id = newId;
        }
    }
}
