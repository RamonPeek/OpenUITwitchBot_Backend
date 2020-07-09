using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Webhooks
{
    public class TwitchResponse<T> : ITwitchResponse<T>
    {

        public IEnumerable<T> data { get; set; }

        public TwitchResponse() { }

        public TwitchResponse(IEnumerable<T> data)
        {
            this.data = data;
        }

    }
}
