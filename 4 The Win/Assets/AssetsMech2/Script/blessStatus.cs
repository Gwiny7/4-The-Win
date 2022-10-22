using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class blessStatus : MonoBehaviourPunCallbacks
{
    public ProjectileSpawner LocalPlayer;
    void Awake()
    {
        if(PhotonNetwork.LocalPlayer.ActorNumber == PlayerArrayControl.PlayersActorOrder[0]){
            LocalPlayer.SetBlessed(true);
        }

        else{
            LocalPlayer.SetBlessed(false);
        }
    }
}
