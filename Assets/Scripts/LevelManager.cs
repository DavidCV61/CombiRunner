using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int BloquesAlInicio=2;

    [SerializeField] private Bloques bloqueInicial;
    [SerializeField] private int LongitudBloqueNormal=283;
    [SerializeField] private Bloques[] bloquesPrefabs;

    [SerializeField] private List<Bloques> listaBloquesNormales= new List<Bloques>();

    private Pooler pooler;
    private Bloques UltimoBloque;
    private int bloquesCreados;

    private void Awake() {
        pooler = GetComponent<Pooler>();
    }

    void Start()
    {
        LlenarBloquesSegunTipo();
        UltimoBloque=bloqueInicial;
    for (int i = 0; i < BloquesAlInicio; i++)
    {

        AnadirBloque(TipodeBloques.Normal,LongitudBloqueNormal);
        
    }        
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.G)){
            AnadirBloque(TipodeBloques.Normal,LongitudBloqueNormal);
        }
    }

    private void AnadirBloque(TipodeBloques tipo,float longitud){
        Bloques nuevo_bloque = ObtenerBloquesSegunTipo(tipo);
        nuevo_bloque.transform.position=EstablecerPosicionNuevoBloque(longitud);
        UltimoBloque=nuevo_bloque;
        bloquesCreados++;



    }

    

    private void LlenarBloquesSegunTipo(){

        foreach (Bloques bloque in bloquesPrefabs)
        {
            switch (bloque.TipoDebloque)
            {
                case TipodeBloques.Normal:
                listaBloquesNormales.Add(bloque);
                break;
                
                default:
                break;
            }
        }
    }


    private Bloques ObtenerInstanciadelPooler2(List<Bloques> lista){

        int bloqueRandom =Random.Range(0,lista.Count);
        string nombreDelbloque=lista[bloqueRandom].name;
        GameObject instancia =pooler.ObtenerInstanciadelPooler(nombreDelbloque);
        instancia.SetActive(true);
        Bloques bloque = instancia.GetComponent<Bloques>();
        return bloque;
    }

    private Bloques ObtenerBloquesSegunTipo(TipodeBloques tipo){

        Bloques nuevoBloque = null;
        switch(tipo){

            case TipodeBloques.Normal:
            nuevoBloque = ObtenerInstanciadelPooler2(listaBloquesNormales);
            break;
        }

        return nuevoBloque;

    }

    private Vector3 EstablecerPosicionNuevoBloque(float longitud){


        return UltimoBloque.transform.position+Vector3.forward*longitud;

    }

    private void  RespuestaSolicitudNuevoBloque(){
        AnadirBloque(TipodeBloques.Normal,LongitudBloqueNormal);

    }

    private void OnEnable() {

        Limite.EventoSolicitudNuevoBloque += RespuestaSolicitudNuevoBloque;
        
    }
    private void OnDisable() {
         Limite.EventoSolicitudNuevoBloque -= RespuestaSolicitudNuevoBloque;
    }



   

   

    
}
