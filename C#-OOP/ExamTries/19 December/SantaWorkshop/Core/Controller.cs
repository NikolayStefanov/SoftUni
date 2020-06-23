using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private DwarfRepository dwarfs = new DwarfRepository();
        private PresentRepository presents = new PresentRepository();
        private int craftedPresents = 0;
        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf currDwarf = null;
            if (dwarfType == "HappyDwarf")
            {
                currDwarf = new HappyDwarf(dwarfName);
            }
            else if (dwarfType == "SleepyDwarf")
            {
                currDwarf = new SleepyDwarf(dwarfName);
            }
            else 
            {
                throw new InvalidOperationException("Invalid dwarf type.");
            }
            dwarfs.Add(currDwarf);
            return $"Successfully added {dwarfType} named {dwarfName}.";
            
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            IInstrument currInstrument = new Instrument(power);
            var targetDwarf = dwarfs.FindByName(dwarfName);
            if (targetDwarf == null)
            {
                throw new InvalidOperationException("The dwarf you want to add an instrument to doesn't exist!");
            }
            targetDwarf.AddInstrument(currInstrument);
            return $"Successfully added instrument with power {power} to dwarf {dwarfName}!";
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            var currPresent = new Present(presentName, energyRequired);
            presents.Add(currPresent);
            return $"Successfully added Present: {presentName}!";
        }

        public string CraftPresent(string presentName)
        {
            var workShop = new Workshop();
            var targetPresent = presents.FindByName(presentName);
            var availableDwarfs = dwarfs.Models.Where(x => x.Energy >= 50).OrderByDescending(x=> x.Energy);
            if (availableDwarfs.Count() == 0)
            {
                throw new InvalidOperationException("There is no dwarf ready to start crafting!");
            }

            foreach (var dwarf in availableDwarfs)
            {
                workShop.Craft(targetPresent, dwarf);
                if (dwarf.Energy == 0)
                {
                    dwarfs.Remove(dwarf);
                }
                if (targetPresent.IsDone())
                {
                    craftedPresents++;
                    break;
                }
                
            }            

            var isDone = "not done";
            if (targetPresent.IsDone())
            {
                isDone = "done";
            }
            return $"Present {presentName} is {isDone}.";
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{craftedPresents} presents are done!");
            sb.AppendLine($"Dwarfs info:");
            foreach (var dwarf in dwarfs.Models)
            {
                sb.AppendLine($"Name: {dwarf.Name}");
                sb.AppendLine($"Energy: {dwarf.Energy}");
                sb.AppendLine($"Instruments: {dwarf.Instruments.Where(x=> !x.IsBroken()).Count()} not broken left");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
