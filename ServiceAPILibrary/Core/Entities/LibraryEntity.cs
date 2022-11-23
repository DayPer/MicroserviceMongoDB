using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAPILibrary.Core.Entities
{
    [BsonCollection("Library")]
    public class LibraryEntity: Document
    {
        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Price")]
        public int Price { get; set; }

        [BsonElement("PublicationDate")]
        public DateTime? PublicationDate { get; set; }

        [BsonElement("Autor")]
        public AutorEntity Autor { get; set; }
    }
}
