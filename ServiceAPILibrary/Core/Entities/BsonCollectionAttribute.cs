using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAPILibrary.Core.Entities
{
    [AttributeUsage(AttributeTargets.Class, Inherited =false)]
    public class BsonCollectionAttribute : Attribute
    {
        public string CollectionName { get; }
        public BsonCollectionAttribute(string _collectionName)
        {
            CollectionName = _collectionName;
        }
    }
}
