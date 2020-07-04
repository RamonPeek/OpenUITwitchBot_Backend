using Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class UserService : IUserService
    {

        private IUserRepo Repository { get; set; }

        public UserService(IUserRepo repository)
        {
            Repository = repository;
        }

        public User Create(User model, Credentials credentials)
        {
            model.Id = Guid.NewGuid().ToString();
            User createdUser = Repository.Create(model);
            if (createdUser == null)
                return null;
            return createdUser;
        }

        public User Delete(string id)
        {
            User deletedUser = Repository.Delete(id);
            if(deletedUser == null)
                return null;
            return deletedUser;
        }

        public List<User> GetAll()
        {
            return Repository.GetAll();
        }

        public User GetById(string id)
        {
            return Repository.GetById(id);
        }

        public User Update(string id, User model)
        {
            return Repository.Update(id, model);
        }
    }
}
