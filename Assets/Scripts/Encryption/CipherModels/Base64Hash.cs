using System;
using System.Buffers.Text;

namespace Encryption.CipherModels
{
    public class Base64Hash:Cipher
    {
        public override string Encrypt(string message)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(message));
        }

        public override string Decrypt(string message)
        {
            return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(message));
        }
    }
}