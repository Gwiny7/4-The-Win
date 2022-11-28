using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

public class MazeFinal : MonoBehaviour
{
    PhotonView PV;
    bool won = false;
    public GameObject victoryScreen;

    private void Start(){
        PV = GameObject.Find("StatusManager").GetComponent<PhotonView>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player" && won == false)
        {
            victoryScreen.SetActive(true);
            won = true;
            Debug.Log("WIN");
            PV.RPC("RPC_SetVictory", RpcTarget.AllBuffered);
        }
        
    }
}
