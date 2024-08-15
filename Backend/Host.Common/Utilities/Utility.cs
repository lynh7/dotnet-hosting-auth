using Host.Common.Constants;
using Konscious.Security.Cryptography;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Host.Common.Utilities
{
    public static class Utility
    {
        public static async Task<bool> IsValidPasscode(string passcode)
        {
            if (string.IsNullOrWhiteSpace(passcode)) throw new ValidationException("Passcode can't be empty");
            if (passcode.Length < 12) throw new ValidationException("Passcode must be at least 12 characters");

            var regex = new Regex(GlobalConstants.REGEX_PASSCODE);
            if (!regex.IsMatch(passcode)) throw new ValidationException("Passcode Invalid, must be 1 upper, 1 lower, 1 symbol, 1 number");

            return true;
        }

        /// <summary>
        /// Every passcode should have their own salt.
        /// </summary>
        /// <returns></returns>
        public static byte[] CreateSalt()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }

        /// <summary>
        /// Hash password using Argon2, the Winner of the Password Hashing Competition (PHC). 
        /// </summary>
        /// <param name="password">input password string</param>
        /// <param name="storedSalt">input stored salt</param>
        /// <returns></returns>
        public static byte[] HashPassword(string password, string storedSalt)
        {
            byte[] salt = Convert.FromBase64String(storedSalt.Split(':')[0]);

            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 8; // four cores
            argon2.Iterations = 4;
            argon2.MemorySize = 1024 * 8; // 0.0078125 GB
            var result = argon2.GetBytes(16);

            return result;
        }

        public static bool VerifyPassword(byte[] orgPassword, string passwordString, string storedHash)
        {
            byte[] salt = Convert.FromBase64String(storedHash.Split(':')[0]);
            var hashPassword = HashPassword(passwordString, storedHash);

            return hashPassword.SequenceEqual(orgPassword);
        }
    }
}
