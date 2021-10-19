using System;

namespace Domain
{
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
      
        public Person(string firstName, string lastName)
        {
            Validation.NameValidation(firstName);
            Validation.NameValidation(lastName);

            FirstName = firstName;
            LastName = lastName;
        }

    }
}
