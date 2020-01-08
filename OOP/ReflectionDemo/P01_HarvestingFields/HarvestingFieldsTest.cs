namespace P01_HarvestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type targetType = typeof(HarvestingFields);
            var input = string.Empty;
            while ((input = Console.ReadLine()) != "HARVEST")
            {
                PrintTargetMembers(input, targetType);
            }
        }

        private static void PrintTargetMembers(string input, Type targetType)
        {
            IEnumerable<FieldInfo> targetFields;
            switch (input.ToLower())
            {
                case "protected":
                    targetFields = targetType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(x => x.IsFamily);
                    foreach (var field in targetFields)
                    {
                        Console.WriteLine($"{input} {field.FieldType.Name} {field.Name}");
                    }
                    break;
                case "private":
                    targetFields = targetType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(x => x.IsPrivate);
                    foreach (var field in targetFields)
                    {
                        Console.WriteLine($"{input} {field.FieldType.Name} {field.Name}");
                    }
                    break;
                case "public":
                    targetFields = targetType.GetFields(BindingFlags.Instance | BindingFlags.Public);
                    foreach (var field in targetFields)
                    {
                        Console.WriteLine($"{input} {field.FieldType.Name} {field.Name}");
                    }
                    break;
                case "all":
                    targetFields = targetType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
                    foreach (var field in targetFields)
                    {
                        if (field.IsPrivate)
                        {
                            Console.WriteLine($"private {field.FieldType.Name} {field.Name}");
                        }
                        else if (field.IsPublic)
                        {
                            Console.WriteLine($"public {field.FieldType.Name} {field.Name}");
                        }
                        else
                        {
                            Console.WriteLine($"protected {field.FieldType.Name} {field.Name}");
                        }
                    }
                    break;
            }
        }
    }
}
