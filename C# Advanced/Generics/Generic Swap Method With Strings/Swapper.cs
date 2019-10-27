using System;
using System.Collections.Generic;
using System.Text;

namespace _3.GenericSwapMethodStrings
{
    public class Swapper<T>
    {
        private List<T> theList;

        public Swapper(List<T> list)
        {
            this.TheList = new List<T>();
            this.TheList = list;
        }
        public List<T> TheList
        {
            get { return theList; }
            set { theList = value; }
        }
        public void SwapIndexes(int firstIndex, int secondIndex)
        {
            if (firstIndex >=0 && firstIndex < theList.Count && secondIndex >= 0 && secondIndex < theList.Count && firstIndex != secondIndex)
            {
                var firstValue = TheList[firstIndex];
                TheList[firstIndex] = TheList[secondIndex];
                TheList[secondIndex] = firstValue;
            }
        }

    }
}
