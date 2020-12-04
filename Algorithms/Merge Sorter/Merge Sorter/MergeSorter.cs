namespace Merge_Sorter
{
    using System.Collections.Generic;
    using System.Linq;

    public static class MergeSorter
    {
        public static void MakeMergeSort(int[] numbers)
        {
            var result = MergeSort(numbers);
            for (int i = 0; i < result.Length; i++)
            {
                numbers[i] = result[i];
            }
        }

        private static int[] MergeSort(int[] numbers)
        {
            if (numbers.Length <= 1) return numbers; //base case

            var leftPart = new List<int>();
            var rightPart = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i < numbers.Length/2) 
                    AddNumberToPartArray(leftPart, numbers[i]);
                else 
                    AddNumberToPartArray(rightPart, numbers[i]);
            }

            leftPart = MergeSort(leftPart.ToArray()).ToList();
            rightPart = MergeSort(rightPart.ToArray()).ToList();

            return Merge(leftPart, rightPart);
        }

        private static int[] Merge(List<int> leftPart, List<int> rightPart)
        {
            var result = new List<int>();

            while (leftPart.Any() &&  rightPart.Any())
            {
                if (leftPart.First() <= rightPart.First())
                    AddNumberToResultAndDeleteFirstElement(result, leftPart);
                else
                    AddNumberToResultAndDeleteFirstElement(result, rightPart);
            }

            while (leftPart.Any())
            {
                AddNumberToResultAndDeleteFirstElement(result, leftPart);
            }
            while (rightPart.Any())
            {
                AddNumberToResultAndDeleteFirstElement(result, rightPart);
            }
            return result.ToArray();
        }

        private static void AddNumberToResultAndDeleteFirstElement(List<int> result, List<int> partArray)
        {
            result.Add(partArray.First());
            partArray.RemoveAt(0);
        }
        private static void AddNumberToPartArray(List<int> partArray, int number)
        {
            partArray.Add(number);
        }
    }
}
