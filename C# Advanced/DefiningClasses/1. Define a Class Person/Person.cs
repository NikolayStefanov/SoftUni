    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace DefiningClasses
    {
        public class Person
        {
            public Person()
            {
                this.age = 1;
                this.name = "No name";
            }
            public Person(int age) : this()
            {
                this.Age = age;
            }
            public Person(string name, int age)
            {
                this.name = name;
                this.age = age;
            }
            private int age;
            private string name;
            public int Age
            {
                get
                {
                    return age;
                }
                set
                {
                    age = value;
                }
            }
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
        }
    }
