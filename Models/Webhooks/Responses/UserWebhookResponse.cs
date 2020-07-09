using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Webhooks.Responses
{
    public class UserWebhookResponse
    {

        public string from_id { get; set; }
        public string from_name { get; set; }
        public string to_id { get; set; }
        public string to_name { get; set; }
        public string followed_at { get; set; }

        public UserWebhookResponse() { }

        public UserWebhookResponse(string from_id, string from_name, string to_id, string to_name, string followed_at)
        {
            this.from_id = from_id;
            this.from_name = from_name;
            this.to_id = to_id;
            this.to_name = to_name;
            this.followed_at = followed_at;
        }

    }
}
