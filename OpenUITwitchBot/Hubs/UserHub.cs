using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Models;
using Models.Webhooks.Responses;
using System;

using System.Threading.Tasks;

namespace OpenUITwitchBot.Hubs
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserHub : Hub
    {
    }
}
