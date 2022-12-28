using System;
using UnityEditor.Rendering;
using UnityEngine;

namespace Encryption.CipherModels
{
    public class AffineCipher : Cipher
    {
        private int _keyA;
        private int _keyB;
        private string _alphabets;
        private int _alphabetsLength;
        private char[] _alphabetsArray;
        
        private char[] _result;
        
        public AffineCipher()
        {
            
        }

        public void SetParameter(string alphabets, int keyA, int keyB)
        {
            _alphabets = alphabets;
            _keyA = keyA;
            _keyB = keyB;

            _alphabetsArray = alphabets.ToCharArray();
            _alphabetsLength = alphabets.Length;
            
        }

        

        private int FindMultiplicativeInverse()
        {
            int aInverse = 0;

            for (int i = 0; i < _alphabetsLength; i++)
            {
                if (((_keyA * i) % _alphabetsLength) == 1)
                {
                    aInverse = i;
                }
            }

            return aInverse;
        }
        private char EncryptChar(char ch)
        {
            int index = _alphabets.IndexOf(ch);
            int resultIndex;
            if (index == -1) return ch;

            resultIndex = ((_keyA * index) + _keyB) % _alphabetsLength;

            return _alphabetsArray[resultIndex];
        }

        private char DecryptChar(char ch, int aInverse)
        {
            int index = _alphabets.IndexOf(ch);
            int resultIndex;
            if (index == -1) return ch;

            if (index - _keyB < 0) index += _alphabetsLength;
                
            resultIndex = (aInverse * (index - _keyB)) % _alphabetsLength;
            
            return _alphabetsArray[resultIndex];
        }

        public string AffineShift(string message, bool isEncrypt)
        {
            int resultIndex = 0;
            char tmpChar;
            int aInverse = 0;
            _result = new char[message.Length+ 1];
            if (!isEncrypt) aInverse = FindMultiplicativeInverse();
            Debug.Log("aInverse = " + aInverse);
            foreach(char ch in message)
            {
                Debug.Log("result "+ resultIndex);
                if (char.IsUpper(ch))
                {
                    tmpChar = char.ToLower(ch);
                    //enc
                    tmpChar =(isEncrypt)? EncryptChar(tmpChar):DecryptChar(tmpChar,aInverse);
                    _result[resultIndex++] = Char.ToUpper(tmpChar);
                }
                else
                {
                    tmpChar = ch;
                    tmpChar =(isEncrypt)? EncryptChar(tmpChar):DecryptChar(tmpChar, aInverse);
                    
                    _result[resultIndex++] = tmpChar;
                }
            }
            return new string(_result);
        }
        public override string Encrypt(string message)
        {
            return AffineShift(message, true);
        }

        public override string Decrypt(string message)
        {
            return AffineShift(message, false);
        }
    }
}