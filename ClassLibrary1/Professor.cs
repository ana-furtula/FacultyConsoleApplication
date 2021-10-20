using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Professor : Person
    {
        public Guid Id { get; }
        public Professor(string firstName, string lastName, string jmbg) : base(firstName, lastName, jmbg)
        {
            Id = Guid.NewGuid();
        }

        public Professor(Guid id, string firstName, string lastName, string jmbg) : base(firstName, lastName, jmbg)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"JMBG: {JMBG}, First name: {FirstName}, Last name: {LastName}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Professor prof)
            {
                return FirstName.Equals(prof.FirstName) && LastName.Equals(prof.LastName);
            }
            return false;
        }
    }
}
