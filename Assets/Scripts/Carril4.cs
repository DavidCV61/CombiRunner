using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carril4 : MonoBehaviour
{
    [SerializeField] private float velocidad;
    public bool PuedeMoverse4{get;set;}
    public PlayerController Player4 {get;set;}
    

    void Update()
    {

        if(PuedeMoverse4){

            transform.Translate(Vector3.forward*velocidad*Time.deltaTime);
            if(transform.position.z+40<Player4.transform.position.z){
                PuedeMoverse4 =false;
            }

        }
        
    }
}
