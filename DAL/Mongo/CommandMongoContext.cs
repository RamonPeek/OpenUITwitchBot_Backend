using DAL.Interfaces;
using DAL.Mongo.Connector;
using Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mongo
{
    public class CommandMongoContext : ICommandContext
    {

        private IMongoCollection<Command> CommandCollection = new MongoConnector().Database.GetCollection<Command>("commands");

        public Command Create(Command model)
        {
            CommandCollection.InsertOne(model);
            return model;
        }

        public Command Delete(string id)
        {
            return CommandCollection.FindOneAndDelete(c => c.Id == id);
        }

        public Command GetById(string id)
        {
            return CommandCollection.Find(c => c.Id == id).FirstOrDefault();
        }

        public Command Update(string id, Command model)
        {
            CommandCollection.ReplaceOne(c => c.Id == id, model);
            return model;
        }
    }
}
