using DAL.Interfaces;
using Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class UserRepo : IUserRepo
    {

        private IUserContext Context { get; set; }


        public UserRepo(IUserContext context)
        {
            Context = context;
        }

        public User Create(User model)
        {
            return Context.Create(model);
        }

        public User Delete(string id)
        {
            return Context.Delete(id);
        }

        public List<User> GetAll()
        {
            return Context.GetAll();
        }

        public User GetById(string id)
        {
            return Context.GetById(id);
        }

        public User Update(string id, User model)
        {
            return Context.Update(id, model);
        }
    }
}
