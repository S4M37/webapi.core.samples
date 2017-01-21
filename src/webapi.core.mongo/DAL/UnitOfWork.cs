using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.core.mongo.Models;

namespace webapi.core.mongo.DAL
{
    public class UnitOfWork : IDisposable
    {
        protected IMongoClient _client;
        protected IMongoDatabase _database;
        private const string ConnectionString = "mongodb://localhost:27017";

        private const string BusinessIndice = "businesses";

        static UnitOfWork()
        {

        }
        public UnitOfWork()
        {
            _client = new MongoClient(ConnectionString);
            _database = _client.GetDatabase("test");
        }

        private GenericRepository<Business> businessRepository;

        public GenericRepository<Business> BusinessRepository
        {
            get
            {

                if (this.businessRepository == null)
                {
                    this.businessRepository = new GenericRepository<Business>(_database, BusinessIndice);
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
