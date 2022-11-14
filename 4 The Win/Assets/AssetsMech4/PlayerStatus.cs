using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

public class PlayerStatus : MonoBehaviour
{
    private blessStatus BS;
    private bool blessed;
    public int maxTry;
    public int tryLeft;
    public GameObject victoryScreen;
    
    void Awake(){
        BS = GetComponent<blessStatus>();
    }
    void Start()
    {
        StartCoroutine(Wait(5.0f));
        
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
        victoryScreen.SetActive(true);
    }
}
