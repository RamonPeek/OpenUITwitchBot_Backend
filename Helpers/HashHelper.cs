using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Helpers
{
    public class HashHelper
    {
     
        public static string GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }
        
        public static string Hash(String input, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            string hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: input,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hash;
        }

    }
}
