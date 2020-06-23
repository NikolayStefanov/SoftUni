using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {

        public string Read(string args)
        {
            var arguments = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var commandName = (arguments[0] + "command").ToLower();
            arguments = arguments.Skip(1).ToArray();
            var targetClass = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(n => n.Name.ToLower() == commandName);
            if (targetClass == null)
            {
                throw new ArgumentException("Invalid type name!");
            }
            var instance = Activator.CreateInstance(targetClass) as ICommand;
            if (instance == null)
            {
                throw new ArgumentException("Invalid type name!");
            }
            var res =instance.Execute(arguments);
            return res;
        }
    }
}
