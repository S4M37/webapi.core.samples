using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.core.mongo.DAL
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        private IMongoCollection<TEntity> _collection;
        private IMongoDatabase _database;

        public GenericRepository(IMongoDatabase _database, string collectionName)
        {
            this._collection = _database.GetCollection<TEntity>(collectionName);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _collection.Find("{}").ToList();
        }
        public TEntity Get(string Id)
        {
            List<TEntity> businesses = _collection.Find(new BsonDocument("_id", Id)).ToList();
            return businesses.FirstOrDefault();
        }

        public void Add(TEntity entity)
        {
            _collection.InsertOneAsync(entity);
        }

        public void Update(TEntity entity)
        {
            //_collection.ReplaceOne(x => x.Id == entity.Id, entity);
        }


        public void Delete(string Id)
        {
            _collection.DeleteOne(Id);
        }

    }
}
