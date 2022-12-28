using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ToolbarMenu : MonoBehaviour
{
    public GameObject burgerMenu;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting");
    }

    // Update is called once per frame
    void Update()
    {
        
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
        SceneManager.LoadScene("SampleScene");
    }
    
    
}
