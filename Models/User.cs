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

        [BsonElement("twitch_account")]
        public TwitchAccount TwitchAccount { get; set; }

        public User() { }

        public User(string id, TwitchAccount twitchAccount)
        {
            this.Id = id;
            this.TwitchAccount = twitchAccount;
        }

    }
}
