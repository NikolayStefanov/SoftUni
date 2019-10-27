using System;
using System.Collections.Generic;
using System.Text;

namespace _5.GenericCountMethodStrings
{
    public class Comparer<T>
        where T : IComparable
    {
        private List<T> list;
        private T element;
        public Comparer(List<T> theList,  T element)
        {
            this.List = theList;
            this.element = element;

        }
        public List<T> List
        {
            get { return list; }
            set { list = value; }
        }

        public int LargerElementsByComparedElement()
        {
            var count = 0;
            foreach (var item in List)
            {
                if (item.CompareTo(element) > 0)
                {
                    count++;
                }
            }
            return count;
        }

    }
}
