using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mongo
{
    public class CommandMongoContext : ICommandContext
    {
        public Command Create(Command model)
        {
            throw new NotImplementedException();
        }

        public Command Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Command GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Command Update(int id, Command model)
        {
            throw new NotImplementedException();
        }
    }
}
