using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Raw_Data_exe
{
    public class Engine
    {
        public Engine(int speed, int power)
        {
            this.EngineSpeed = speed;
            this.EnginePower = power;
        }
        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }
    }
}
