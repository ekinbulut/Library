using System;
using System.Diagnostics.CodeAnalysis;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Library.Publisher.Data.Entities
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class EPublisher
    {
        public EPublisher()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }

        [BsonId] public string Id { get; set; }

        public string    Name           { get; set; }
        public string[]  Series         { get; set; }
        public DateTime  CreateDateTime { get; set; } = DateTime.Now;
        public DateTime? UpdateDateTime { get; set; }
    }
}