using System;

namespace Domain
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person()
        {
        }
        public Person(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

    }
}
