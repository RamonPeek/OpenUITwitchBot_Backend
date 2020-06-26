using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Command
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement("text")]
        public string Text { get; set; }

        public Command() {}

        public Command(string id, string text)
        {
            this.Id = id;
            this.Text = text;
        }
    }
}
