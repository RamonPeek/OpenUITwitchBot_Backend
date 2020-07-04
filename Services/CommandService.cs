using Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class CommandService : ICommandService
    {

        private ICommandRepo Repository { get; set; }

        public CommandService(ICommandRepo repository)
        {
            Repository = repository;
        }

        public Command Create(Command model)
        {
            model.Id = Guid.NewGuid().ToString();
            if (GetById(model.Id.ToString()) != null)
                return null;
            return Repository.Create(model);
        }

        public Command Delete(string id)
        {
            if (GetById(id) == null) return null;
            return Repository.Delete(id);
        }

        public Command GetById(string id)
        {
            return Repository.GetById(id);
        }

        public Command Update(string id, Command model)
        {
            if (GetById(id) == null) return null;
            if (model.Id.ToString() != id) return null;
            return Repository.Update(id, model);
        }

        public List<Command> GetAll()
        {
            return Repository.GetAll();
        }
    }
}
