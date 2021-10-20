using System.Collections.Generic;
using Domain;

namespace RepositoryServices.Interfaces
{
    public interface IProfessorRepository
    {
        void AddProfessor(Professor professor);
        void UpdateProfessor(string jmbg, string newFirstName);
        void DeleteProfessor(string jmbg);
        Professor GetProfByCredentials(string jmbg);
        List<Professor> GetAll();
    }
}
