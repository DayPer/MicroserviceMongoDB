using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIServiceTest.Core.Entities;
using MongoDB.Driver;
using ServiceAPILibrary.Core.Entities;


namespace APIServiceTest.Core.ContextMongoDB
{
    public interface IUserContext
    {
        IMongoCollection<User> Users { get; }
    }
}
