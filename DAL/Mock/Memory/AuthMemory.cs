using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mock.Memory
{
    public class AuthMemory
    {
        public static List<Credentials> Memory { get; }

        static AuthMemory()
        {
            List<Credentials> data = new List<Credentials>();
            data.Add(new Credentials()
            {
                UserId = UserMemory.Memory[0].Id,
                Email = "mock0@admin.nl",
                Password = "Admin123!"
            });
            data.Add(new Credentials()
            {
                UserId = UserMemory.Memory[1].Id,
                Email = "mock1@admin.nl",
                Password = "Admin123!"
            });
            data.Add(new Credentials()
            {
                UserId = UserMemory.Memory[2].Id,
                Email = "mock2@admin.nl",
                Password = "Admin123!"
            });
            data.Add(new Credentials()
            {
                UserId = UserMemory.Memory[3].Id,
                Email = "mock3@admin.nl",
                Password = "Admin123!"
            });
            Memory = data;
        }

    }
}
