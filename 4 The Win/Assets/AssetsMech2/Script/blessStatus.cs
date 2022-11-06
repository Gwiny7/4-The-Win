using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class blessStatus : MonoBehaviourPunCallbacks
{
    public ProjectileSpawner LocalPlayer;
    private int Seed;
    private PhotonView PV;
    private int RandomValue;

    void Awake()
    {
        //Seed = (int)Random.Range(0, PhotonNetwork.CurrentRoom.PlayerCount);
        //Seed = 1;
        PV = GetComponent<PhotonView>();
        PV.RPC("RPC_PassSeed", RpcTarget.AllBuffered, Seed);

        if(PhotonNetwork.LocalPlayer.ActorNumber == PlayerArrayControl.PlayersActorOrder[/*RandomValue*/0]){
            LocalPlayer.SetBlessed(true);
        }

        else{
            LocalPlayer.SetBlessed(false);
        }
    }
    
    [PunRPC]
    void RPC_PassSeed(int randomValue){
        RandomValue = randomValue;
    }
}
