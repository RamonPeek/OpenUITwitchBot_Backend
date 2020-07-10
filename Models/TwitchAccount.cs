using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class TwitchAccount
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement("display_name")]
        public string DisplayName { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("profile_image_url")]
        public string ProfileImageUrl { get; set; }

        [BsonElement("view_count")]
        public int ViewCount { get; set; }

        public TwitchAccount() { }

        public TwitchAccount(string id, string displayName, string description, string profileImageUrl, int viewCount)
        {
            this.Id = id;
            this.DisplayName = displayName;
            this.Description = description;
            this.ProfileImageUrl = profileImageUrl;
            this.ViewCount = viewCount;
        }
    }
}
