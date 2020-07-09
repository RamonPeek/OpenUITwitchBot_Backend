using Microsoft.AspNetCore.SignalR;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenUITwitchBot.Hubs
{
    public class NameUserIdProvider : IUserIdProvider
    {

        private IUserService UserService;

        public string GetUserId(HubConnectionContext connection)
        {
            string userId = connection.User?.Identity?.Name;
            User user = UserService.GetById(userId);
            return user.TwitchAccount.Id;
        }

        public NameUserIdProvider(IUserService userService)
        {
            this.UserService = userService;
        }

    }
}
