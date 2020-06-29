using DAL.Interfaces;
using Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class CommandRepo : ICommandRepo
    {

        private ICommandContext Context { get; set; }

        public CommandRepo(ICommandContext context)
        {
            Context = context;
        }

        public Command Create(Command model)
        {
            return Context.Create(model);
        }

        public Command Delete(string id)
        {
            return Context.Delete(id);
        }

        public Command GetById(string id)
        {
            return Context.GetById(id);
        }

        public Command Update(string id, Command model)
        {
            return Context.Update(id, model);
        }

        public List<Command> GetAll()
        {
            return Context.GetAll();
        }
    }
}
