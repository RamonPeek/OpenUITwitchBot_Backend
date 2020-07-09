using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Models.Webhooks;
using Models.Webhooks.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenUITwitchBot.Hubs;
using static OpenUITwitchBot.Hubs.UserHub;

namespace OpenUITwitchBot.WebhookReceivers
{

    [Route("api/webhooks/incoming/twitch/user")]
    [ApiController]
    public class UserWebhookController : ControllerBase
    {

        private IHubContext<UserHub> UserHub;

        #region NEW_FOLLOWER
        [HttpPost]
        public async Task<IActionResult> HandleReceivedFollow([FromBody] TwitchResponse<UserWebhookResponse> response)
        {
            await UserHub.Clients.User(response.data.ToList()[0].to_id).SendAsync("SendUserUpdate", response.data.ToList()[0]);
            return Ok();
        }


        [HttpGet]
        public IActionResult VerifySubscription([FromQuery(Name = "hub.challenge")] string hubChallenge)
        {
            return Ok(hubChallenge);
        }
        #endregion

        public UserWebhookController(IHubContext<UserHub> userHub)
        {
            this.UserHub = userHub;
        }

    }
}