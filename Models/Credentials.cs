using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Credentials
    {

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        public Credentials() { }

        public Credentials(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

    }
}
