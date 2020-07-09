using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Webhooks
{
    public interface ITwitchResponse<T>
    {

        public IEnumerable<T> data { get; set; }

    }
}
