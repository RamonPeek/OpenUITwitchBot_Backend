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
    public class AuthFactory : IFactory<IAuthService>
    {
        public IAuthService Create()
        {
            return new AuthService(new AuthRepo(new AuthMockContext()));
        }
    }
}
