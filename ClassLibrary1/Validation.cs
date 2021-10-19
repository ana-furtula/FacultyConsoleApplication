using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain
{
    public class Validation
    {
        public static bool IndexValidation(string index)
        {
            Regex rx = new Regex("[0-9]+/[0-9]+");
            if (rx.IsMatch(index)) return true;
            throw new Exception("Invalid index input.");
        }

        public static bool NameValidation(string name)
        {
            Regex rx = new Regex("[A-Z]+[a-z]+");
            if (rx.IsMatch(name)) return true;
            throw new Exception("Invalid name input.");
        }

        public static bool ESPBValidation(int espb)
        {
            if (espb > 0 && espb <= 10) return true;
            throw new Exception("Invalid ESPB input.");
        }

        public static bool SubjectNameValidation(string name)
        {
            return true;
        }

        public static bool GradeValidation(int grade)
        {
            if (grade >= 5 && grade <= 10) return true;
            throw new Exception("Invalid grade input.");
        }

    }
}
