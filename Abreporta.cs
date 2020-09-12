using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abreporta : MonoBehaviour
{
  public static bool   temchave = false;
  public static bool fechada = true;
  public static bool tocou = false;
   
   
     void Update()
    {
     GameObject GOP = GameObject.Find("porta2");
       if(temchave &&  fechada && Vector3.Distance(transform.position,GOP.transform.position)<3 && GOP!=null){
          GOP.transform.Translate(Vector3.right*2);//inutil pq destroy
          fechada = false;
          tocou = true;
          Destroy(GOP,.5f);
        }
       //if(temchave && !fechada && Vector3.Distance(transform.position,GOP.transform.position)>6){
         //GOP.transform.Translate(Vector3.right*-2);
         //fechada = true;
         //tocou = true;
       //}//dava bug donde usei destroy
       
    } 
    
}
