namespace Merge_Sorter
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var numbersToMergeSort = Console.ReadLine().Split(new char[] { ' ' }).Select(int.Parse).ToArray();

            MergeSorter.MakeMergeSort(numbersToMergeSort);
            Console.WriteLine(string.Join("->", numbersToMergeSort));
        }
    }
}
