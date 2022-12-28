
using UnityEngine;

namespace Encryption.CipherController
{
    public abstract class CipherController
    {
        protected Cipher Cipher;

        protected CipherController()
        {

        }

        
        public abstract void UpdateValues();

        public string Encrypt(string input)
        { 
            return  Cipher.Encrypt(input);
        }

        public string Decrypt(string input)
        {
            return Cipher.Decrypt(input);
        }
        
    }
}