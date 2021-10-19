using System.Collections.Generic;
using Domain;

namespace FacultyApp.Model
{
    public interface IStudentRepository
    {
        public void AddStudent(Student student);
        public void UpdateStudent(string oldIndeks, string newIndeks);
        public void DeleteStudent(string indeks);
        public Student GetStudentByIndex(string indeks);
        public List<Student> GetAll();

    }
}