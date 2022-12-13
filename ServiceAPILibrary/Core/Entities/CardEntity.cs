using FluentValidation;
using MongoDB.Bson.Serialization.Attributes;
using ServiceAPILibrary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIServiceTest.Core.Entities
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

    public class cardRegisterValidation : AbstractValidator<CardEntity>
    {
        public cardRegisterValidation()
        {
            RuleFor(x => x.Headline).NotEmpty();
            RuleFor(x => x.CardNumber).NotEmpty();
            RuleFor(x => x.ExpirationDay).NotEmpty();
            RuleFor(x => x.CW).NotEmpty();
        }

    }
}
