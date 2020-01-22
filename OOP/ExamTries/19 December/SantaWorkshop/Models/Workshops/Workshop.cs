using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Craft(IPresent present, IDwarf dwarf)
        {
            while (!present.IsDone() && dwarf.Energy != 0)
            {
                var currInstrument = dwarf.Instruments.FirstOrDefault(x => !(x.IsBroken()));
                if (currInstrument != null && !currInstrument.IsBroken())
                {
                    dwarf.Work();
                    currInstrument.Use();
                    present.GetCrafted();
                }
                else
                {
                    break;
                }
            }
        }
    }
}
