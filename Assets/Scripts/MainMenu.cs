using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    //buat masuk ke loading screen 
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    

    //kalo player keluar dari game
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("user has quit the game."); //test button ny bisa atau gk
    }
}
