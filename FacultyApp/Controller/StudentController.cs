using Domain;
using RepositoryServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyApp.Controller
{
    public class StudentController
    {
        public StudentController(IStudentRepository studentRepository)
        {
            StudentRepository = studentRepository;
        }

        public void AddStudent(string firstName, string lastName, string index, string jmbg)
        {
            try
            {
                Student student = new Student(firstName, lastName, index, jmbg);
                StudentRepository.AddStudent(student);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Student FindStudent(string index)
        {
            if(!Validation.IndexValidation(index))
                throw new Exception("Invalid index format!");

            return StudentRepository.GetStudentByIndex(index);
        }

        public void UpdateStudent(string index, string newFirstName)
        {
            if(!Validation.IndexValidation(index))
                throw new Exception("Invalid index format");

            if (!Validation.NameValidation(newFirstName))
                throw new Exception("Invalid first name.");

            try
            {
                StudentRepository.UpdateStudent(index, newFirstName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteStudent(string index)
        {
            Validation.IndexValidation(index);

            try
            {
                StudentRepository.DeleteStudent(index);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Student> GetAllStudents()
        {
            return StudentRepository.GetAll();
        }

        private IStudentRepository StudentRepository { get; }
    }
}
