using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Encryption.CipherController;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class OptionController : MonoBehaviour
{
    [Header("Options Fields")] 
    [SerializeField] private GameObject caesarShiftObj;
    [SerializeField] private GameObject affineKeyObj;
    [SerializeField] private GameObject affineKeyAObj;
    [SerializeField] private GameObject affineKeyBObj;
    [SerializeField] private GameObject vigenereKeyObj;
    [SerializeField] private GameObject alphabetsObj;

    [Header("Input Output")] 
    [SerializeField] private TMP_InputField inputTMPInputField;
    [SerializeField] private TMP_InputField outputTMPInputField;

    [Header("Error")] 
    [SerializeField] private GameObject errorBoxObj;
    [SerializeField] private TMP_Text errorText;
    // [SerializeField] private Validator _validator;
    

    private GameObject _activeGameObject;
    private CipherController _cipher;
    

    // Start is called before the first frame update
    void Start()
    {
        CaesarCipherOptions();
        // VigenereCipherOptions();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Encrypt()
    {
        _cipher.UpdateValues();
        
        outputTMPInputField.text = _cipher.Encrypt(inputTMPInputField.text);
    }
    public void Decyrpt()
    {
        _cipher.UpdateValues();
        outputTMPInputField.text = _cipher.Decrypt(inputTMPInputField.text);
    }
    
    #region Option Field Hide/Show Control
    public void CaesarCipherOptions()
    {
        if (_activeGameObject) _activeGameObject.SetActive(false);
        caesarShiftObj.SetActive(true);
        _cipher = new CaesarCipherController(caesarShiftObj, alphabetsObj);
        _activeGameObject = caesarShiftObj;
    }

    public void VigenereCipherOptions()
    {
        _activeGameObject.SetActive(false);
        vigenereKeyObj.SetActive(true);
        _cipher = new VigenereCipherController(vigenereKeyObj, alphabetsObj);
        _activeGameObject = vigenereKeyObj;
    }

    public void AffineCipherOptions()
    {
        _activeGameObject.SetActive(false);
        affineKeyObj.SetActive(true);
        _cipher = new AffineCipherController(affineKeyAObj, affineKeyBObj, alphabetsObj);
        _activeGameObject = affineKeyObj;
    }

    public void Hash32Options()
    {
        _activeGameObject.SetActive(false);
        _cipher = new Base32HashController();
        alphabetsObj.SetActive(false);
    }
    public void Hash64Options()
    {
        _activeGameObject.SetActive(false);
        _cipher = new Base64HashController();
        alphabetsObj.SetActive(false);
    }

    #endregion
}