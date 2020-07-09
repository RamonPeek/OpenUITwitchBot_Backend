using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Models.Webhooks;
using Models.Webhooks.Responses;
using OpenUITwitchBot.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenUITwitchBot.Controllers
{

    [Route("api/webhooks/incoming/twitch/subscription")]
    [ApiController]
    public class SubscriptionWebhookController : ControllerBase
    {

        private IHubContext<SubscriptionHub> SubscriptionHub;

        #region NEW_SUBSCRIPTION
        [HttpPost]
        public async Task<IActionResult> HandleReceivedSubscription([FromBody] TwitchResponse<SubscriptionWebhookResponse> response)
        {
            await SubscriptionHub.Clients.User(response.data.ToList()[0].event_data.user_id).SendAsync("SendSubscriptionUpdate", response.data.ToList()[0]);
            return Ok();
        }


        [HttpGet]
        public IActionResult VerifySubscription([FromQuery(Name = "hub.challenge")] string hubChallenge)
        {
            return Ok(hubChallenge);
        }
        #endregion

        public SubscriptionWebhookController(IHubContext<SubscriptionHub> subscriptionHub)
        {
            this.SubscriptionHub = subscriptionHub;
        }

    }
}
