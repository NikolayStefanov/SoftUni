using MXGP.Models.Races;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Repositories
{
    public class RaceRepository : Repository<Race>
    {
        public override Race GetByName(string name)
        {
            var targetRace = this.Data.Find(x => x.Name == name);
            return targetRace;
        }
    }
}
