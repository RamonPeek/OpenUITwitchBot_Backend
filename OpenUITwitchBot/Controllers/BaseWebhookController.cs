using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using Models.Webhooks;
using Services.Interfaces;

namespace OpenUITwitchBot.WebhookReceivers
{

    [Route("api/webhooks")]
    [ApiController]
    public class BaseWebhookController : ControllerBase
    {

        private readonly IHttpClientFactory ClientFactory;
        private readonly string BaseUrl = "https://api.twitch.tv/helix";
        
        private IConfiguration Configuration;

        private IUserService UserService { get; set; }

        [HttpGet("subscribe")]
        public async Task<IActionResult> HandleSubscribe(string callBackUrl, string topicUrl, string oAuthToken)
        {
            ClaimsIdentity identity = User.Identity as ClaimsIdentity;
            string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return Unauthorized("Your session has expired.");
            User user = UserService.GetById(userId);
            if(user == null)
                return NotFound("Your session has expired."); //TODO CREATE BETTER MESSAGE
            HttpRequestMessage request = new HttpRequestMessage(
                HttpMethod.Post,
                this.BaseUrl + "/webhooks/hub");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", oAuthToken);
            request.Headers.Add("Client-Id", Configuration["TWITCH_CLIENT_ID"]);  
            request.Content = new StringContent(
                "{\"hub.callback\":\""+ callBackUrl + "\"," + 
                    "\"hub.mode\":\"subscribe\"," +
                    "\"hub.topic\":\"" + topicUrl + "\"," +
                    "\"hub.lease_seconds\":864000" +
                    //TODO ADD SECRET HERE
                "}", Encoding.UTF8, "application/json");

            var client = ClientFactory.CreateClient();

            var response = await client.SendAsync(request);
            return Ok(response.StatusCode + ":" + response.ReasonPhrase);
        }

        [HttpGet("unsubscribe")]
        public async Task<IActionResult> HandleUnsubscribe(string callBackUrl, string topicUrl, string oAuthToken)
        {
            ClaimsIdentity identity = User.Identity as ClaimsIdentity;
            string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return Unauthorized("Your session has expired.");
            User user = UserService.GetById(userId);
            if (user == null)
                return NotFound("Your session has expired."); //TODO CREATE BETTER MESSAGE
            HttpRequestMessage request = new HttpRequestMessage(
                HttpMethod.Post,
                this.BaseUrl + "/webhooks/hub");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", oAuthToken);
            request.Headers.Add("Client-Id", Configuration["TWITCH_CLIENT_ID"]);
            request.Content = new StringContent(
                "{\"hub.callback\":\"" + callBackUrl + "\"," +
                    "\"hub.mode\":\"unsubscribe\"," +
                    "\"hub.topic\":\"" + topicUrl + "\"," +
                    "\"hub.lease_seconds\":864000" +
                //TODO ADD SECRET HERE
                "}", Encoding.UTF8, "application/json");

            var client = ClientFactory.CreateClient();

            var response = await client.SendAsync(request);
            return Ok(response.StatusCode + ":" + response.ReasonPhrase);
        }

        public BaseWebhookController(IHttpClientFactory clientFactory, IConfiguration configuration, IUserService userService)
        {
            this.ClientFactory = clientFactory;
            this.Configuration = configuration;
            this.UserService = userService;
        }

    }
}