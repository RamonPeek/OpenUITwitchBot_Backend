using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mongo.Connector
{
    public class MongoConnector
    {

        public IMongoDatabase Database { get; set; }

        public MongoConnector()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            this.Database = client.GetDatabase("openuitwitchbot");
        }

        

    }
}
