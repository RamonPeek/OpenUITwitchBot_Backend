﻿using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interfaces
{
    public interface IAuthRepo
    {
        string Authenticate(Credentials credentials);
        bool CreateCredentials(Credentials credentials);
        Credentials GetByUserId(string userId);
        bool DeleteCredentials(Credentials credentials);
    }
}
