using System;

namespace Person
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var person = new Child(name, age);

            Console.WriteLine(person.ToString());
        }
    }
}
