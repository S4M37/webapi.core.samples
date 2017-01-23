using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.core.entityframework.DAL
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal DbWebApiContext dataAccessProvider;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(DbWebApiContext dataAccessProvider)
        {
            this.dataAccessProvider = dataAccessProvider;
            dbSet = dataAccessProvider.Set<TEntity>();
        }

        public IEnumerable<TEntity> getAll()
        {
            IQueryable<TEntity> query = dbSet;
            return query.ToList();
        }

        public EntityEntry<TEntity> add(TEntity tEntity)
        {
            var entity = dbSet.Add(tEntity);
            dataAccessProvider.SaveChanges();
            return entity;
        }

        public void delete(string Id)
        {
            TEntity entityToDelete = dbSet.Find(Id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (dataAccessProvider.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }


        public TEntity get(string Id)
        {
            return dbSet.Find(Id);
        }

        public void update(TEntity tEntity)
        {
            dbSet.Update(tEntity);
            dataAccessProvider.Update(tEntity).State = EntityState.Modified;
            dataAccessProvider.SaveChanges();
        }
    }
}
