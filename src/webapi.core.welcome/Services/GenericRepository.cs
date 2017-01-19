using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.core.welcome.Services
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity:class
    {
        private IAdapterConnector iAdapterConnector;

        public GenericRepository(IAdapterConnector iAdapterConnector)
        {
            this.iAdapterConnector = iAdapterConnector;
        }

        public string Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Attach(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(string Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

    }
}
