using APIServiceTest.Core.Entities;
using FluentValidation;
using MongoDB.Bson.Serialization.Attributes;
using ServiceAPILibrary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIServiceTest.Core.Entities
{
    [BsonCollection("User")]
    public class UserEntity : Document
    {
       
        [BsonElement("Name")]
        public String Name { get; set; }

        [BsonElement("LastName")]
        public String LastName { get; set; }

        [BsonElement("Username")]
        public string Username { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Pass")]
        public string Pass { get; set; }

    }

    public class userRegisterValidation : AbstractValidator<UserEntity>
    {
        public userRegisterValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Pass).NotEmpty();
        }

    }
}
