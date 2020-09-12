using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
 
public class pegachave: MonoBehaviourPun
{
  AudioSource  MyAudioSource;
   
   void Start()
   {
      MyAudioSource = GetComponent<AudioSource>();
   }

    IEnumerator OnTriggerEnter(Collider other)
    {
            
      if(other.gameObject.tag == "robot"){
        MyAudioSource.Play();
        Abreporta.temchave=true;
        yield return new WaitForSeconds(3);//pra tocar antes de destroy
        Destroy(gameObject,.5f);
            
       }
      }
}

    