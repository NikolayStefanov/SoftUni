using System;
using System.Collections.Generic;

namespace _9.CollectionHierarchy
{
    public class RemoveAddCollection : AddCollection, IAddable, IRemoveabe
    {
        public override int Add(string word)
        {
            this.Collection.Insert(0, word);
            return 0;
        }
        public virtual string Remove()
        {
            var lastIndex = this.Collection.Count - 1;
            var lastWord = this.Collection[lastIndex];
            this.Collection.RemoveAt(lastIndex);
            return lastWord;
        }
    }
}
