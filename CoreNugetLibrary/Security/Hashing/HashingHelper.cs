using System;
using System.Security.Cryptography;
using System.Text;

namespace Kernel.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public HashingHelper()
        {
        }

        /// <summary>
        /// hash üretir
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passHash"></param>
        /// <param name="passSalt"></param>
       public static void CreatePasswordHash(string password,out byte[] passHash,out byte[] passSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA256())
            {
                passSalt = hmac.Key;
                passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        /// <summary>
        /// parola doğruluğu kontrolü yapılır
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passSalt"></param>
        /// <param name="passHash"></param>
        /// <returns></returns>
        public static bool VerifyPassword(string password, byte[] passSalt, byte[] passHash)
        {
            using(var hmac = new HMACSHA256(passSalt))
            {
                var passByte = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < passHash.Length; i++)
                {
                    if(passHash[i] != passByte[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// general hash
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetEncryptedHash(string value)
        {
            string hshstr = "";

            using (var hmac = new System.Security.Cryptography.HMACSHA256())
            {
                hshstr = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(value)));
            }
            return hshstr;
        }
    }
}
