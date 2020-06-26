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
            if (GetById(model.Id) != null) return null;
            return Repository.Create(model);
        }

        public Command Delete(int id)
        {
            if (GetById(id) == null) return null;
            return Repository.Delete(id);
        }

        public Command GetById(int id)
        {
            return Repository.GetById(id);
        }

        public Command Update(int id, Command model)
        {
            if (GetById(id) == null) return null;
            return Repository.Update(id, model);
        }
    }
}
