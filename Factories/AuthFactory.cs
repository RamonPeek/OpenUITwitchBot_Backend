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
    public class AuthFactory : IFactory<IAuthService>
    {
        public IAuthService Create()
        {
            //return new AuthService(new AuthRepo(new AuthMockContext()));
            return new AuthService(new AuthRepo(new AuthMongoContext()));
        }
    }
}
