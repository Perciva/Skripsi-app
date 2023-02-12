using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; //needed for audio set
using UnityEngine.UI;

public class VolumeSet : MonoBehaviour
{
    public AudioMixer audio_mixer;

    public float volume_value; 

    public Slider volSlide;

    void start()
    {
        volSlide.value = PlayerPrefs.GetFloat("gameVol");
    }

    void update()
    {
        audio_mixer.SetFloat("gameVol", volume_value);//gameVol itu nama mixer di unity ny
        PlayerPrefs.SetFloat("gameVol", volume_value); //PlayerPrefs store player's preferences between game sessions
    }
    
    public void slideVol (float volume) //the (float volume) is to take in the value of the slider
    {
        //test di console unity liat value float ny sesuai atau gk Debug.Log(volume); 

        // audio_mixer.SetFloat("gameVol", volume); dipindahin ke void update, sengaja gk di cut

        volume_value = volume;
    }

}
