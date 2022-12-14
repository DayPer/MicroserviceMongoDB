using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIServiceTest.Core.Entities;
using MongoDB.Driver;


namespace APIServiceTest.Core.ContextMongoDB
{
    public interface ICardContext
    {
        IMongoCollection<Card> Cards { get; }
    }
}
