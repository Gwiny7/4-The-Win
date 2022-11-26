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
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait(5.0f));
    }

    IEnumerator Wait(float sec){
        yield return new WaitForSeconds(sec);
        blessed = PlayerArrayControl.blessed;
        if(blessed){
            blessedScreen.SetActive(true);
        }
        yield return null;
    }

    [PunRPC]

    void RPC_Victory(){
        victoryScreen.SetActive(true);
        if(PhotonNetwork.IsMasterClient){
            nextButton.SetActive(true);
        }
    }
}
