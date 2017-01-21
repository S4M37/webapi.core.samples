using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.core.mongo.Models;

namespace webapi.core.mongo.DAL
{
    public class GenericRepository : IRepository
    {

        private IMongoCollection<Entity> _collection;
        public GenericRepository(IMongoDatabase _database, string collection)
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
