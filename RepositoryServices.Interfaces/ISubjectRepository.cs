using System.Collections.Generic;
using Domain;

namespace RepositoryServices.Interfaces
{
    public interface ISubjectRepository
    {
        void Add(Subject subject);
        void Update(string name, string newName);
        void Delete(string name);
        Subject GetSubjectByCredentials(string name);
        List<Subject> GetAll();
        bool Exists(Subject subject);
    }
}
