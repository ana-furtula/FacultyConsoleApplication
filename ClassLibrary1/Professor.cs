using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Professor : Person
    {
        public string Code { get; set; }
        public Professor(string firstName, string lastName, string code) : base(firstName, lastName)
        {
            Code = code;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName} {Code}";
        }
    }
}
