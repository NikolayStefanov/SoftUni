using DefiningClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                var inputNameAndAge = Console.ReadLine().Split();
                var name = inputNameAndAge[0];
                var age = int.Parse(inputNameAndAge[1]);
                var person = new Person(name, age);
                people.Add(person);
            }
            foreach (Person person in people.Where(x=> x.Age > 30).OrderBy(x=>x.Name))
            {
                Console.WriteLine(person.Name + " - " + person.Age);
            }
        }
    }
}
