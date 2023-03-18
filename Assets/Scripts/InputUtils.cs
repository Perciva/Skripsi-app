using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputUtils : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void GoToInput()
    {
        SceneManager.LoadScene("Input Key scene", LoadSceneMode.Single);
    }
}
