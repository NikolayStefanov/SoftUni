using MXGP.Models.Motorcycles;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Repositories.Contracts
{
    public class MotorcycleRepository : Repository<Motorcycle>
    {
        public override Motorcycle GetByName(string name)
        {
            var targetMotor = this.Data.Find(x => x.Model == name);
            return targetMotor;
        }
    }
}
