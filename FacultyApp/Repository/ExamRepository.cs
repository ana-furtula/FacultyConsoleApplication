using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Domain;
using Newtonsoft.Json;

namespace FacultyApp.Repository
{
    public class ExamRepository
    {
        private static ExamRepository _instance;
        private object _lock = new object();
        private List<Exam> _exams = new List<Exam>();
        private ExamRepository()
        {
        }

        public static ExamRepository Instance
        {
            get
            {
                if (_instance == null) _instance = new ExamRepository();
                return _instance;
            }
        }

        public bool Exist(Exam exam)
        {
            return _exams.Contains(exam);
        }

        public void Add(string code, string name, int espb)
        {
            try
            {
                Exam exam = new Exam(code, name, espb);
                if (GetExamByCredentials(code) != null) throw new Exception("Exam with this code already exists!");
                _exams.Add(exam);
                Save();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(string code, string newCode)
        {
            Load();
            Exam exam = GetExamByCredentials(code);
            if (exam == null) throw new Exception("Exam is not found!");
            if (GetExamByCredentials(newCode) != null) throw new Exception("Exam with this code already exists!");
            exam.Code = newCode;
            Save();
        }

        public void Delete(string code)
        {
            Exam exam = GetExamByCredentials(code);
            if (exam == null) throw new Exception("Exam is not found!");
            _exams.Remove(exam);
            Save();
        }
        public Exam GetExamByCredentials(string code)
        {
            return _exams == null ? null : _exams.FirstOrDefault(x => x.Code == code);
        }

        public void Save()
        {
            lock (_lock)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "exams.json");

                var jsonText = JsonConvert.SerializeObject(_exams, Formatting.Indented);

                File.WriteAllText(filePath, jsonText);
            }
        }
        internal void Load()
        {
            lock (_lock)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "exams.json");

                var jsonText = File.ReadAllText(filePath);

                var examsFromFile = JsonConvert.DeserializeObject<List<Exam>>(jsonText);

                _exams = examsFromFile == null ? new List<Exam>() : examsFromFile;

            }
        }
    }
}
