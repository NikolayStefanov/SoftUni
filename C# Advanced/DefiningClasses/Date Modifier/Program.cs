using System;

namespace _5._Date_Modifier_EXE
{
    public class Program
    {
        static void Main(string[] args)
        {
            var firstData = Console.ReadLine();
            var secondData = Console.ReadLine();
            int daysDifference = DataModifier.TimeDifference(firstData, secondData);
            Console.WriteLine(daysDifference);
        }
    }
}
