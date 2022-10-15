using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipodeBloques{
Normal


}
public class Bloques : MonoBehaviour
{

   
     [SerializeField]private TipodeBloques tipobloque;
      public TipodeBloques TipoDebloque => tipobloque;


}
