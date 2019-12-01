using System;
using System.Collections.Generic;
using System.Text;

namespace _6.BirthdayCelebrations
{
    public class Robot
    {
        public Robot(string model, string id)
        {
            this.Name = model;
            this.ID = id;
        }

        public string Name { get; set; }
        public string ID { get; set; }
    }
}
