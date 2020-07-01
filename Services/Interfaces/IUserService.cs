using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IUserService
    {
        User Create(User model, Credentials credentials);
        User GetById(string id);
        User Update(string id, User model);
        User Delete(string id);
        List<User> GetAll();
    }
}
