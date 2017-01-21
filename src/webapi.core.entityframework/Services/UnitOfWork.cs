using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.core.entityframework.DBProviders;
using webapi.core.welcome.Models;

namespace webapi.core.entityframework.Services
{
    public class UnitOfWork : IDisposable
    {
        private DbWebApiContext dataAccessProvider;

        private GenericRepository<Business> businessRepository;


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

