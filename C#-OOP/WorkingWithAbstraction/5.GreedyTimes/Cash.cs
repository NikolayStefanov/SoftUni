using System;
using System.Collections.Generic;
using System.Text;

namespace P05_GreedyTimes
{
    public class Cash
    {
        public Cash(string name, long value)
        {
            this.Name = name;
            this.Value = value;
        }
        public string Name { get; set; }
        public long  Value { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"##{this.Name} - {this.Value}");
            return sb.ToString().TrimEnd();
        }
    }
}
