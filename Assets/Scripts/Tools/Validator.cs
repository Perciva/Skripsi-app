using System;
using System.Linq;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Validator : MonoBehaviour
    {
        [Header("Options Fields")] 
        [SerializeField] private TMP_InputField caesarShiftTMPI;
        [SerializeField] private TMP_InputField affineKeyATMPI;
        [SerializeField] private TMP_InputField affineKeyBTMPI;
        [SerializeField] private TMP_InputField vigenereKeyTMPI;
        [SerializeField] private TMP_InputField alphabetsTMPI;

        [Header("Input Output")] 
        [SerializeField] private TMP_InputField inputTMPI;
        [SerializeField] private TMP_Dropdown dropdown;
        
        [Header("Error")]
        [SerializeField] private GameObject errorBoxObj;
        [SerializeField] private TMP_Text errorText;
        
        [Header("Input Output Buttons")]
        [SerializeField] private Button encryptButton;
        [SerializeField] private Button decryptButton;

        
        public void Start()
        {
            DisableError();
            FieldValidate();
        }
        private void DisableButtons()
        {
            encryptButton.interactable = false;
            decryptButton.interactable = false;
        }
        private void EnableButtons()
        {
            encryptButton.interactable = true;
            decryptButton.interactable = true;
        }
        private void SetError(string msg)
        {
            if (!errorBoxObj.activeSelf) errorBoxObj.SetActive(true);
            errorText.SetText(msg);
            DisableButtons();
        }
        
        private void DisableError()
        {
            errorBoxObj.SetActive(false);
            EnableButtons();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(inputTMPI.text))
            {
                SetError("Input Must Not be Empty!");
                return false;
            }
            DisableError();
            return true;
        }

        private bool ValidateCaesarShift()
        {
            if(string.IsNullOrEmpty(caesarShiftTMPI.text)){
                SetError("Shift Must Not be Empty!");
                return false;
            }
            DisableError();
            return true;
        }

        private bool ValidateAlphabets()
        {
          
            string alpha = alphabetsTMPI.text;

            if (string.IsNullOrEmpty(alpha))
            {
                SetError("Alphabets Must Not be Empty!");
                return false;
            }

            alpha = alpha.ToLower();
            //if distinct alphabets not same length as total
            if (!(alpha.Distinct().Count() == alpha.Length))
            {
                SetError("Alphabets Must Not Contain Duplicate Character!");
                return false;
            }
            DisableError();
            return true;
        }

        private bool ValidateVigenereKey()
        {
            string key = vigenereKeyTMPI.text.ToLower();
            if (string.IsNullOrEmpty(key))
            {
                SetError("Key Must Not Be Empty");
                return false;
            }
            string alpha = alphabetsTMPI.text;
            foreach(char ch in key)
            {
                if (!char.IsLetter(ch))
                {
                    SetError("Key Must Be Letters");
                    return false;
                }
                else if (alpha.IndexOf(ch) == -1)
                {
                    SetError("Key Containes forbidden character : '"+ch+"'");
                    return false;
                }
            }
            DisableError();
            return true;
        }

        private bool ValidateAffineKeys()
        {
            if (string.IsNullOrEmpty(affineKeyATMPI.text) || string.IsNullOrEmpty(affineKeyBTMPI.text))
            {
                SetError("Keys Must Not Be Empty!");
                return false;
            }
            int keyA = int.Parse(affineKeyATMPI.text);
            int keyB = int.Parse(affineKeyBTMPI.text);

            if (keyA < 1 || keyB < 1)
            {
                SetError("Keys Must be more than 0");
                return false;
            }

            BigInteger gcd = BigInteger.GreatestCommonDivisor(keyA, alphabetsTMPI.text.Length);
            //mustbe coprime
            Debug.Log("gcd:" + gcd);
            if (gcd != 1)
            {
                SetError("Key A is not coprime of alphabets length");
                return false;
            }
            
            DisableError();
            return true;
        }

        public void FieldValidate()
        {
            if (!ValidateInput()) return;
            
            int value = dropdown.value;
            switch (value)
            {
                case 0:
                    //caesar
                    if (ValidateAlphabets()) ValidateCaesarShift();
                    break;
                case 1:
                    // vigenere
                    if (ValidateAlphabets()) ValidateVigenereKey();
                    break;
                case 2:
                    // affine
                    if (ValidateAlphabets()) ValidateAffineKeys();
                    break;
                case 3:
                    // option.HashOptions();
                    break;
                case 4:
                    // option.HashOptions();
                    break;
            }
        }
    }
