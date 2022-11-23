﻿using MongoDB.Bson.Serialization.Attributes;
using ServiceAPILibrary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIServiceCard.Core.Entities
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
