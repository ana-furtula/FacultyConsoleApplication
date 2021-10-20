
using System;
namespace Domain
{
    public class Student : Person
    {
        public string Indeks { get; set; }
        public Guid Id { get; }
        public Student(string firstName, string lastName, string indeks, string jmbg) : base(firstName, lastName, jmbg)
        {
            if (!Validation.IndexValidation(indeks))
                throw new Exception("Invalid index format!");

            Indeks = indeks;
            Id = Guid.NewGuid();
        }

        public Student(Guid id, string firstName, string lastName, string indeks, string jmbg) : base(firstName, lastName, jmbg)
        {
            if (!Validation.IndexValidation(indeks))
                throw new Exception("Invalid index format!");

            Indeks = indeks;
            Id = id;
        }

        public override string ToString()
        {
            return $"JMBG: {JMBG}, First name: {FirstName}, Last name: {LastName}, Index: {Indeks}";
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
