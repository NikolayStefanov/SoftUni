using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Repositories
{
    public class PresentRepository : IRepository<IPresent>
    {
        private List<IPresent> models = new List<IPresent>();
        public IReadOnlyCollection<IPresent> Models => this.models.AsReadOnly();

        public void Add(IPresent model)
        {
            this.models.Add(model);
        }

        public IPresent FindByName(string name)
        {
            var targetPresent = models.FirstOrDefault(x => x.Name == name);
            return targetPresent;
        }

        public bool Remove(IPresent model)
        {
            return this.models.Remove(model);
        }
    }
}
