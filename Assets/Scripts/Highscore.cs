using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Highscore : MonoBehaviour
{
    [Header("Highscore")] 
    [SerializeField] private TMP_Text HighscoreTextArea;
    [SerializeField] private GameObject BlurGameObject;
    [Header("Username")] 
    [SerializeField] private TMP_InputField UsernameTMPI;
    [SerializeField] private GameObject UsernameCanvas;
    [SerializeField] private TMP_Text ErrorText;

    private GameHighscoreController hscontroller;
    private GameHighscore newScore;
    void Start()
    {
        hscontroller = new GameHighscoreController();
    }

    public void getUsername()
    {
        string username = UsernameTMPI.text;

        if (string.IsNullOrEmpty(username))
        {
            ErrorText.text = "Username Must Not be Empty!";
            return;
        }
        int score = (int)Countdown.start_time;
        newScore = new GameHighscore(username,score);
        
        lala();
    }

    public void lala()
    {
        hscontroller.LoadHighscore();
        hscontroller.addHighscore(newScore);
        hscontroller.SaveHighscore();
        List<GameHighscore> highscores = hscontroller.GetHighscore();
        // highscores.Add(newScore);
        foreach (GameHighscore a in highscores)
        {
            HighscoreTextArea.text =HighscoreTextArea.text + a.Username + " - " + a.Score + "\n";
        }
        BlurGameObject.SetActive(false);
        UsernameCanvas.SetActive(false);
    }

}
