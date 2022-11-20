using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAPILibrary.Core.Entities
{
    [BsonCollection("Autor")]
    public class AutorEntity: Document
    {
        [BsonElement("Name")]
        public String Name { get; set; }

        [BsonElement("LastName")]
        public String LastName { get; set; }

        [BsonElement("Profession")]
        public String Profession { get; set; }
    }
}
