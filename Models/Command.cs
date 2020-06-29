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

        [BsonElement("tag")]
        public string Tag { get; set; }

        [BsonElement("type")]
        public CommandType Type { get; set; }

        [BsonElement("content")]
        public string Content { get; set; }

        public Command() {}

        public Command(string id, string tag, CommandType type, string content)
        {
            this.Id = id;
            this.Tag = tag;
            this.Type = type;
            this.Content = content;
        }
    }
}
