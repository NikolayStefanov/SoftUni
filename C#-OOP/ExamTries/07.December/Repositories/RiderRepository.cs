using MXGP.Models.Riders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Repositories
{
    public class RiderRepository : Repository<Rider>
    {
        public override Rider GetByName(string name)
        {
            var targetRider = this.Data.Find(x => x.Name == name);
            return targetRider;
        }

    }
}
