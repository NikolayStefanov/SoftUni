namespace _03BarracksFactory.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using P03_BarraksWars.Core.CommandsRepo;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // TODO: refactor for Problem 4
        private string InterpredCommand(string[] data, string commandName)
        {
            Type targetType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name.ToLower() == commandName);
            var instance = (Command)Activator.CreateInstance(targetType, new object[] { data, this.repository, this.unitFactory });
            var targetMethod = targetType.GetMethod("Execute");
            string result = (string)targetMethod.Invoke(instance, null);
            return result;            
        }
    }
}
