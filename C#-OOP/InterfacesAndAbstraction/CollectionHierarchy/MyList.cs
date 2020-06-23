using System;

namespace _9.CollectionHierarchy
{
    public class MyList : RemoveAddCollection
    {
        public int Used { get => this.Collection.Count; }
        public override string Remove()
        {
            var targetWord = this.Collection[0];
            this.Collection.RemoveAt(0);
            return targetWord;
        }
    }
}
