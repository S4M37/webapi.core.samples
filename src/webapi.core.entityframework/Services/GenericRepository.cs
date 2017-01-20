using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.core.entityframework.DBProviders;

namespace webapi.core.entityframework.Services
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        DBBusinessContext dataAccessProvider;

        public GenericRepository(DBBusinessContext dataAccessProvider)
        {
            this.dataAccessProvider = dataAccessProvider;
        }

        public IEnumerable<TEntity> getAll()
        {
            throw new NotImplementedException();
        }

        public void add(TEntity tEntity)
        {
            throw new NotImplementedException();
        }

        public void delete(string Id)
        {
            throw new NotImplementedException();
        }

        public TEntity get(string Id)
        {
            throw new NotImplementedException();
        }

        public void update(TEntity tEntity)
        {
            throw new NotImplementedException();
        }
    }
}
