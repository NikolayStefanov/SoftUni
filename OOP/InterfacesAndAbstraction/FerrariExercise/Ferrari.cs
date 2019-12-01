using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Ferrari
{
    public class Ferrari : IDriveable
    {
        private const string model = "488-Spider";
        public Ferrari(string name)
        {
            this.Driver = name;
            this.Model = model;
        }
        public string Model { get; }
        public string Driver { get; private set; }

        public string PushGas()
        {
            return "Gas!";
        }

        public string UseBrake()
        {
            return "Brakes!";
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{this.Model}/{this.UseBrake()}/{this.PushGas()}/{this.Driver}");
            return sb.ToString();
        }
    }
}
