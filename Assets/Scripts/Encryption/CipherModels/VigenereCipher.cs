using UnityEngine;

namespace Encryption.CipherModels
{
    public class VigenereCipher : Cipher
    {
        private string _key;
        private int _keyIndex;
        private char[] _keyArray;
        private string _alphabets;
        private char[] _alphabetsArray;
        // private int _alphabetsLength;
        private char[] _result;
        public VigenereCipher()
        {
            
        }
        public void SetParameter(string alphabets, string key)
        {
            _alphabets = alphabets;
            _key = key;
            _alphabetsArray = _alphabets.ToCharArray();
            // _alphabetsLength = _alphabetsArray.Length;
            // _shift = shift;
            // _result = new char[_alphabetsLength] ;
        }
        private char Cipher(char ch, bool isEncrypt)
        {
            int index = _alphabets.IndexOf(ch);
            if (index == -1) return ch;
            
            int keyIndexOnAlphabets = _alphabets.IndexOf((_keyArray[_keyIndex++]));
            // Debug.Log("Alphabtes Index = "+ index + " key index = "+ keyIndexOnAlphabets);
            int newIndex = 0;
            
            if(isEncrypt) newIndex = ((index + keyIndexOnAlphabets)+_alphabets.Length)% _alphabets.Length;
            else newIndex = ((index - keyIndexOnAlphabets)+_alphabets.Length) % _alphabets.Length;
            
            _keyIndex = _keyIndex % _key.Length;
            // Debug.Log("New Index = "+newIndex);
            return _alphabetsArray[newIndex];
        }
        private string VigenereShift(string message, bool isEncrypt)
        {
            _result = new char[message.Length+1];
            Debug.Log(_key);
            _keyArray = _key.ToCharArray();
            _keyIndex = 0;
            int resultIndex = 0;
            
            foreach (char ch in message)
            {
                if (char.IsUpper(ch))
                {
                    char tmp = char.ToLower(ch);
                    _result[resultIndex++] = char.ToUpper(Cipher(tmp, isEncrypt));
                }
                else _result[resultIndex++] = Cipher(ch, isEncrypt);
            }
            return new string(_result);
        }
        public override string Encrypt(string message)
        {
            return VigenereShift(message, true);
        }

        public override string Decrypt(string message)
        {
            return VigenereShift(message, false);
        }
    }
}