using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using TMPro;

public class blessStatus : MonoBehaviourPunCallbacks
{
    private int Seed;
    private PhotonView PV;
    private int RandomValue;
    private int BlessedActorNumber;
    private bool isBlessed = false;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
        Seed = (int)Random.Range(0, PhotonNetwork.CurrentRoom.PlayerCount);
        
        if(PhotonNetwork.IsMasterClient){
            BlessedActorNumber = PlayerArrayControl.PlayersActorOrder[Seed];
            PV.RPC("RPC_PassBlessed", RpcTarget.AllBuffered, BlessedActorNumber);
        }
    }
    
    public bool IsBlessed(){
        return isBlessed;
    }

    [PunRPC]
    void RPC_PassBlessed(int num){
        BlessedActorNumber = num;
        Debug.Log("Player Local: " + PhotonNetwork.LocalPlayer.ActorNumber);
        Debug.Log("Player Abençoado: " + BlessedActorNumber);
        
        if(PhotonNetwork.LocalPlayer.ActorNumber == BlessedActorNumber){
            isBlessed = true;
        }

        else{
            isBlessed = false;
        }
        
        PlayerArrayControl.blessed = isBlessed;
    }
}
