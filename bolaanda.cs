using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
 
public class bolaanda: MonoBehaviourPun
{
 public float delta = 0.1f; 
 public float dir = 7.0f;
 public float esq = -7.0f;
     
  void Update()
  {
     transform.position = new Vector3  (transform.position.x+delta, transform.position.y, transform.position.z);      

     if(transform.position.x >= 7.0f){
        transform.Rotate(0,180,0) ;
        delta = -0.1f; 
      }
      if(transform.position.x <= -7.0f){
         transform.Rotate(0,180,0) ;
         delta =  0.1f; 
      }
    }
}

