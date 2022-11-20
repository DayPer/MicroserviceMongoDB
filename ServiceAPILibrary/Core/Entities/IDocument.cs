using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAPILibrary.Core.Entities
{
    public interface IDocument
    {
        [BsonId]
        //[BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        //ObjectId id { get; set; }
        string id { get; set; }
        DateTime CreateDate { get; }

    }
}
