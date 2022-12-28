using System;
using System.Text;
using UnityEngine;

public class CaesarCipher : Cipher
{
    private string _alphabets;

    private char[] _alphabetsArray = new char[] { };
    private int _alphabetsLength;
    private char[] _result;
    private int _shift;

    public CaesarCipher()
    {
    }

    public string Alphabets
    {
        get => _alphabets;
        set => _alphabets = value;
    }

    public int Shift
    {
        get => _shift;
        set => _shift = value;
    }

    public void SetParameter(string alphabets, int shift)
    {
        _alphabets = alphabets;
        _alphabetsArray = _alphabets.ToCharArray();
        _alphabetsLength = _alphabetsArray.Length;
        _shift = shift;
       
    }
    private char Cipher(char ch)
    {
        
        int index = _alphabets.IndexOf(ch);
        if (index == -1) return ch;
        
        index = (((index + _shift)% _alphabetsLength) + _alphabetsLength) % _alphabetsLength;
        return _alphabetsArray[index];
    }
    private string CaesarShift(string message, bool isEncrypt)
    {
        _result = new char[message.Length+1] ;
        if (!isEncrypt) _shift = -_shift;
        char tmpShiftChar;
        int resultIndex = 0;
        foreach (char ch in message)
        {
            if (char.IsUpper(ch))
            {
                tmpShiftChar = char.ToLower(ch);
                _result[resultIndex++] = char.ToUpper(Cipher(tmpShiftChar));
            }
            else
            {
                _result[resultIndex++] = Cipher(ch);
            }
            // Debug.Log("Result = "+_result[resultIndex-1] + "ascii = " + (int)_result[resultIndex-1]);
        }
        return new String(_result);
    }
    public override string Encrypt(string message)
    {
        return CaesarShift(message,true);
    }
    public override string Decrypt(string message)
    {
        return CaesarShift(message,false);
    }
}