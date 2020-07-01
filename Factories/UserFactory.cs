using DAL.Mock;
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
            return new UserService(new UserRepo(new UserMockContext()));
        }
    }
}
