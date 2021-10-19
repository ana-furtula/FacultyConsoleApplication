using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Professor : Person
    {
        public string Id { get; set; }
        public Professor(string firstName, string lastName, string id) : base(firstName, lastName)
        {
            Id = id;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName} {Id}";
        }

        public override bool Equals(object obj)
        {
           if(obj is Professor prof)
            {
                return Id.Equals(prof.Id);
            }
            return false;
        }
    }
}
