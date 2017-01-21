using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.core.mongo.Models;

namespace webapi.core.mongo.DAL
{
    public class GenericRepository<Entity> : IRepository<Entity>
    {

        private IMongoCollection<Entity> _collection;
        private IMongoDatabase _database;

        public GenericRepository(IMongoDatabase _database, string collectionName)
        {
            this._collection = _database.GetCollection<Entity>(collectionName);
        }      

        public IEnumerable<Entity> GetAll()
        {
            return _collection.Find("{}").ToList();
        }
        public Entity Get(string Id)
        {
            List<Entity> businesses = _collection.Find(new BsonDocument("_id", Id)).ToList();
            return businesses.FirstOrDefault();
        }

        public void Add(Entity entity)
        {
            _collection.InsertOneAsync(entity);
        }

        public void Update(Entity entity)
        {
            //_collection.ReplaceOne(x => x.Id == entity.Id, entity);
        }


        public void Delete(string Id)
        {
            _collection.DeleteOne(Id);
        }
        
    }
}
