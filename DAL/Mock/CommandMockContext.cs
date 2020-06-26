using DAL.Interfaces;
using DAL.Mock.Memory;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mock
{
    public class CommandMockContext : ICommandContext
    {

        public Command Create(Command model)
        {
            CommandMemory.Memory.Add(model);
            return model;
        }

        public Command Delete(int id)
        {
            Command command = GetById(id);
            CommandMemory.Memory.Remove(command);
            return command;
        }

        public Command GetById(int id)
        {
            return CommandMemory.Memory.Find(c => c.Id == id);
        }

        public Command Update(int id, Command model)
        {
            Delete(id);
            Create(model);
            return model;
        }
    }
}
