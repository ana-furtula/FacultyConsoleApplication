﻿using System;
using System.Collections.Generic;
using Domain;
using System.Linq;

namespace FacultyApp.Model
{
    public class InMemoryStudentRepository : IStudentRepository
    {
        private List<Student> _students = new List<Student>();
       
        public void AddStudent(Student student)
        {
            if (_students.Contains(student)) throw new Exception("Student already exists!");
            _students.Add(student);
        }

        public void DeleteStudent(string indeks)
        {
            Student s = GetStudentByIndex(indeks);
            if (s == null) throw new Exception("Student is not found!");
            _students.Remove(s);
        }

        public List<Student> GetAll()
        {
            return _students;
        }

        public Student GetStudentByIndex(string indeks)
        {
            return _students?.FirstOrDefault(x => x.Indeks.Equals(indeks));
        }

        public void UpdateStudent(string oldIndeks, string newIndeks)
        {
            Student s = GetStudentByIndex(oldIndeks);
            if (s == null) throw new Exception("Student is not found!");
            if (GetStudentByIndex(newIndeks) != null) throw new Exception("Student with this index already exists.");
            s.Indeks = newIndeks;
        }
    }
}