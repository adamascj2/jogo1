using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class somdeporta : MonoBehaviour
{
AudioSource  MyAudioSource;
     
    void Start()
    {
      MyAudioSource = GetComponent<AudioSource>();
    }

     
    void Update()
    {
      if(Abreporta.tocou){   
       MyAudioSource.Play();
       Abreporta.tocou= false;       
      }     
     }
 
       
}
