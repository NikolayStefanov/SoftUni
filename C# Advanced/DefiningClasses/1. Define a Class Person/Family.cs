using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people = new List<Person>();


        public void AddMember(Person member)
        {
            people.Add(member);
        }
        public Person GetTheOldestPerson()
        {
            int index = 0;
            int oldest = int.MinValue;
            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].Age > oldest)
                {
                    oldest = people[i].Age;
                    index = i;
                }
            }
            return people[index];
        }


    }
}
