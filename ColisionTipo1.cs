using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColisionTipo1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Localizador;
    public GameObject PielTipo2;
    public GameObject PielTipo3Derecha;
    public GameObject PielTipo3Izquierda;
    public GameObject[] enmedio;

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("navaja")){

            enmedio = new GameObject[20];

            // gameObject.GetComponent<MeshRenderer>().enabled=false;
            Destroy(this.gameObject);
            GameObject parteIzquierda;
            GameObject parteDerecha;
            Vector3 donde;
            donde = other.transform.position;
            float mag = donde.x-transform.position.x;
            
            // Para la parte izquierda
            float x2i = transform.position.x+0.5f*mag-0.5f-0.25f*transform.localScale.x;
            // Instantiate(Localizador,new Vector3(x2i,transform.position.y,transform.position.z),Quaternion.identity);
            parteIzquierda=Instantiate(PielTipo2,new Vector3(x2i,transform.position.y,transform.position.z),Quaternion.identity);
            parteIzquierda.transform.Rotate(new Vector3(90,0,0));
            float tamXi = transform.localScale.x/2+mag-1;
            parteIzquierda.transform.localScale = new Vector3(tamXi,transform.localScale.y,transform.localScale.z);
            

            // Para la parte derecha
            // float x2d = transform.position.x-0.5f*mag+0.5f+0.25f*transform.localScale.x;
            float x2d = transform.position.x+(transform.localScale.x/2-((transform.localScale.x/2-mag)-1)/2);
            // Instantiate(Localizador,new Vector3(x2d,transform.position.y,transform.position.z),Quaternion.identity);
            parteDerecha=Instantiate(PielTipo2,new Vector3(x2d,transform.position.y,transform.position.z),Quaternion.identity);
            parteDerecha.transform.Rotate(new Vector3(90,0,0));
            float tamXd = transform.localScale.x/2-mag-1;
            parteDerecha.transform.localScale = new Vector3(tamXd,transform.localScale.y,transform.localScale.z);

            // Crear las partes de enmedio
            float zIterado;
            zIterado=(transform.position.z+transform.localScale.z/2- transform.localScale.z/10*0-0.5f);
            enmedio[0]=Instantiate(PielTipo3Izquierda,new Vector3(donde.x-0.5f,transform.position.y,zIterado),Quaternion.identity);
            enmedio[1]=Instantiate(PielTipo3Derecha,new Vector3(donde.x+0.5f,transform.position.y,zIterado),Quaternion.identity);

            for(int i=2;i<20;i+=2){
                zIterado=(transform.position.z+transform.localScale.z/2- transform.localScale.z/10*(i/2)-0.5f);
                
                enmedio[i]=Instantiate(PielTipo3Izquierda,new Vector3(donde.x-0.5f,transform.position.y,zIterado),Quaternion.identity);
                enmedio[i+1]=Instantiate(PielTipo3Derecha,new Vector3(donde.x+0.5f,transform.position.y,zIterado),Quaternion.identity);
                // Román del futro cambia el 0.5f del codigo de arriba por la escala 
                // tambien agrega un cambio de escala para que quede del tamaño adecuado y sea mas facil modificarlo
                
                FixedJoint unionIzquierda1 = (enmedio[i].transform.Find("Armature.005").Find("Bone.002")).gameObject.AddComponent<FixedJoint>();
                unionIzquierda1.connectedBody = enmedio[i-2].transform.Find("Armature.005").Find("Bone.004").GetComponent<Rigidbody>();

                FixedJoint unionDerecha1 = enmedio[i+1].transform.Find("Armature.005").Find("Bone.001").gameObject.AddComponent<FixedJoint>();
                unionDerecha1.connectedBody = enmedio[i-1].transform.Find("Armature.005").Find("Bone.003").GetComponent<Rigidbody>();

            }
        }
        
    }
}
