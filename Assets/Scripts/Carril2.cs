using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carril2 : MonoBehaviour
{
   [SerializeField] private float velocidad;
    public bool PuedeMoverse2{get;set;}
    public PlayerController Player2{get;set;}
    

    void Update()
    {

        if(PuedeMoverse2){

            transform.Translate(Vector3.forward*-velocidad*Time.deltaTime);
            if(transform.position.z+40<Player2.transform.position.z){
                PuedeMoverse2 =false;
            }

        }
        
    }
}
