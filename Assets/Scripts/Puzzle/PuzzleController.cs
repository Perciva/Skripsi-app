using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Puzzle;
using TMPro;
using UnityEngine.UI;


public class PuzzleController : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text question;
    [SerializeField] private TMP_Text checkKeyText;
    [SerializeField] private GameObject questionGO;
    private Puzzle.Puzzle a;
    private PuzzleGenerator generator;
    void Start()
    {
        generator = PuzzleGenerator.Instance;
        questionGO.SetActive(false);
    }

    public void GetPuzzle(int i)
    {
        a = generator.GetPuzzle(i);
        Debug.Log(a.Title +" " + a.Question);
        title.text = a.Title;
        question.text = a.Question;
        
        // a = generator.GetPuzzle(2);
        // Debug.Log(a.Title +" " + a.Question);
        //  a = generator.GetPuzzle(3);
        // Debug.Log(a.Title +" " + a.Question);
        // a = generator.GetPuzzle(4);
        // Debug.Log(a.Title +" " + a.Question);
    }

    public void CheckKey()
    {
        string k = checkKeyText.text;
        if (string.IsNullOrEmpty(k)) return;

        
        Debug.Log(k);
        Debug.Log(a.CheckKey(k));

        checkKeyText.color = a.CheckKey(k) == true ? Color.green : Color.red;


    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
