using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionTipo1 : MonoBehaviour
{
    public GameObject PielTipo2;
    public GameObject PielTipo3;
    void OnTriggerEnter(Collider other){
        // Verificar si lo que colisionó fue la navaja
        if(other.CompareTag("navaja")){
            // ELiminar el elemento anterior y generar las secciones divididas
            Destroy(this.gameObject);
            GameObject parteIzquierda;
            GameObject parteDerecha;
            Vector3 donde;
            donde = other.transform.position;
            float mag = donde.x-transform.position.x;
            
            // Para la parte izquierda, calculo de la posicion y tamaño respecto al punto de colision
            float x2i = transform.position.x+0.5f*mag-0.5f-0.25f*transform.localScale.x;
            parteIzquierda=Instantiate(PielTipo2,new Vector3(x2i,transform.position.y,transform.position.z),Quaternion.identity);
            parteIzquierda.transform.Rotate(new Vector3(90,0,0));
            float tamXi = transform.localScale.x/2+mag-1;
            parteIzquierda.transform.localScale = new Vector3(tamXi,transform.localScale.y,transform.localScale.z);
            

            // Para la parte derecha
            float x2d = transform.position.x+(transform.localScale.x/2-((transform.localScale.x/2-mag)-1)/2);
            parteDerecha=Instantiate(PielTipo2,new Vector3(x2d,transform.position.y,transform.position.z),Quaternion.identity);
            parteDerecha.transform.Rotate(new Vector3(90,0,0));
            float tamXd = transform.localScale.x/2-mag-1;
            parteDerecha.transform.localScale = new Vector3(tamXd,transform.localScale.y,transform.localScale.z);

            // Crear las partes de enmedio
            float zIterado;
            for(int i=0;i<10;i++){
                GameObject tipo2Izquierda;
                GameObject tipo2Derecha;
                zIterado=(transform.position.z+transform.localScale.z/2- transform.localScale.z/10*i-0.5f);
           
                tipo2Izquierda=Instantiate(PielTipo3, new Vector3(donde.x-0.5f,transform.position.y,zIterado), Quaternion.identity);
                
                tipo2Derecha=Instantiate(PielTipo3, new Vector3(donde.x+0.5f,transform.position.y,zIterado), Quaternion.identity);
            }
        }
        
    }
}
