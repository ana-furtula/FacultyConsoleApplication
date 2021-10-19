using Domain;
using FacultyApp.Model;
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

        public void AddStudent(string firstName, string lastName, string index)
        {
            try
            {
                Student student = new Student(firstName, lastName, index);
                StudentRepository.AddStudent(student);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Student FindStudent(string index)
        {
            Validation.IndexValidation(index);
            return StudentRepository.GetStudentByIndex(index);
        }

        public void UpdateStudent(string oldIndex, string newIndex)
        {
            Validation.IndexValidation(oldIndex);
            Validation.IndexValidation(newIndex);

            try
            {
                StudentRepository.UpdateStudent(oldIndex, newIndex);
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
