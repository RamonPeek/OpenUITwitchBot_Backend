using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Combined
{
    public class UserWithCredentials
    {

        public UserWithCredentials() { }

        public User User { get; set; }
        public Credentials Credentials { get; set; }

        public UserWithCredentials(User user, Credentials credentials)
        {
            User = user;
            Credentials = credentials;
        }

    }
}
