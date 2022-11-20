using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using TMPro;

public class PlayerStatus : MonoBehaviour
{
    private blessStatus BS;
    private PhotonView PV;
    private bool blessed;
    public int maxTry;
    public int tryLeft;
    public GameObject victoryScreen;
    public GameObject blessedStatus;
    public TMP_Text tryStatus;
    
    void Awake(){
        PV = GetComponent<PhotonView>();
        BS = GetComponent<blessStatus>();
    }
    void Start()
    {
        StartCoroutine(Wait(5.0f));
        
    }

    void Update(){
        tryStatus.text = ("Tries Left: " + tryLeft);
        if(blessed){
            blessedStatus.SetActive(true);
        }
    }

    public void Try()
    {
        tryLeft--;
    }

    public bool GetBlessed(){
        return blessed;
    }

    IEnumerator Wait(float sec){
        yield return new WaitForSeconds(sec);
        blessed = BS.IsBlessed();
        Debug.Log("PlayerStatus Blessed: " + blessed);
        if(blessed)
        {
            tryLeft = 1;
        }
        else
        {
            tryLeft=maxTry/(PhotonNetwork.CurrentRoom.PlayerCount - 1);
        }
        yield return null;
    }

    public void SetVictory(){
        PV.RPC("RPC_Victory", RpcTarget.AllBuffered);
    }

    [PunRPC]

    void RPC_Victory(){
        victoryScreen.SetActive(true);
    }
}
