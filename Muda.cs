using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
 
public class Muda: MonoBehaviourPun
{
  public string   entrante;
  public static string   entstatic;
  public PhotonView photonView;
  public string URLSkin =  "http://americo.somee.com/mozilla.jpg"; 
  AudioSource m_MyAudioSource;
   
   void Start()
   {
    m_MyAudioSource = GetComponent<AudioSource>();
    photonView = this.GetComponent<PhotonView>(); 
    entrante =  photonView.ViewID.ToString();
     
     URLSkin = PlayerPrefs.GetString("mySkin");  
    //Muda nomes
     if(photonView.IsMine) photonView.RPC("Mudar", RpcTarget.AllBuffered,entrante);
    //Muda skin
    if(photonView.IsMine) photonView.RPC("CarregaSk", RpcTarget.AllBuffered,entrante,URLSkin); 
    }

    void  OnGUI ()
    {
      GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
      myButtonStyle.fontSize = 60;
      Font myFont1 = (Font)Resources.Load("Fonts/comic", typeof(Font));
      myButtonStyle.font = myFont1;
      myButtonStyle.normal.textColor = Color.yellow;
      myButtonStyle.hover.textColor = Color.yellow; 

       if( GUI.Button(new Rect(Screen.width-300,Screen.height -  450,300,150), "TIRO",myButtonStyle))  
       {
         GameObject SH = GameObject.Find("robot(Clone)"+entrante);
         GameObject BC = PhotonNetwork.Instantiate ("bullet",new Vector3(SH.transform.position.x,SH.transform.position.y+  1.0f,SH.transform.position.z),SH.transform.rotation,0);
         BC.GetComponent<Rigidbody>().velocity = SH.transform.forward *7;
        }
       
        if(GUI.Button (new Rect (Screen.width-530,Screen.height -  300,600,150) , "MUDA CAMERA",myButtonStyle ))
        {
          entstatic = entrante;
        }
    
      }

      
          //void OnTriggerEnter(Collider other)
         IEnumerator OnTriggerEnter(Collider other)
         {
           if(other.gameObject.tag == "bola" || other.gameObject.name == "inferno"){
            m_MyAudioSource.Play();//robot tem "dead" de audio clip
            photonView = gameObject.GetComponent<PhotonView>(); 
            entrante =  photonView.ViewID.ToString();
            GameObject GOx = GameObject.Find("robot(Clone)"+entrante);
            yield return new WaitForSeconds(0.01f);//gambiarra!!!!
            GOx.transform.position = GameObject.Find("Entrada").transform.position ;  
            GOx.transform.rotation = GameObject.Find("Entrada").transform.rotation ; 
 
            //photonView.RPC("Dead", RpcTarget.All,entrante); //Excluido pq tem Photonview
           }
          }

    [PunRPC]

    void  Mudar(string ent )
    {
     PhotonView photonViewX = this.GetComponent<PhotonView>();
     if(photonViewX.ViewID.ToString() == ent){
       //nome do avatar
       GetComponentInChildren<Transform>().name = GetComponentInChildren<Transform>().name +ent;
       //nome da textura
       GetComponentInChildren<Renderer>().materials[0].name = GetComponentInChildren<Renderer>().materials[0].name+ent;
      }
    }
    
    [PunRPC]

    IEnumerator  CarregaSk(string ent,string URL )
    {
     PhotonView photonViewX = this.GetComponent<PhotonView>();
     if(photonViewX.ViewID.ToString() == ent){
       GameObject GOH = GameObject.Find("robot(Clone)"+ent);
       using (WWW www = new WWW(URL))
       {
         yield return www;
         GOH.GetComponentInChildren<Renderer>().materials[0].mainTexture  = www.texture;
        }  
       }
     }

    
     //[PunRPC]
     //EXCLUIDO
     //void  Dead(string ent)
     //{
     //}
     
}
