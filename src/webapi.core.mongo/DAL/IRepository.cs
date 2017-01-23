using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.core.mongo.DAL
{
    interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(string Id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(string Id);
    }
}
