using Domain;
using RepositoryServices.Interfaces;
using System;
using System.Collections.Generic;

namespace FacultyApp.Controller
{
    public class SubjectController
    {
        public SubjectController(ISubjectRepository subjectRepository)
        {
            SubjectRepository = subjectRepository;
        }

        public void AddSubject(string name, int espb, int semester)
        {
            try
            {
                Subject subject = new Subject(name, espb, semester);
                SubjectRepository.Add(subject);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Subject FindSubject(string name)
        {
            return SubjectRepository.GetSubjectByCredentials(name);
        }

        public void UpdateSubject(string name, string newName)
        {
            try
            {
                SubjectRepository.Update(name, newName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteSubject(string name)
        {
            try
            {
                SubjectRepository.Delete(name);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Subject> GetAllSubjects()
        {
            return SubjectRepository.GetAll();
        }

        private ISubjectRepository SubjectRepository { get; set; }
    }
}
