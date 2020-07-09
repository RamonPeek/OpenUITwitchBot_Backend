using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Webhooks.Responses
{
    public class SubscriptionWebhookResponse
    {

        public string id { get; set; }
        public string event_type { get; set; }
        public string event_timestamp { get; set; }
        public string version { get; set; }
        public SubscriptionEventData event_data { get; set; }

        public SubscriptionWebhookResponse() {}

        public SubscriptionWebhookResponse(string id, string event_type, string event_timestamp, string version, SubscriptionEventData event_data)
        {
            this.id = id;
            this.event_type = event_type;
            this.event_timestamp = event_timestamp;
            this.version = version;
            this.event_data = event_data;
        }

        public class SubscriptionEventData
        {
            public string broadcaster_id { get; set; }
            public string broadcaster_name { get; set; }
            public bool is_gift { get; set; }
            public string plan_name { get; set; }
            public string tier { get; set; }
            public string user_id { get; set; }
            public string user_name { get; set; }
            public string gifter_id { get; set; }
            public string gifter_name { get; set; }

            public SubscriptionEventData() {}

            public SubscriptionEventData(string broadcaster_id, string broadcaster_name, bool is_gift, string plan_name, string tier, string user_id, string user_name, string gifter_id, string gifter_name)
            {
                this.broadcaster_id = broadcaster_id;
                this.broadcaster_name = broadcaster_name;
                this.is_gift = is_gift;
                this.plan_name = plan_name;
                this.tier = tier;
                this.user_id = user_id;
                this.user_name = user_name;
                this.gifter_id = gifter_id;
                this.gifter_name = gifter_name;
            }
        }
    }


}
