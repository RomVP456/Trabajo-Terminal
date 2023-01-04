using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountFrames : MonoBehaviour
{

    public TMP_Text cuadrosPorSegundo; 
    private int avgFrameRate;
    void Start()
    {
        InvokeRepeating("DisplayCuenta",1,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DisplayCuenta(){
        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;
        cuadrosPorSegundo.text = avgFrameRate.ToString() + " FPS";
    }
}
