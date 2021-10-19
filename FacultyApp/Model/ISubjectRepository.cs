using System.Collections.Generic;
using Domain;

namespace FacultyApp.Model
{
    public interface ISubjectRepository
    {
        public void Add(Subject subject);
        public void Update(string id, string newId);
        public void Delete(string id);
        public Subject GetSubjectByCredentials(string id);
        public List<Subject> GetAll();


    }
}
