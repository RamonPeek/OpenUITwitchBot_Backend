using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Webhooks.Responses
{
    public class StreamWebhookResponse
    {

        public string id { get; set; }
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string game_id { get; set; }
        public List<String> community_ids { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public int viewer_count { get; set; }
        public string started_at { get; set; }
        public string language { get; set; }
        public string thumbnail_url { get; set; }

        public StreamWebhookResponse() {}

        public StreamWebhookResponse(string id, string user_id, string user_name, string game_id, List<String> community_ids, string type, string title, int viewer_count, string started_at, string language, string thumbnail_url)
        {
            this.id = id;
            this.user_id = user_id;
            this.user_name = user_name;
            this.game_id = game_id;
            this.community_ids = community_ids;
            this.type = type;
            this.title = title;
            this.viewer_count = viewer_count;
            this.started_at = started_at;
            this.language = language;
            this.thumbnail_url = thumbnail_url;
        }

    }
}
