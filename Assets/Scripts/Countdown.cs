using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Countdown : MonoBehaviour
{
    
    float current_time;
    public static float start_time = 10000; //3 hours in seconds

    [SerializeField] Text countdown_text; 

    void start()
    {

    }

    void Update()
    {
        decrement();   
        countdown_text.text = (start_time).ToString();
        if(start_time <= 0) //kalo timer ny udh nunjukkin angka 0 / udh di detik 0 biar dia gk nurun jadi angka negatif
        {
            countdown_text.text = "0";
        }
    }

    public static void decrement(){
        start_time -= 1f * (float)Time.deltaTime; //add 1 to the timer every second
         //nampilin timer ny di layar

       
        // if(start_time <= 0) //kalo timer ny udh nunjukkin angka 0 / udh di detik 0 biar dia gk nurun jadi angka negatif
        // {
        //     countdown_text.text = "0";
        // }
    }
}
