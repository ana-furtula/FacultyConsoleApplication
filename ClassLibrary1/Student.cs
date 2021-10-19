
using System;
namespace Domain
{
    public class Student : Person
    {
        public string Indeks { get; set; }
        public Student(string firstName, string lastName, string indeks) : base(firstName, lastName)
        {
            Validation.IndexValidation(indeks);
            Indeks = indeks;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {Indeks}";
        }

        public override bool Equals(object obj)
        {
            if(obj is Student s1)
            {
                return Indeks.Equals(s1.Indeks);
            }

            return false;
        }
    }
}
