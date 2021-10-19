using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Subject
    {
        public string Name { get; set; }
        public int ESPB { get; set; }
        public string Id { get; set; }

        public Subject(string id, string name, int espb)
        {
            Validation.ESPBValidation(espb);
            Validation.SubjectNameValidation(name);
            ESPB = espb;
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Id} {Name} {ESPB}";
        }
    }
}
