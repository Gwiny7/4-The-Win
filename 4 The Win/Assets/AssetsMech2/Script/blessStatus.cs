using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using TMPro;

public class blessStatus : MonoBehaviourPunCallbacks
{
    public ProjectileSpawner LocalPlayer;
    private int Seed;
    private PhotonView PV;
    private int RandomValue;
    private int BlessedActorNumber;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
        Seed = 1;
        //Seed = (int)Random.Range(0, PhotonNetwork.CurrentRoom.PlayerCount);
        if(PhotonNetwork.IsMasterClient){
            PV.RPC("RPC_PassBlessed", RpcTarget.AllBuffered, Seed);
        }

        Debug.Log(BlessedActorNumber);
        //Debug.Log(PhotonNetwork.LocalPlayer.ActorNumber);
    }

    void Start(){
        if(PhotonNetwork.LocalPlayer.ActorNumber == BlessedActorNumber){
            LocalPlayer.SetBlessed(true);
        }

        else{
            LocalPlayer.SetBlessed(false);
        }
    }

    void Update(){
        if(PhotonNetwork.LocalPlayer.ActorNumber == BlessedActorNumber){
            LocalPlayer.SetBlessed(true);
        }

        else{
            LocalPlayer.SetBlessed(false);
        }
    }
    
    [PunRPC]
    void RPC_PassBlessed(int num){
        BlessedActorNumber = PlayerArrayControl.PlayersActorOrder[num];
        Debug.Log(BlessedActorNumber);
    }
}
