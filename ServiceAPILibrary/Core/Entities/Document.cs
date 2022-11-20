using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAPILibrary.Core.Entities
{
    public class Document : IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        //public ObjectId id { get; set; }
        public string id { get; set; }

        //public DateTime CreateDate => id.CreationTime;
        public DateTime CreateDate => DateTime.Now;
    }
}
