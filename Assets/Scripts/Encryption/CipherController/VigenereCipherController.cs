using Encryption.CipherModels;
using TMPro;
using UnityEngine;

namespace Encryption.CipherController
{
    public class VigenereCipherController:CipherController
    {
        private string _key;
        private string _alphabets;
        private GameObject _alphabetsObj;
        private GameObject _keyObj;

        public VigenereCipherController(GameObject keyObj, GameObject alphabetsObj) : base()
        {
            _alphabetsObj = alphabetsObj;
            _keyObj = keyObj;
            this.Cipher = new VigenereCipher();
        }

        public override void UpdateValues()
        {
            _key = _keyObj.GetComponentInChildren<TMP_InputField>().text;
            _alphabets = _alphabetsObj.GetComponentInChildren<TMP_InputField>().text;
            
            ((VigenereCipher)this.Cipher).SetParameter(_alphabets, _key);
        }
    }
}