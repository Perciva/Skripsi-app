using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ToolbarMenu : MonoBehaviour
{
    public GameObject burgerMenu;
    public GameObject FE = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Countdown.decrement();
    }
    public void ToggleBurgerMenu()
    {
        // Debug.Log("BORGER");
        if (burgerMenu.activeSelf)
        {
            burgerMenu.SetActive(false);
        }
        else
        {
            burgerMenu.SetActive(true);
        }
    }

    public void GoToEncrypt()
    {
        SceneManager.LoadScene("Encrypt Tool", LoadSceneMode.Single);
    }
    public void GoToStegano()
    {
        SceneManager.LoadScene("SteganoTool", LoadSceneMode.Single);
    }
    public void GoToWeb()
    {
        SceneManager.LoadScene("WebSQL", LoadSceneMode.Single);
    }
    public void ToolgeFile()
    {
        if(FE != null){
            FE.SetActive(!FE.activeSelf);
            return;
        }
        SceneManager.LoadScene("Client's computer ransomware", LoadSceneMode.Single);
    }
}
