using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropdownController : MonoBehaviour
{
    [SerializeField] private OptionController option;
    
    [SerializeField] private TMP_Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {

    }
    /*
     * Index Dropdownn: 0-4
     * Caesar
     * Vigenere
     * Affine
     * Base 32
     * Base 64
     */
    public void changeOption()
    {
        int value = dropdown.value;
        switch (value)
        {
            case 0:
                option.CaesarCipherOptions();
                break;
            case 1:
                option.VigenereCipherOptions();
                break;
            case 2:
                option.AffineCipherOptions();
                break;
            case 3:
                option.Hash32Options();
                break;
            case 4:
                option.Hash64Options();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
