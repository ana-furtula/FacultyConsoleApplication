using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Domain;
using Newtonsoft.Json;

namespace FacultyApp.Repository
{
    public class ProfessorRepository
    {
        private static ProfessorRepository _instance;
        private object _lock = new object();
        private List<Professor> _profs = new List<Professor>();
        private ProfessorRepository()
        {
        }
        public static ProfessorRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ProfessorRepository();
                return _instance;
            }
        }

        public bool Exist(Professor prof)
        {
            return _profs.Contains(prof);
        }

        public void Add(string firstName, string lastName, string code)
        {
            Professor prof = new Professor(firstName, lastName, code);
            if (GetProfByCredentials(code) != null) throw new Exception("Professor with this code already exists!");
            _profs.Add(prof);
            Save();
        }

        public void Update(string code, string newCode)
        {
            Load();
            Professor p = GetProfByCredentials(code);
            if (p == null) throw new Exception("Professor is not found!");
            if (GetProfByCredentials(newCode) != null) throw new Exception("Professor with this code already exists!");
            p.Code = newCode;
            Save();
        }

        public void Delete(string code)
        {
            Professor p = GetProfByCredentials(code);
            if (p == null) throw new Exception("Professor is not found!");
            _profs.Remove(p);
            Save();
        }
        public Professor GetProfByCredentials(string code)
        {
            return _profs?.FirstOrDefault(x => x.Code == code);
        }

        public void Save()
        {
            lock (_lock)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "profs.json");

                var jsonText = JsonConvert.SerializeObject(_profs, Formatting.Indented);

                File.WriteAllText(filePath, jsonText);
            }
        }
        internal void Load()
        {
            lock (_lock)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "profs.json");

                var jsonText = File.ReadAllText(filePath);

                var profsFromFile = JsonConvert.DeserializeObject<List<Professor>>(jsonText);

                _profs = profsFromFile ?? new List<Professor>();

            }
        }


    }
}
