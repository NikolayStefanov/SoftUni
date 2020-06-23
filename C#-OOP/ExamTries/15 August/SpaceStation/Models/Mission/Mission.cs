using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {

            foreach (var astronaut in astronauts)
            {
                List<string> items = planet.Items.ToList();

                while (astronaut.CanBreath && items.Count > 0)
                {
                    var firstItem = items.First();
                    astronaut.Breath();
                    astronaut.Bag.Items.Add(firstItem);                    
                    items.Remove(firstItem);
                    planet.Items.Remove(firstItem);
                    if (!astronaut.CanBreath)
                    {
                        continue;
                    }
                }
            }
        }
    }
}
