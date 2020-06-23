using System;
using System.Collections.Generic;
using System.Text;

namespace _5.BorderControl
{
    public class Robot : IFakable
    {
        public Robot(string model, string id)
        {
            this.Name = model;
            this.ID = id;
        }

        public string Name { get ; set ; }
        public string ID { get; set; }
    }
}
