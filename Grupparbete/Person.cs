using System;
using System.Collections.Generic;
using System.Text;

namespace Grupparbete
{
    class Person
    {
        public Person(string name, int age, int workPlaceID)
        {
            Age = age;
            Name = name;
            WorkPlaceID = workPlaceID;
        }

        public int Age { get; set; }
        public string Name { get; set; }
        public int WorkPlaceID { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Age})";
        }
    }
}
