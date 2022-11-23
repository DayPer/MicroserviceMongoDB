using ServiceAPILibrary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using APIServiceCard.Core.Entities;

namespace APIServiceCard.Core.ContextMongoDB
{
    public class CardContext : ICardContext
    {
        private readonly IMongoDatabase _db;
        public CardContext(IOptions<MongoSetting> options)
        {
            var _client = new MongoClient(options.Value.ConnecionString);
            _db = _client.GetDatabase(options.Value.DataBase);
        }
        public IMongoCollection<Card> Cards => _db.GetCollection<Card>("Cards");

    }
}
