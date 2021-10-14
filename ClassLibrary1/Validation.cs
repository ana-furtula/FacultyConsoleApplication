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
            return false;
        }
        public static bool NameValidation(string name)
        {
            Regex rx = new Regex("[A-Z]+[a-z]+");
            if (rx.IsMatch(name)) return true;
            throw new Exception("Invalid name input.");
        }

    }
}
