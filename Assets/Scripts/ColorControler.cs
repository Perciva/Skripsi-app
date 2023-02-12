using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorControler : MonoBehaviour
{
    [SerializeField] Image mainDisplay;
    [SerializeField] Slider redSlider;
    [SerializeField] Slider greenSlider;
    [SerializeField] Slider blueSlider;

    private byte r;
    private byte g;
    private byte b;

    // Start is called before the first frame update
    void Start()
    {
        r = 0;
        g = 0;
        b = 0;
    }

    
    // Update is called once per frame
    void Update()
    {
        r = (byte)(redSlider.value * 255f);
        g = (byte)(greenSlider.value * 255f);
        b = (byte)(blueSlider.value * 255f);

         mainDisplay.color = new Color32(r,g,b,100);

        // Debug.Log(r + " " + g + " " + b);
    }
}
