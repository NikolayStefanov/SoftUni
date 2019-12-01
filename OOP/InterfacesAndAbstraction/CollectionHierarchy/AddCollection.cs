using System.Collections.Generic;

namespace _9.CollectionHierarchy
{
    public class AddCollection : IAddable
    {
        public AddCollection()
        {
            this.Collection = new List<string>();
        }
        protected List<string> Collection { get; private set; }

        public virtual int Add(string word)
        {
            this.Collection.Add(word);
            return this.Collection.Count - 1;
        }
    }
}
