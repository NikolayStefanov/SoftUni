using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const double cubicSm = 125;
        private const int minHP = 50;
        private const int maxHP = 69;
        private int horsePower;
        public SpeedMotorcycle(string model, int horsePower) : base(model, horsePower, cubicSm)
        {
            this.HorsePower = horsePower;
        }
        public override int HorsePower 
        { 
            get => this.horsePower;
            protected set 
            {
                if (value < minHP || value > maxHP)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                this.horsePower = value;
            }
        }
    }
}
