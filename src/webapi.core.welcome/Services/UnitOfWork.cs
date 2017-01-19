using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.core.welcome.Models;
using webapi.core.welcome.Services;

namespace webapi.core.welcome.Services
{
    public class UnitOfWork : IDisposable
    {
        private IAdapterConnector iAdaperConnector;

        private GenericRepository<Business> businessRepository;

        public GenericRepository<Business> BusinessRepository
        {
            get
            {

                if (this.businessRepository == null)
                {
                    this.businessRepository = new GenericRepository<Business>(iAdaperConnector);
                }
                return businessRepository;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // dispose the AdapterConnector                    
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
