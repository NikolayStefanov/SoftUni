using System;
using System.Collections.Generic;
using System.Text;

namespace P05_GreedyTimes
{
    public class Gold
    {
        public long Value { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"##Gold - {this.Value}");
            return sb.ToString().TrimEnd();
        }
    }
}
