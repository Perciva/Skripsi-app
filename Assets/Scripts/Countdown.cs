using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Countdown : MonoBehaviour
{
    
    float current_time;
    public float start_time = 10800f; //3 hours in seconds

    [SerializeField] Text countdown_text; 

    void start()
    {
        current_time = start_time;
    }

    void Update()
    {
        current_time -= 1f * (float)Time.deltaTime; //add 1 to the timer every second
        countdown_text.text = (start_time + current_time).ToString(); //nampilin timer ny di layar

       
        if(start_time + current_time <= 0) //kalo timer ny udh nunjukkin angka 0 / udh di detik 0 biar dia gk nurun jadi angka negatif
        {
            countdown_text.text = "0";
        }
     
     }

}
