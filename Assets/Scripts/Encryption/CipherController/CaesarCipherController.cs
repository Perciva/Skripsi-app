using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace Encryption.CipherController
{
    public class CaesarCipherController : CipherController
    {
        private int _shift;
        private string _alphabets;
        private GameObject _alphabetsObj;
        private GameObject _shiftObj;

        public CaesarCipherController(GameObject shiftObj, GameObject alphabets) : base()
        {
     
            _shiftObj = shiftObj;
            _alphabetsObj = alphabets;
            this.Cipher = new CaesarCipher();
        }

        public override void UpdateValues()
        {
            _shift = int.Parse(_shiftObj.GetComponentInChildren<TMP_InputField>().text);
            _alphabets = _alphabetsObj.GetComponentInChildren<TMP_InputField>().text;

            ((CaesarCipher)this.Cipher).SetParameter(_alphabets, _shift);
        }

    }
}