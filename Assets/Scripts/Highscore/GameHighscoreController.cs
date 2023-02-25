
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class GameHighscoreController
{
    private List<GameHighscore> highscores = new List<GameHighscore>();
    private Filebase fb = new Filebase();
    public void addHighscore(GameHighscore hs)
    {
        highscores.Add(hs);
    }

    public void sortHighscores()
    {
        // foreach(GameHighscore a in  highscores)
        // {
        //     Debug.Log("Username: " + a.Username + " Score: " + a.Score);
        // }
        // Debug.Log("Before");
        // highscores = highscores.OrderBy(a => a.Score).ToList();

        // highscores = highscores.OrderBy(a => a.Score).ToList();
        highscores.Sort((a,b) => b.Score.CompareTo(a.Score));
        Debug.Log(highscores);
    }

    public void SaveHighscore()
    {
        sortHighscores();
        fb.SaveHighscore(highscores);
    }

    public List<GameHighscore> GetHighscore()
    {
        return highscores;
    }
    public void LoadHighscore()
    {
        
        highscores = fb.LoadHighscore();
        sortHighscores();
        // foreach(GameHighscore a in  highscores)
        // {
        //     Debug.Log("Username: " + a.Username + " Score: " + a.Score);
        // }
    }
}
