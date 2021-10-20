using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using RepositoryServices.Interfaces;

namespace InMemoryRepositoryServices
{
    public class InMemoryProfessorRepository : IProfessorRepository
    {
        private List<Professor> _profs = new List<Professor>();

        public void AddProfessor(Professor professor)
        {
            if (GetProfByCredentials(professor.JMBG) != null)
                throw new Exception("Professor with this id already exists!");

            _profs.Add(professor);
        }

        public void DeleteProfessor(string jmbg)
        {
            Professor prof = GetProfByCredentials(jmbg);

            if (prof == null) 
                throw new Exception("Professor is not found!");

            _profs.Remove(prof);
        }

        public List<Professor> GetAll()
        {
            return _profs;
        }

        public Professor GetProfByCredentials(string jmbg)
        {
            return _profs?.FirstOrDefault(x => x.JMBG == jmbg);
        }

        public void UpdateProfessor(string jmbg, string newFirstName)
        {
            Professor p = GetProfByCredentials(jmbg);

            if (p == null) 
                throw new Exception("Professor is not found!");

            p.FirstName = newFirstName;
        }
    }
}
