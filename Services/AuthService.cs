using Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class AuthService : IAuthService
    {

        private IAuthRepo Repository { get; set; }


        public AuthService(IAuthRepo repository)
        {
            Repository = repository;
        }

        public string Authenticate(Credentials credentials)
        {
            string userId = Repository.Authenticate(credentials);
            if (userId == null)
                return null;
            return userId;
        }

        public bool CreateCredentials(Credentials credentials)
        {
            return Repository.CreateCredentials(credentials);
        }

        public bool DeleteCredentials(Credentials credentials)
        {
            return Repository.DeleteCredentials(credentials);
        }

        public Credentials GetByUserId(string userId)
        {
            return Repository.GetByUserId(userId);
        }
    }
}
