using System;
using System.Collections.Generic;
using System.IO;
using Domain;
using Newtonsoft.Json;
using System.Linq;

namespace FacultyApp.Repository
{
    public class StudentRepository
    {
        private static StudentRepository _instance;
        private object _lock = new object();
        private List<Student> _students = new List<Student>();

        private StudentRepository()
        {
        }
        public static StudentRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StudentRepository();
                }

                return _instance;
            }
        }

        public void Add(string firstName, string lastName, string indeks)
        {
            try
            {
                Student student = new Student(firstName, lastName, indeks);
                if (_students.Contains(student)) throw new Exception("Student already exists!");
                _students.Add(student);
                Save();
            } catch(Exception e)
            {
                throw e;
            }

        }
        public void Update(string oldIndeks, string newIndeks)
        {
            Load();
            Student s = GetStudentByIndex(oldIndeks);
            if (s == null) throw new Exception("Student is not found!");
            if (GetStudentByIndex(newIndeks) != null) throw new Exception("Student with this index already exists.");
            s.Indeks = newIndeks;
            Save();
        }

        public void Delete(string indeks)
        {
            Student s = GetStudentByIndex(indeks);
            if (s == null) throw new Exception("Student is not found!");
            _students.Remove(s);
            Save();
        }

        public Student GetStudentByIndex(string indeks)
        {
            return _students?.FirstOrDefault(x => x.Indeks.Equals(indeks));
        }

        public void Save()
        {
            lock (_lock)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "students.json");

                var jsonText = JsonConvert.SerializeObject(_students, Formatting.Indented);

                File.WriteAllText(filePath, jsonText);
            }
        }
        internal void Load()
        {
            lock (_lock)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "students.json");

                var jsonText = File.ReadAllText(filePath);

                var studentsFromFile = JsonConvert.DeserializeObject<List<Student>>(jsonText);

                _students = studentsFromFile == null ? new List<Student>() : studentsFromFile;

            }
        }

       
       
    }
}