using System.Buffers.Text;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Encryption.CipherModels
{
    public class Base32Hash :Cipher
    {
        private char[] _alphabets;
        private int _mask;
        private int _shift;
        private Dictionary<char, int> _charMap = new Dictionary<char, int>();
        private string _separator = "-";

        public Base32Hash()
        {
            _alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567".ToCharArray();
            _mask = _alphabets.Length - 1;
            _shift = CountTrailingZeros(_alphabets.Length);
            for (int i = 0; i < _alphabets.Length; i++) _charMap[_alphabets[i]] = i;
        }
        
        private int CountTrailingZeros(int i) {
            int y;
            if (i == 0) return 32;
            
            int n = 31;
            y = i << 16; if (y != 0) { n = n - 16; i = y; }
            y = i << 8; if (y != 0) { n = n - 8; i = y; }
            y = i << 4; if (y != 0) { n = n - 4; i = y; }
            y = i << 2; if (y != 0) { n = n - 2; i = y; }
            
            return n - (int)((uint)(i << 1) >> 31);
        }
        
        private string Encode(byte[] data) {
            if (data.Length == 0) return "";
            if (data.Length >= (1 << 28)) {
                return "Error Input Not Valid";
            }
            
            int outputLength = (data.Length * 8 + _shift - 1) / _shift;
            StringBuilder result = new StringBuilder(outputLength);

            int buffer = data[0];
            int next = 1;
            int bitsLeft = 8;
            
            while (bitsLeft > 0 || next < data.Length) {
                if (bitsLeft < _shift) {
                    if (next < data.Length) {
                        buffer <<= 8;
                        buffer |= (data[next++] & 0xff);
                        bitsLeft += 8;
                    } else {
                        int pad = _shift - bitsLeft;
                        buffer <<= pad;
                        bitsLeft += pad;
                    }
                }
                int index = _mask & (buffer >> (bitsLeft - _shift));
                bitsLeft -= _shift;
                result.Append(_alphabets[index]);
            }
            //padding output
            int padding = 8 - (result.Length % 8);
            if (padding > 0) result.Append(new string('=', padding == 8 ? 0 : padding));
            
            return result.ToString();
        }
        private byte[] Decode(string encoded) {
            encoded = encoded.Trim().Replace(_separator, "");

            encoded = Regex.Replace(encoded, "[=]*$", "");

            encoded = encoded.ToUpper();
            if (encoded.Length == 0) {
                return new byte[0];
            }
            int encodedLength = encoded.Length;
            int outLength = encodedLength * _shift / 8;
            byte[] result = new byte[outLength];
            int buffer = 0;
            int next = 0;
            int bitsLeft = 0;
            foreach (char c in encoded.ToCharArray()) {
                if (!_charMap.ContainsKey(c)) {
                    
                }
                buffer <<= _shift;
                buffer |= _charMap[c] & _mask;
                bitsLeft += _shift;
                if (bitsLeft >= 8) {
                    result[next++] = (byte)(buffer >> (bitsLeft - 8));
                    bitsLeft -= 8;
                }
            }
            // We'll ignore leftover bits for now.
            //
            // if (next != outLength || bitsLeft >= SHIFT) {
            //  throw new DecodingException("Bits left: " + bitsLeft);
            // }
            return result;
        }
        public override string Encrypt(string message)
        {
            return Encode(Encoding.ASCII.GetBytes(message));
         
        }

        public override string Decrypt(string message)
        {
            return System.Text.Encoding.UTF8.GetString(Decode(message));
        }
    }
}
