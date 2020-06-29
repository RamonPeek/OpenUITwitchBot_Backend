using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class User
    {

        [BsonId]
        public string Id { get; set; }

        [BsonElement("firstname")]
        public string FirstName { get; set; }

        [BsonElement("lastname")]
        public string LastName { get; set; }

        public User() { }

        public User(string id, string firstname, string lastname)
        {
            this.Id = id;
            this.FirstName = firstname;
            this.LastName = lastname;
        }

    }
}
