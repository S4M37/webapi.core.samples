using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.core.welcome.Models;

namespace webapi.core.welcome.Services
{
    interface IRepository
    {
        IEnumerable<Entity> GetAll();
        Entity Get(string Id);
        string Add(Entity entity);
        void Update(Entity entity);
        void Delete(string Id);
    }
}
