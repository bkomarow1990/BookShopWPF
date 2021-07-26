using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WorkServices.Encryption
{
    public class EncryptionService
    {
        static string BaseConvert(string number, int fromBase, int toBase)
        {
            var digits = "0123456789abcdefghijklmnopqrstuvwxyz";
            var length = number.Length;
            var result = string.Empty;

            var nibbles = number.Select(c => digits.IndexOf(c)).ToList();
            int newlen;
            do
            {
                var value = 0;
                newlen = 0;

                for (var i = 0; i < length; ++i)
                {
                    value = value * fromBase + nibbles[i];
                    if (value >= toBase)
                    {
                        if (newlen == nibbles.Count)
                        {
                            nibbles.Add(0);
                        }
                        nibbles[newlen++] = value / toBase;
                        value %= toBase;
                    }
                    else if (newlen > 0)
                    {
                        if (newlen == nibbles.Count)
                        {
                            nibbles.Add(0);
                        }
                        nibbles[newlen++] = 0;
                    }
                }
                length = newlen;
                result = digits[value] + result; //
            }
            while (newlen != 0);

            return result;
        }
        //public static string ComputeSHA256Hash(string text) {
        //    byte[] salt = new byte[32];
        //    System.Security.Cryptography.RNGCryptoServiceProvider.Create().GetBytes(salt);
        //    // Convert the plain string pwd into bytes
        //    byte[] plainTextBytes = System.Text.UnicodeEncoding.Unicode.GetBytes(text);
        //    // Append salt to pwd before hashing
        //    byte[] combinedBytes = new byte[plainTextBytes.Length + salt.Length];
        //    System.Buffer.BlockCopy(plainTextBytes, 0, combinedBytes, 0, plainTextBytes.Length);
        //    System.Buffer.BlockCopy(salt, 0, combinedBytes, plainTextBytes.Length, salt.Length);
        //    // Create hash for the pwd+salt
        //    System.Security.Cryptography.HashAlgorithm hashAlgo = new System.Security.Cryptography.SHA256Managed();
        //    byte[] hash = hashAlgo.ComputeHash(combinedBytes);
        //    // Append the salt to the hash
        //    byte[] hashPlusSalt = new byte[hash.Length + salt.Length];
        //    System.Buffer.BlockCopy(hash, 0, hashPlusSalt, 0, hash.Length);
        //    System.Buffer.BlockCopy(salt, 0, hashPlusSalt, hash.Length, salt.Length);
        //    return Convert.ToBase64String(hashPlusSalt);
        //}
        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
