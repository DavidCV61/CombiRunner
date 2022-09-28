using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]private float MovDer;
    [SerializeField]private float velMov;
    [SerializeField]private float contsX=15f;
    [SerializeField]private float gravedad=20f;
    [SerializeField]private float salto=20f;
     [SerializeField]private float limiteSuperior=9f;
      [SerializeField]private float limiteInferior=-9f;

     [SerializeField] private float posVertical=0f;
    private CharacterController Jugador;
    private int carrilActual;
    private Vector3 direccion;
    

  


    private void Start() {
        
    

        Jugador=GetComponent<CharacterController>();
        Debug.Log("Hola mundo");


    } 
    private void Update()
    {





       
        


        MovDer=Input.GetAxis("Horizontal");
        direccion=new Vector3(MovDer*contsX,0,velMov);

        
       

        

        if(Jugador.isGrounded){

            posVertical=-gravedad*Time.deltaTime;
            direccion.y=posVertical;

            if(Input.GetButtonDown("Jump")){

                posVertical=salto;
                direccion.y=posVertical;
            }


        }else{

            posVertical-=gravedad*Time.deltaTime;
            direccion.y=posVertical;

            
        }

        
        Jugador.Move(direccion*Time.deltaTime);
         if(transform.position.x<=limiteInferior){

            direccion=Vector3.zero;
            transform.position=new Vector3(limiteInferior,transform.position.y,transform.position.z);

        }
           if(transform.position.x>=limiteSuperior){

            direccion=Vector3.zero;
            transform.position=new Vector3(limiteSuperior,transform.position.y,transform.position.z);

        }

        
        
    }


  
   
   
}
