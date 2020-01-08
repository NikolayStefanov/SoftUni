namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var classType = Type.GetType("P02_BlackBoxInteger.BlackBoxInteger");
            var methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var constructor = classType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            var classInicialize = (BlackBoxInteger)Activator.CreateInstance(classType, true);
            var input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                var arguments = input.Split('_', StringSplitOptions.RemoveEmptyEntries);
                var targetMethodName = arguments[0];
                var parameter = int.Parse(arguments[1]);
                foreach (var method in methods)
                {
                    if (method.Name == targetMethodName)
                    {
                        method.Invoke(classInicialize , new object[] { parameter});
                        var field = classType.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);
                        Console.WriteLine(field.GetValue(classInicialize));
                    }
                }
            }
        }
    }
}
