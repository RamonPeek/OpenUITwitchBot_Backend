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
                UserId = "shddgsagd",
                Email = "mock0@admin.nl",
                Password = "Admin123!",
                Salt = "abcdefghijkl"
            });
            data.Add(new Credentials()
            {
                UserId = "sdasgfdsg",
                Email = "mock1@admin.nl",
                Password = "Admin123!",
                Salt = "abcdefghijkl"
            });
            data.Add(new Credentials()
            {
                UserId = "bvcbvcbbc",
                Email = "mock2@admin.nl",
                Password = "Admin123!",
                Salt = "abcdefghijkl"
            });
            data.Add(new Credentials()
            {
                UserId = "gsfsfdsff",
                Email = "mock3@admin.nl",
                Password = "Admin123!",
                Salt = "abcdefghijkl"
            });
            Memory = data;
        }

    }
}
