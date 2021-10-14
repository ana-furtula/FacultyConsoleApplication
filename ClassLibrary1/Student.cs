
using System;
namespace Domain
{
    public class Student : Person
    {
        public string Indeks { get; set; }
        public Student(string firstName, string lastName, string indeks) : base(firstName, lastName)
        {   
            if (Validation.IndexValidation(indeks)) Indeks = indeks;
            else throw new Exception("Index is not valid!");
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {Indeks}";
        }
    }
}
