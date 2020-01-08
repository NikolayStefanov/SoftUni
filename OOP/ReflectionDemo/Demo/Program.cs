using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var catConstructor = typeof(Cat).GetMethods();
            foreach (var method in catConstructor)
            {
                if (!method.IsSpecialName && method.DeclaringType == typeof(Cat))
                {
                    Console.WriteLine(method.Name);
                }
            }
        }
    }
}
