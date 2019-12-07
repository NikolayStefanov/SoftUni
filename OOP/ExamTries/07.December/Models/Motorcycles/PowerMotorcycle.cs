using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private const double cubicSm = 450;
        private const int minHP = 70;
        private const int maxHP = 100;
        private int horsePower;
        public PowerMotorcycle(string model, int horsePower) : base(model, horsePower, cubicSm)
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
