using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; //as the name suggests it manages the scenes
using UnityEngine.UI; //for the slider to fill up and for the random texts (facts) showing up on loading screen, this library is needed

public class loadscreen : MonoBehaviour
{
    public GameObject load_screen;
    public Slider slider;
    public int rand_fact;
    public Text facts_disp;

    float progress = 0;

    void Start()
    {
        StartCoroutine(LoadAsynchronously(2));

        //buat display cybersec facts randomly on every load screens
        rand_fact = Random.Range(1, 9); //knp 9 karena di-itung dari 0

        if (rand_fact == 1)
        {
            facts_disp.text = "Cybercrime is more common in Indonesia, reported by Akamai Techonologies.";
        }

        if (rand_fact == 2)
        {
            facts_disp.text = "Companies experienced a 176% increase in the number of cyberattacks. From this, 68% of funds were never recovered.";
        }

        if (rand_fact == 3)
        {
            facts_disp.text = "Every one in ten social media users has been the victim of cyber-attack.";
        }

        if (rand_fact == 4)
        {
            facts_disp.text = "44% of Millennials have fallen victim to cybercrime by sharing passwords.";
        }

        if (rand_fact == 5)
        {
            facts_disp.text = "Norton Cybersecurity Insights Reports states that Millennials are the most vulnerable to cyber-attack.";
        }

        if (rand_fact == 6)
        {
            facts_disp.text = "3 billion phising emails are sent everyday to hack sensitive information.";
        }

        if (rand_fact == 7)
        {
            facts_disp.text = "Hackers often target social media users.";
        }

        if (rand_fact == 8)
        {
            facts_disp.text = "Ransomware is currently the leading technique used by cybercriminals.";
        }

    }

    /* public void loading_screen (int sceneIndex)
     {
         //StartCoroutine(LoadAsynchronously(sceneIndex));
     }
    */

   /* IEnumerator ExampleCoroutine()
    {
        progress+= 0.05f;

        slider.value = progress;

        yield return new WaitForSeconds(0.001f);
    }
   */

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        

        //load_screen.SetActive(true);

        while (progress != 100) //bisa jg while (operation.isDone == false)

        
        {
            

            //StartCoroutine(ExampleCoroutine());

            progress += 0.0007f;

            slider.value = progress;

            //Debug.Log(progress); //buat testing di unity ny


            if (progress >= 1)
            {
                AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

            }

            yield return null; //wait until the next frame 
        }
       
    }
}
