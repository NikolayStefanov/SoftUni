using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        public Repository()
        {
            this.Data = new List<T>();
        }
        protected List<T> Data { get; set; }
        public void Add(T model)
        {
            this.Data.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return this.Data.AsReadOnly();
        }

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
            this.Data.Remove(model);
            return true;
        }
    }
}
