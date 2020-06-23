using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Repositories
{
    public class DwarfRepository : IRepository<IDwarf>
    {
        private readonly List<IDwarf> models = new List<IDwarf>();
        public IReadOnlyCollection<IDwarf> Models => this.models.AsReadOnly();

        public void Add(IDwarf model)
        {
            this.models.Add(model);
        }

        public IDwarf FindByName(string name)
        {
            var firstDwarf = this.models.FirstOrDefault(x => x.Name == name);
            return firstDwarf;
        }

        public bool Remove(IDwarf model)
        {
            return this.models.Remove(model);
        }
    }
}
