using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    using Core.Entities;
    using Core.Entities.Concrete;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Customer : Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }   
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}