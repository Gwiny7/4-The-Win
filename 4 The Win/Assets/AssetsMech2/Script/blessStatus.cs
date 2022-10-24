using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class blessStatus : MonoBehaviourPunCallbacks
{
    public ProjectileSpawner LocalPlayer;
    private int Seed;

    void Awake()
    {
        //Seed = Random.Range(0, 64);
        //Random.seed = (int)Seed;

        if(PhotonNetwork.LocalPlayer.ActorNumber == PlayerArrayControl.PlayersActorOrder[/*(int)Random.Range(0, PhotonNetwork.CurrentRoom.PlayerCount)*/0]){
            LocalPlayer.SetBlessed(true);
        }

        else{
            LocalPlayer.SetBlessed(false);
        }
    }
}
