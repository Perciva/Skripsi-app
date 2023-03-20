using System.Collections;
using System.Collections.Generic;
using Puzzle;
using TMPro;
using UnityEngine;

public class Login : MonoBehaviour
{
    [SerializeField] private TMP_InputField unameField;
    [SerializeField] private TMP_InputField passwdField;
    [SerializeField] private GameObject errorBoxObj;
    [SerializeField] private TMP_Text errorText;
    [SerializeField] private GameObject keyObject;
    [SerializeField] private TMP_Text keyText;
    void Start()
    {
        passwdField.contentType = TMP_InputField.ContentType.Password;
        DisableError();
    }

    private bool LoginValidation()
    {
        if (string.IsNullOrEmpty(unameField.text))
        {
            SetError("Username Cannot be Empty!");
            return false;
        }
        else if (string.IsNullOrEmpty(passwdField.text))
        {
            SetError("Password Cannot be Empty!");
            return false;
        }
        DisableError();
        return true;
    }

    public void DoLogin()
    {
        if (!LoginValidation()) return;
        string username = unameField.text;
        string password = passwdField.text;

        string a = " 'OR 1 = 1 #";

        a= a.Replace(" ", "").ToLower();

        if (username.Replace(" ", "").ToLower().CompareTo(a) == 0)
        {
            ShowKey();
        }
        else if (password.Replace(" ", "").ToLower().CompareTo(a) == 0)
        {
            ShowKey();
        }
        else
        {
            SetError("Username and Password does not match!");
        }


    }
    private void SetError(string msg)
    {
        if (!errorBoxObj.activeSelf) errorBoxObj.SetActive(true);
        errorText.SetText(msg);
    }
    private void DisableError()
    {
        errorBoxObj.SetActive(false);
    }

    private void ShowKey()
    {
        PuzzleGenerator gen = PuzzleGenerator.Instance;
        if(gen.GetPuzzle(5) is WebPuzzle)
        {
            WebPuzzle puzzle = gen.GetPuzzle(5) as WebPuzzle;
            Debug.Log(puzzle is WebPuzzle);
            Debug.Log(puzzle.WebKey);
            keyText.text = puzzle.WebKey;
            
        }
        keyObject.SetActive(true);
        
    }


    void Update()
    {
        
    }
}
