using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoverConSerial : MonoBehaviour
{
    public GameObject valoresPotenciometros;
    public SixSignals valores;
    public int[] intValores;
    public GameObject[] ejes;
    private Vector3 rotacion = Vector3.zero;
    private int[] cualEje = {1,1,2,2,1,2};
    void Start()
    {
        valores = valoresPotenciometros.GetComponent<SixSignals>();
        
    }

    // Update is called once per frame
    void Update()
    {
        intValores = Array.ConvertAll(valores.SeisValores,int.Parse);
        float dato;
        for (int i = 0;i<6;i++){
            dato = map(0,1023,-90,90,intValores[i]);
            rotacion[cualEje[i]] = dato;
            ejes[i].transform.localRotation = Quaternion.Euler(rotacion);
            rotacion = Vector3.zero;
        }
        
        
        // rotacion[1] = dato;
        // ejes[0].transform.rotation = Quaternion.Euler(rotacion);
        // rotacion = Vector3.zero;

        // dato = map(0,1023,-90,90,intValores[1]);
        // rotacion[1] = dato;
        // ejes[1].transform.localRotation = Quaternion.Euler(rotacion);
        // rotacion = Vector3.zero;

        // dato = map(0,1023,-90,90,intValores[2]);
        // rotacion[2] = dato;
        // ejes[2].transform.localRotation = Quaternion.Euler(rotacion);
        // rotacion = Vector3.zero;

        // dato = map(0,1023,-90,90,intValores[3]);
        // rotacion[2] = dato;
        // ejes[3].transform.localRotation = Quaternion.Euler(rotacion);
        // rotacion = Vector3.zero;
        // dato = map(0,1023,-90,90,intValores[1]);
        // ejes[1].transform.Rotate(0,dato,0);
    }
    public float map(float OldMin, float OldMax, float NewMin, float NewMax, int OldValue){ 
        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin; 
        return(NewValue);
    }
}
