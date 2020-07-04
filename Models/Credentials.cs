using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Credentials
    {

        [BsonId]
        public string UserId { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }
        
        [BsonElement("salt")]
        public string Salt { get; set; }

        public Credentials() { }

        public Credentials(string userId, string email, string password, string salt)
        {
            this.UserId = userId;
            this.Email = email;
            this.Password = password;
            this.Salt = salt;
        }

    }
}
