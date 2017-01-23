using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.core.entityframework.DbModels;

namespace webapi.core.entityframework.DAL
{
    public class UnitOfWork : IDisposable
    {
        private DbWebApiContext dataAccessProvider;

        private GenericRepository<Business> businessRepository;
        private GenericRepository<Category> categoryRepository;


        public UnitOfWork(DbWebApiContext dataAccessProvider)
        {
            this.dataAccessProvider = dataAccessProvider;
        }
        public GenericRepository<Business> BusinessRepository
        {
            get
            {

                if (this.businessRepository == null)
                {
                    this.businessRepository = new GenericRepository<Business>(dataAccessProvider);
                }
                return this.businessRepository;
            }
        }

        public GenericRepository<Category> CategoryRepository
        {
            get
            {

                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new GenericRepository<Category>(dataAccessProvider);
                }
                return this.categoryRepository;
            }
        }

        public void Save()
        {
            dataAccessProvider.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dataAccessProvider.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

