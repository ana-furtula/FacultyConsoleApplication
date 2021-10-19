using Domain;
using FacultyApp.Model;
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

        public void AddProfessor(string firstName, string lastName, string id)
        {
            try
            {
                Professor prof = new Professor(firstName, lastName, id);
                ProfessorRepository.AddProfessor(prof);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Professor FindProfessor(string id)
        {
            return ProfessorRepository.GetProfByCredentials(id);
        }

        public void UpdateProfessor(string id, string newId)
        {
            try
            {
                ProfessorRepository.UpdateProfessor(id, newId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteProfessor(string id)
        {
            try
            {
                ProfessorRepository.DeleteProfessor(id);
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
