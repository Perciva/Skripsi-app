using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject g;
    //buat masuk ke loading screen 
    public void StartButton()
    {
        Countdown.start_time = 10800f;
        SceneManager.LoadScene("Loading Scene", LoadSceneMode.Single);
    }
    
    public void toggle(){
        g.SetActive(true);
    }

    //kalo player keluar dari game
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("user has quit the game."); //test button ny bisa atau gk
    }
}
