using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAPILibrary.Core.Entities
{
    [BsonCollection("Card")]
    public class CardEntity : Document
    {
        [BsonElement("Headline")]
        public String Headline { get; set; }

        [BsonElement("CardNumber")]
        public String CardNumber { get; set; }

        [BsonElement("ExpirationDay")]
        public string ExpirationDay { get; set; }

        [BsonElement("CW")]
        public string CW { get; set; }

    }
}
