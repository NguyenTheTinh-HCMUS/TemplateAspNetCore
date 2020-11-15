using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web1.Options;

namespace Web1.Helpers
{
    public class Hash
    {
        private readonly SaltPassword _saltPass;
        public  Hash(SaltPassword salt)
        {
            _saltPass = salt;
        }
        public  string Create(string value)
        {
            var valueBytes = KeyDerivation.Pbkdf2(
                                password: value,
                                salt: Encoding.UTF8.GetBytes(_saltPass.salt),
                                prf: KeyDerivationPrf.HMACSHA512,
                                iterationCount: 10000,
                                numBytesRequested: 256 / 8);

            return Convert.ToBase64String(valueBytes);
        }

        public  bool Validate(string value, string hash)
            => Create(value) == hash;
    }
}
