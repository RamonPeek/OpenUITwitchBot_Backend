using DAL.Interfaces;
using DAL.Mongo.Connector;
using Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mongo
{
    public class AuthMongoContext : IAuthContext
    {

        private IMongoCollection<Credentials> CredentialsCollection = new MongoConnector().Database.GetCollection<Credentials>("credentials");

        public string Authenticate(Credentials credentials)
        {
            foreach(Credentials storedCredentials in CredentialsCollection.AsQueryable().ToList())
            {
                if(storedCredentials.Email.Equals(credentials.Email, StringComparison.InvariantCultureIgnoreCase) &&
                   storedCredentials.Password.Equals(credentials.Password))
                {
                    return storedCredentials.UserId;
                }
            }
            return null;
        }

        public bool CreateCredentials(Credentials credentials)
        {
            CredentialsCollection.InsertOne(credentials);
            return CredentialsCollection.Find(c => c.UserId == credentials.UserId) != null;
        }

        public bool DeleteCredentials(Credentials credentials)
        {
            CredentialsCollection.FindOneAndDelete(c => c.UserId == credentials.UserId);
            return CredentialsCollection.Find(c => c.UserId == credentials.UserId) == null;
        }

        public Credentials GetByUserId(string userId)
        {
            return CredentialsCollection.Find(c => c.UserId == userId).FirstOrDefault();
        }
    }
}
