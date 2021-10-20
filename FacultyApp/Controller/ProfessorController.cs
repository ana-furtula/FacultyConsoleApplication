using Domain;
using RepositoryServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyApp.Controller
{
    public class ProfessorController
    {

        public ProfessorController(IProfessorRepository professorRepository)
        {
            ProfessorRepository = professorRepository;
        }

        public void AddProfessor(string firstName, string lastName, string jmbg)
        {
            try
            {
                Professor prof = new Professor(firstName, lastName, jmbg);
                ProfessorRepository.AddProfessor(prof);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Professor FindProfessor(string jmbg)
        {
            return ProfessorRepository.GetProfByCredentials(jmbg);
        }

        public void UpdateProfessor(string jmbg, string newFirstName)
        {
            try
            {
                ProfessorRepository.UpdateProfessor(jmbg, newFirstName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteProfessor(string jmbg)
        {
            try
            {
                ProfessorRepository.DeleteProfessor(jmbg);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Professor> GetAllProfessors()
        {
            return ProfessorRepository.GetAll();
        }

        private IProfessorRepository ProfessorRepository { get; }

    }
}
