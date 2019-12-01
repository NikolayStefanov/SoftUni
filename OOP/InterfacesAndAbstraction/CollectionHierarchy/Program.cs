using System;

namespace _9.CollectionHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            var addCollect = new AddCollection();
            var removeAddCollect = new RemoveAddCollection();
            var myList = new MyList();
            var inputStrings = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < 3; i++)
            {
                for (int s = 0; s < inputStrings.Length; s++)
                {
                    switch (i)
                    {
                        case 0:
                            Console.Write(addCollect.Add(inputStrings[s]) + " ");
                            break;
                        case 1:
                            Console.Write(removeAddCollect.Add(inputStrings[s]) + " ");
                            break;
                        case 2:
                            Console.Write(myList.Add(inputStrings[s]) + " ");
                            break;
                    }
                }
                Console.WriteLine();
            }
            var countOfRemoves = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfRemoves; i++)
            {
                Console.Write(removeAddCollect.Remove()+ " ");
            }
            Console.WriteLine();
            for (int i = 0; i < countOfRemoves; i++)
            {
                Console.Write(myList.Remove()+ " ");
            }
        }
    }
}
