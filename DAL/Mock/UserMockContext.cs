using DAL.Interfaces;
using DAL.Mock.Memory;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mock
{
    public class UserMockContext : IUserContext
    {
        public User Create(User model)
        {
            UserMemory.Memory.Add(model);
            return model;
        }

        public User Delete(string id)
        {
            User user = GetById(id);
            if (user != null)
                UserMemory.Memory.Remove(user);
            return user;
        }

        public List<User> GetAll()
        {
            return UserMemory.Memory;
        }

        public User GetById(string id)
        {
            return UserMemory.Memory.Find(u => u.Id == id);
        }

        public User Update(string id, User model)
        {
            Delete(id);
            Create(model);
            return model;
        }
    }
}
