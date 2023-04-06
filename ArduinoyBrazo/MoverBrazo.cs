using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoverBrazo : MonoBehaviour
{
    public float rotationValue = 0;
    public int axis;
    private Vector3 rotacion = Vector3.zero;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotacion[axis] = rotationValue;
        transform.rotation = Quaternion.Euler(rotacion);
    }
    public void OnScrollbarValueChanged(float value)
    {
        rotationValue = value;
    }
}
