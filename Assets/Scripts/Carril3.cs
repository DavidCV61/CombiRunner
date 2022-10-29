using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carril3 : MonoBehaviour
{
   [SerializeField] private float velocidad;
    public bool PuedeMoverse3{get;set;}
    public PlayerController Player3 {get;set;}
    

    void Update()
    {

        if(PuedeMoverse3){

            transform.Translate(Vector3.forward*velocidad*Time.deltaTime);
            if(transform.position.z+40<Player3.transform.position.z){
                PuedeMoverse3 =false;
            }

        }
        
    }
}
