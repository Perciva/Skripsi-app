using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    private string input;
    [SerializeField] private TMP_Text resultText;

    void Start()
    {
        resultText.text = "";
    }

    private void CorrectKey()
    {
        resultText.color = Color.green;
        resultText.text = "Correct Key! Congratulation!";
    }

    private void FalseKey()
    {
        resultText.color=Color.red;
        resultText.text = "Wrong Key!";
    }

    public void read_string(string text)
    {
        input = text;

        Debug.Log(input);
        FalseKey();
    }
    
}
