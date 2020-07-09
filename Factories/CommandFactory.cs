using DAL.Mock;
using DAL.Mongo;
using Factories.Generic;
using Repositories;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Factories
{
    public class CommandFactory : IFactory<ICommandService>
    {

        public ICommandService Create()
        {
            //return new CommandService(new CommandRepo(new CommandMockContext()));
            return new CommandService(new CommandRepo(new CommandMongoContext()));
        }
    }
}
