using Encryption.CipherModels;
using TMPro;
using UnityEngine;

namespace Encryption.CipherController
{
    public class AffineCipherController : CipherController
    {
        private GameObject _alphabetsObj;
        private GameObject _keyAObj;
        private GameObject _keyBObj;
        
        public AffineCipherController(GameObject keyAObj, GameObject keyBObj, GameObject alphabets)
        {
            _alphabetsObj = alphabets;
            _keyAObj = keyAObj;
            _keyBObj = keyBObj;
            
            this.Cipher = new AffineCipher();
        }
        public override void UpdateValues()
        {
            string alphabets = _alphabetsObj.GetComponentInChildren<TMP_InputField>().text;
            int keyA = int.Parse(_keyAObj.GetComponentInChildren<TMP_InputField>().text);
            int keyB = int.Parse(_keyBObj.GetComponentInChildren<TMP_InputField>().text);
            
            ((AffineCipher)Cipher).SetParameter(alphabets, keyA, keyB);
            
        }
    }
}