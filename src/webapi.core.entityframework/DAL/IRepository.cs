using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.core.entityframework.DAL
{
    interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> getAll();
        TEntity get(string Id);
        EntityEntry<TEntity> add(TEntity tEntity);
        void delete(string Id);
        void update(TEntity tEntity);
    }
}
