using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Subject
    {
        public string Name { get; set; }
        public int ESPB { get; set; }
        public int Semester { get; set; }
        public Guid Id { get; }

        public Subject(string name, int espb, int semester)
        {
            if(!Validation.ESPBValidation(espb))
                throw new Exception("Invalid ESPB.");
            if(!Validation.SubjectNameValidation(name)) 
                throw new Exception("Invalid name.");

            Id = Guid.NewGuid();
            Name = name;
            ESPB = espb;
            Semester = semester;
        }

        public Subject(Guid id, string name, int espb, int semester)
        {
            if (!Validation.ESPBValidation(espb))
                throw new Exception("Invalid ESPB.");
            if (!Validation.SubjectNameValidation(name))
                throw new Exception("Invalid name.");

            Id = id;
            Name = name;
            ESPB = espb;
            Semester = semester;
        }


        public override string ToString()
        {
            return $"Name: {Name}, ESPB: {ESPB}, Semester: {Semester}";
        }

        public override bool Equals(object obj)
        {
            if(obj is Subject subject)
            {
                return Name.Equals(subject.Name);
            }
            return false;
        }
    }
}
