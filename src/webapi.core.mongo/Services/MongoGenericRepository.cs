using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.core.welcome.Models;

namespace webapi.core.welcome.Services
{
    public class GenericRepository : IRepository
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        private IMongoCollection<Entity> _collection;
        private const string ConnectionString = "mongodb://localhost:27017";

        static GenericRepository()
        {
            _client = new MongoClient(ConnectionString);
            _database = _client.GetDatabase("test");
        }

        public GenericRepository(string collection)
        {
            _collection = _database.GetCollection<Entity>(collection);
        }
        public IEnumerable<Entity> GetAll()
        {
            return _collection.Find("{}").ToList();
        }
        public Entity Get(string Id)
        {
            List<Entity> businesses = _collection.Find(x => x.Id == Id).ToList();
            return businesses.FirstOrDefault();
        }

        public string Add(Entity entity)
        {
            string id = Guid.NewGuid().ToString();
            entity.Id = id;
            _collection.InsertOneAsync(entity);
            return id;
        }

        public void Update(Entity entity)
        {
            _collection.ReplaceOne(x => x.Id == entity.Id, entity);
        }


        public void Delete(string Id)
        {
            _collection.DeleteOne(x => x.Id == Id);
        }
       
    }
}
