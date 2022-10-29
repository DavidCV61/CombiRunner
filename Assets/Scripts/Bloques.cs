using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipodeBloques{
Normal,Coches
}
public class Bloques : MonoBehaviour
{

   
     [SerializeField]private TipodeBloques tipobloque;
      public TipodeBloques TipoDebloque => tipobloque;
      [SerializeField] private Tren[] trenes;
      [SerializeField] private Tren trenSeleccionado;

      public void InicializarBloque(){
               if(tipobloque ==  TipodeBloques.Coches){
                  SeleccionarTren();
      }
      }

      private void SeleccionarTren(){

          if(trenes == null || trenes.Length == 0){
                        return;
                  }

                  int index=Random.Range(0,trenes.Length);
                  trenes[index].gameObject.SetActive(true);
                  trenSeleccionado=trenes[index];
            }
      private void OnTriggerEnter(Collider other) {
            if(other.CompareTag("Player")){
                  trenSeleccionado.PuedeMoverse=true;
                  trenSeleccionado.Player=other.GetComponent<PlayerController>();
            }
            
      }

      }
     
      

      

      
       
      
      



    

