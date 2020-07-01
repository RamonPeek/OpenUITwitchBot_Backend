using DAL.Interfaces;
using DAL.Mongo.Connector;
using Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mongo
{
    public class UserMongoContext : IUserContext
    {

        private IMongoCollection<User> UserCollection = new MongoConnector().Database.GetCollection<User>("users");

        public User Create(User model)
        {
            UserCollection.InsertOne(model);
            return model;
        }

        public User Delete(string id)
        {
            return UserCollection.FindOneAndDelete(u => u.Id == id);
        }

        public List<User> GetAll()
        {
            return UserCollection.AsQueryable().ToList();
        }

        public User GetById(string id)
        {
            return UserCollection.Find(u => u.Id == id).FirstOrDefault();
        }

        public User Update(string id, User model)
        {
            UserCollection.ReplaceOne(u => u.Id == id, model);
            return model;
        }
    }
}
