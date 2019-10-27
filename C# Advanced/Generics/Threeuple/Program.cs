using System;

namespace Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            var nameAdressTownInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var theName = nameAdressTownInput[0] + " " + nameAdressTownInput[1];
            var theAdress = nameAdressTownInput[2];
            var theTown = string.Empty;
            for (int i = 3; i < nameAdressTownInput.Length; i++)
            {
                theTown += nameAdressTownInput[i] + " ";
            }
            var threeupleForNameAdressTown = new Tuple<string, string, string>(theName, theAdress, theTown);

            var nameLitersDrunkInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var theName2 = nameLitersDrunkInput[0];
            var theLiters =int.Parse(nameLitersDrunkInput[1]);
            var drunkOrNot = string.Empty;
            if (nameLitersDrunkInput[2] == "drunk")
            {
                drunkOrNot = "True";
            }
            else
            {
                drunkOrNot = "False";
            }
            var threeupleForNameLitersDrunk = new Tuple<string, int, string>(theName2, theLiters, drunkOrNot);

            var nameBankBalanceBankName = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            var theName3 = nameBankBalanceBankName[0];
            var bankBalance = double.Parse(nameBankBalanceBankName[1]);
            var bankName = nameBankBalanceBankName[2];
            var threupleForNameBankBalanceBankName = new Tuple<string, double, string>(theName3, bankBalance, bankName);

            Console.WriteLine($"{threeupleForNameAdressTown.Item1} -> {threeupleForNameAdressTown.Item2} -> {threeupleForNameAdressTown.Item3}");
            Console.WriteLine($"{threeupleForNameLitersDrunk.Item1} -> {threeupleForNameLitersDrunk.Item2} -> {threeupleForNameLitersDrunk.Item3}");
            Console.WriteLine($"{threupleForNameBankBalanceBankName.Item1} -> {threupleForNameBankBalanceBankName.Item2} -> {threupleForNameBankBalanceBankName.Item3}");

        }
    }
}
