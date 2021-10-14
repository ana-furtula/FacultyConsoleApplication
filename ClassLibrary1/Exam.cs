using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Exam
    {
        public string Name { get; set; }
        public int ESPB { get; set; }
        public string Code { get; set; }

        public Exam(string code, string name, int espb)
        {
            if (espb > 0 && espb <= 10) ESPB = espb;
            else throw new Exception("Espb not valid");
            Code = code;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Code} {Name} {ESPB}";
        }
    }
}
