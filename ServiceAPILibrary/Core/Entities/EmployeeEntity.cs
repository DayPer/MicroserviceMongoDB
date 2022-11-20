using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAPILibrary.Core.Entities 
{
    [BsonCollection("Employee")]
    public class EmployeeEntity : Document
    {
        [BsonElement("Name")]
        public string Name { get; set; }
    }
}
