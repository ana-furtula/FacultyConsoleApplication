using System.Collections.Generic;
using Domain;

namespace RepositoryServices.Interfaces
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        void UpdateStudent(string index, string newFirstName);
        void DeleteStudent(string indeks);
        Student GetStudentByIndex(string indeks);
        List<Student> GetAll();
    }
}