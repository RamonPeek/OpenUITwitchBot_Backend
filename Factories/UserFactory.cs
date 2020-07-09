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
    public class UserFactory : IFactory<IUserService>
    {
        public IUserService Create()
        {
            //return new UserService(new UserRepo(new UserMockContext()));
            return new UserService(new UserRepo(new UserMongoContext()));
        }
    }
}
