using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;


public class DefineBlessed : MonoBehaviour
{
    public GameObject blessedScreen;
    bool blessed;
    public GameObject victoryScreen;
    public GameObject nextButton;
    public GameObject defeatScreen;
    public GameObject nextButtonD;
    // Start is called before the first frame update
    void Start()
    {
        blessed = PlayerArrayControl.blessed;
        if(blessed){
            blessedScreen.SetActive(true);
        }
    }

    [PunRPC]

    void RPC_Victory(){
        victoryScreen.SetActive(true);
        if(PhotonNetwork.IsMasterClient){
            nextButton.SetActive(true);
        }
    }

    [PunRPC]
    void RPC_Defeat(){
        defeatScreen.SetActive(true);
        if(PhotonNetwork.IsMasterClient){
            nextButtonD.SetActive(true);
        }
    }
}
