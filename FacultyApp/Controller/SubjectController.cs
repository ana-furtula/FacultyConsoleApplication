using Domain;
using FacultyApp.Model;
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

        public void AddSubject(string id, string name, int espb)
        {
            try
            {
                Subject subject = new Subject(id, name, espb);
                SubjectRepository.Add(subject);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Subject FindSubject(string id)
        {
            return SubjectRepository.GetSubjectByCredentials(id);
        }

        public void UpdateSubject(string id, string newId)
        {
            try
            {
                SubjectRepository.Update(id, newId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteSubject(string id)
        {
            try
            {
                SubjectRepository.Delete(id);
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
