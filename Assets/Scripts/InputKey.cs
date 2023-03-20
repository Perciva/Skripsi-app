using System.Collections;
using System.Collections.Generic;
using Puzzle;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        if(generator.CheckCombinedKey(input)==true) { // == "DUAR"
            CorrectKey();
            StartCoroutine(test());
            return;
        }
        Debug.Log(input);
        FalseKey();
    }

    IEnumerator test(){
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("HighScore", LoadSceneMode.Single);
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
