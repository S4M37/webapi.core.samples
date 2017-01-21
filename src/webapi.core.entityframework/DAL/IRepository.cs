using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.core.entityframework.Services
{
    interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> getAll();
        TEntity get(string Id);
        void add(TEntity tEntity);
        void delete(string Id);
        void update(TEntity tEntity);
    }
}
