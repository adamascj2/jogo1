using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
 
public class vitoria: MonoBehaviourPun
{
 AudioSource  MyAudioSource;
   
   void Start()
   {
     MyAudioSource = GetComponent<AudioSource>();
     
    }

    void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag == "robot"){
        MyAudioSource.Play();
      }
     }
}

    