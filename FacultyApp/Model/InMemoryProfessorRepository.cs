using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace FacultyApp.Model
{
    public class InMemoryProfessorRepository : IProfessorRepository
    {
        private List<Professor> _profs = new List<Professor>();

        public void AddProfessor(Professor professor)
        {
            if (GetProfByCredentials(professor.Id) != null) throw new Exception("Professor with this id already exists!");
            _profs.Add(professor);
        }

        public void DeleteProfessor(string id)
        {
            Professor prof = GetProfByCredentials(id);
            if (prof == null) throw new Exception("Professor is not found!");
            _profs.Remove(prof);
        }

        public List<Professor> GetAll()
        {
            return _profs;
        }

        public Professor GetProfByCredentials(string id)
        {
            return _profs?.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateProfessor(string id, string newId)
        {
            Professor p = GetProfByCredentials(id);
            if (p == null) throw new Exception("Professor is not found!");
            if (GetProfByCredentials(newId) != null) throw new Exception("Professor with this code already exists!");
            p.Id = newId;
        }
    }
}
