using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter commandInterpreterCtor)
        {
            this.commandInterpreter = commandInterpreterCtor;
        }
        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine();
                var result = commandInterpreter.Read(input);
                Console.WriteLine(result);
            }

        }
    }
}
