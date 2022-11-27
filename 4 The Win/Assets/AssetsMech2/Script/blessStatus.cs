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
    private int RandomizerSeed;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
        Seed = (int)Random.Range(0, PhotonNetwork.CurrentRoom.PlayerCount);
        RandomizerSeed = (int)Random.Range(1, 65);
        
        if(PhotonNetwork.IsMasterClient){
            BlessedActorNumber = PlayerArrayControl.PlayersActorOrder[Seed];
            PV.RPC("RPC_PassBlessed", RpcTarget.AllBuffered, BlessedActorNumber, RandomizerSeed);
        }
    }
    
    public bool IsBlessed(){
        return isBlessed;
    }

    [PunRPC]
    void RPC_PassBlessed(int num, int seed){
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
        PlayerArrayControl.RandomSeed = seed;
    }
}
