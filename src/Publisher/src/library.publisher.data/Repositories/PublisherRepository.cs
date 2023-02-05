using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Library.Publisher.Data.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Library.Publisher.Data.Repositories
{
    [ExcludeFromCodeCoverage]
    public class PublisherRepository : IPublisherRepository
    {
        private readonly string _collectionName = "Publisher";
        private readonly IMongoDatabase _database;

        public PublisherRepository(IMongoClient client)
        {
            _database = client.GetDatabase("LibraryOS");
        }

        public void Delete(string id)
        {
            var collection = _database.GetCollection<EPublisher>(_collectionName);

            collection.DeleteOneAsync(x => x.Id.Equals(id));
        }

        public void Update(EPublisher entity)
        {
            var collection = _database.GetCollection<EPublisher>(_collectionName);

            collection.ReplaceOneAsync(x => x.Id.Equals(entity.Id), entity, new UpdateOptions
                                                                            {
                                                                                IsUpsert = true
                                                                            });
        }

        public void Insert(EPublisher entity)
        {
            var collection = _database.GetCollection<EPublisher>(_collectionName);

            collection.InsertOne(entity);
        }

        public IEnumerable<EPublisher> SelectAll()
        {
            return _database.GetCollection<EPublisher>(_collectionName).Find(new BsonDocument()).ToListAsync()
                .Result;
        }

        public EPublisher Select(string id)
        {
            return _database.GetCollection<EPublisher>(_collectionName).Find(x => x.Id.Equals(id))
                .FirstOrDefaultAsync().Result;
        }
    }
}