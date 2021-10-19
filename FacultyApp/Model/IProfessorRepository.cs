using System.Collections.Generic;
using Domain;

namespace FacultyApp.Model
{
    public interface IProfessorRepository
    {
        public void AddProfessor(Professor professor);
        public void UpdateProfessor(string id, string newId);
        public void DeleteProfessor(string id);
        public Professor GetProfByCredentials(string id);
        public List<Professor> GetAll();
    }
}
