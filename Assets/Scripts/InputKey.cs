using System.Collections;
using System.Collections.Generic;
using Puzzle;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputKey : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private InputField inputKey;
    [SerializeField] private TMP_Text resultText;
    private PuzzleGenerator generator;
    void Start()
    {
        if(resultText)resultText.text = "";
        generator = PuzzleGenerator.Instance;
    }
    
    public void CheckKey()
    {
        string input = inputKey.text;
        if(generator.CheckCombinedKey(input)==true) {
            CorrectKey();
            return;
        }
        Debug.Log(input);
        FalseKey();
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
}
