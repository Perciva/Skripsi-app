using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    private string input;
    

    void Start()
    {
       
    }

    public void read_string(string text)
    {
        input = text;
        Debug.Log(input);
    }
    
}
