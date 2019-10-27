using System;
using System.Collections.Generic;
using System.Text;

namespace _1._Generic_Box_of_String
{
    public class Box<T>
    {
        private T value;

        public Box(T value)
        {
            this.Value = value;
        }
        public T Value
        {
            get { return value; }
            set { this.value = value; }
        }
        public override string ToString()
        {
            var type = Value.GetType();
            var result = $"{type}: {Value}";
            return result;
        }
    }
}
