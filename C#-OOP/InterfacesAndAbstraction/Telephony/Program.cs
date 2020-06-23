using System;

namespace _4.Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            var smartPhone = new Smartphone();
            var callInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var browseInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < callInput.Length; i++)
            {
                Console.WriteLine(smartPhone.Calling(callInput[i]));
            }
            for (int i = 0; i < browseInput.Length; i++)
            {
                Console.WriteLine(smartPhone.Browsing(browseInput[i]));
            }
        }
    }
}
