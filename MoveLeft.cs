using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private Rigidbody bisturiRB;
    private float velocidad;
    public float velDesplazamiento= 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        bisturiRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        velocidad=bisturiRB.velocity.magnitude;
        if(Input.GetKey("space") && velocidad==0){

            print("avanza");
            // bisturiRB.AddForce(-Vector3.forward*velDesplazamiento, ForceMode.Impulse);
            bisturiRB.MovePosition(transform.position-Vector3.forward*velDesplazamiento*Time.deltaTime);
            // transform.Translate(-Vector3.up*velDesplazamiento*Time.deltaTime);
            //transform.GetChild(1).GetComponent<Rigidbody>().AddForce(-Vector3.right*velDesplazamiento*Time.deltaTime, ForceMode.Impulse);
            
        }
        else{
            print("detiene");
            bisturiRB.velocity=Vector3.zero;
            //transform.GetChild(1).GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
