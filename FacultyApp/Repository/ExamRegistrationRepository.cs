using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Domain;
using Newtonsoft.Json;

namespace FacultyApp.Repository
{
    class ExamRegistrationRepository
    {
        private static ExamRegistrationRepository _instance;
        private object _lock = new object();
        private List<ExamRegistration> _ers = new List<ExamRegistration>();
        private ExamRegistrationRepository()
        {
        }

        public static ExamRegistrationRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ExamRegistrationRepository();
                return _instance;
            }
        }

        public void Add(string indeks, string examCode, DateTime date, int grade, string profCode)
        {
            try
            {
                Load();
                StudentRepository.Instance.Load();
                ExamRepository.Instance.Load();
                ProfessorRepository.Instance.Load();
                if (StudentRepository.Instance.GetStudentByIndex(indeks) != null && ExamRepository.Instance.GetExamByCredentials(examCode) != null && ProfessorRepository.Instance.GetProfByCredentials(profCode) != null)
                {
                    ExamRegistration er = new ExamRegistration(indeks, examCode, date, grade, profCode);
                    foreach(ExamRegistration examRegistration in _ers)
                    {
                        if(examRegistration.Date.Date==er.Date.Date && examRegistration.ExamCode == er.ExamCode && examRegistration.Indeks == er.Indeks)
                        {
                            throw new Exception("Exam registration already exists.");
                        }
                    }
                    if (!_ers.Contains(er)) _ers.Add(er);
                    Save();
                }
                else
                {
                    throw new Exception("Student/Professor/Exam does not exist. Exam registration cannot be added!");
                }
            } catch(Exception e)
            {
                throw e;
            }
        }

        public void Update(string indeks, string examCode, DateTime date, int newGrade)
        {
            Load();
            ExamRegistration er = GetERByCredentials(indeks, examCode, date);
            if (er == null) throw new Exception("Exam registration is not found!");
            if (newGrade >= 5 && newGrade <= 10) er.Grade = newGrade;
            else throw new Exception("Grade is not valid!");
            Save();
        }

        public void Delete(string indeks, string examCode, DateTime date)
        {
            ExamRegistration er = GetERByCredentials(indeks, examCode, date);
            if (er == null) throw new Exception("Exam registration is not found!");
            _ers.Remove(er);
            Save();
        }

        public ExamRegistration GetERByCredentials(string indeks, string examCode, DateTime date)
        {
            return _ers?.FirstOrDefault(x => x.Indeks.Equals(indeks) && x.ExamCode.Equals(examCode) && x.Date == date);
        }

        public void Save()
        {
            lock (_lock)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "ers.json");

                var jsonText = JsonConvert.SerializeObject(_ers, Formatting.Indented);

                File.WriteAllText(filePath, jsonText);
            }
        }

        internal void Load()
        {
            lock (_lock)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "ers.json");

                var jsonText = File.ReadAllText(filePath);

                var ersFromFile = JsonConvert.DeserializeObject<List<ExamRegistration>>(jsonText);

                _ers = ersFromFile == null ? new List<ExamRegistration>() : ersFromFile;

            }
        }
    }
}
