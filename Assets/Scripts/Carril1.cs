using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carril1 : MonoBehaviour
{
    [SerializeField] private float velocidad;
    public bool PuedeMoverse1{get;set;}
    public PlayerController Player1 {get;set;}
    

    void Update()
    {

        if(PuedeMoverse1){

            transform.Translate(Vector3.forward*-velocidad*Time.deltaTime);
            if(transform.position.z+40<Player1.transform.position.z){
                PuedeMoverse1 =false;
            }

        }
        
    }
}
