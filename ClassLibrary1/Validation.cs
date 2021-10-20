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

            if (rx.IsMatch(index)) 
                return true;

            return false;
        }

        public static bool NameValidation(string name)
        {
            Regex rx = new Regex("[A-Za-z]+");

            if (rx.IsMatch(name))
                return true;

            return false;

        }

        internal static bool JMBGValidation(string jmbg)
        {
            Regex rx = new Regex("[0-9]{2}");

            if (rx.IsMatch(jmbg))
                return true;

            return false;
        }

        public static bool ESPBValidation(int espb)
        {
            if (espb > 0 && espb <= 10) 
                return true;

            return false;
        }

        public static bool SubjectNameValidation(string name)
        {
            return true;
        }

        public static bool SemesterValidation(int semester)
        {
            if (semester >= 1 && semester <= 8)
                return true;

            return false;
        }

        public static bool GradeValidation(int grade)
        {
            if (grade >= 5 && grade <= 10) 
                return true;

            return false;
        }

    }
}
