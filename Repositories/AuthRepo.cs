using DAL.Interfaces;
using Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class AuthRepo : IAuthRepo
    {
        private IAuthContext Context { get; set; }

        public AuthRepo(IAuthContext context)
        {
            Context = context;
        }

        public string Authenticate(Credentials credentials)
        {
            return Context.Authenticate(credentials);
        }

        public bool CreateCredentials(Credentials credentials)
        {
            return Context.CreateCredentials(credentials);
        }

        public bool DeleteCredentials(Credentials credentials)
        {
            return Context.DeleteCredentials(credentials);
        }

        public Credentials GetByUserId(string userId)
        {
            return Context.GetByUserId(userId);
        }
    }
}
