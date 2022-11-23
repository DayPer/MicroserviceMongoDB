using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIServiceCard.Core.Entities;
using MongoDB.Driver;
using ServiceAPILibrary.Core.Entities;


namespace APIServiceCard.Core.ContextMongoDB
{
    public interface ICardContext
    {
        IMongoCollection<Card> Cards { get; }
    }
}
