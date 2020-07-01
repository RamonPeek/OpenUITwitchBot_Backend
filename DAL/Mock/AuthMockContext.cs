using DAL.Interfaces;
using DAL.Mock.Memory;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mock
{
    public class AuthMockContext : IAuthContext
    {
        public string Authenticate(Credentials credentials)
        {
            foreach(Credentials storedCredentials in AuthMemory.Memory)
            {
                if (storedCredentials.Email.ToLower() == credentials.Email.ToLower() &&
                    storedCredentials.Password == credentials.Password)
                {
                    return storedCredentials.UserId;
                }
            }
            return null;
        }

        public bool CreateCredentials(Credentials credentials)
        {
            AuthMemory.Memory.Add(credentials);
            return AuthMemory.Memory.Find(c => c.UserId == credentials.UserId) != null;
        }

        public bool DeleteCredentials(Credentials credentials)
        {
            Credentials foundCredentials = AuthMemory.Memory.Find(c => c.UserId == credentials.UserId);
            if (foundCredentials == null)
                return false;
            AuthMemory.Memory.Remove(foundCredentials);
            return AuthMemory.Memory.Find(c => c.UserId == credentials.UserId) == null;
        }

        public Credentials GetByUserId(string userId)
        {
            return AuthMemory.Memory.Find(c => c.UserId == userId);
        }
    }
}
