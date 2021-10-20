using System;

namespace Domain
{
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JMBG { get; set; }

        public Person(string firstName, string lastName, string jmbg)
        {
            if(!Validation.NameValidation(firstName)) throw new Exception("Invalid first name.");
            if(!Validation.NameValidation(lastName)) throw new Exception("Invalid last name.");
            if (!Validation.JMBGValidation(jmbg)) throw new Exception("Invalid JMBG");

            FirstName = firstName;
            LastName = lastName;
            JMBG = jmbg;
        }

    }
}
