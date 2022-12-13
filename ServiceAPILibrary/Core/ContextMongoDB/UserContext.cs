using ServiceAPILibrary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using APIServiceTest.Core.Entities;
using APIServiceTest.Core.ContextMongoDB;

namespace APIServiceTest.Core.ContextMongoDB
{
    public class UserContext : IUserContext
    {
        private readonly IMongoDatabase _db;
        public UserContext(IOptions<MongoSetting> options)
        {
            var _client = new MongoClient(options.Value.ConnecionString);
            _db = _client.GetDatabase(options.Value.DataBase);
        }
        public IMongoCollection<User> Users => _db.GetCollection<User>("Users");

    }
}
