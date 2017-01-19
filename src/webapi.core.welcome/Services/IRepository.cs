using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.core.welcome.Models;

namespace webapi.core.welcome.Services
{
    interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(string Id);
        string Add(TEntity entity);
        void Attach(TEntity entity);
        void Delete(string Id);
    }
}
