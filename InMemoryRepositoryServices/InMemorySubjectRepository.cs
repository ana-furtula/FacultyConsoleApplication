using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using RepositoryServices.Interfaces;

namespace InMemoryRepositoryServices
{
    public class InMemorySubjectRepository : ISubjectRepository
    {
        private List<Subject> _subjects = new List<Subject>();

        public void Add(Subject subject)
        {
            if (Exists(subject)) 
                throw new Exception("This subject already exists!");

            _subjects.Add(subject);
        }

        public void Delete(string name)
        {
            Subject subject = GetSubjectByCredentials(name);
            if (subject == null) throw new Exception("Subject is not found!");
            _subjects.Remove(subject);
        }

        public bool Exists(Subject subject)
        {
            if (_subjects.Contains(subject)) return true;
            return false;
        }

        public List<Subject> GetAll()
        {
            return _subjects;
        }

        public Subject GetSubjectByCredentials(string name)
        {
            return _subjects == null ? null : _subjects.FirstOrDefault(x => x.Name == name);
        }

        public void Update(string name, string newName)
        {
            Subject subject = GetSubjectByCredentials(name);
            if (subject == null) throw new Exception("Subject is not found!");
            if (GetSubjectByCredentials(newName) != null) throw new Exception("Subject with this name already exists!");
            subject.Name = newName;
        }
    }
}
