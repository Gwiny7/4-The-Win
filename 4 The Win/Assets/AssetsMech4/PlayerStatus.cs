using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using TMPro;

public class PlayerStatus : MonoBehaviour
{
    private PhotonView PV;
    private bool blessed;
    public int maxTry;
    public int tryLeft;
    public List<GameObject> Lifes = new List<GameObject>();
    public Sprite brokenHeart;
    public GameObject victoryScreen;
    public GameObject defeatScreen;
    public GameObject blessedStatus;
    public GameObject nextButton;
    public GameObject nextButtonD;
    
    void Awake(){
        PV = GetComponent<PhotonView>();
    }
    void Start()
    {
        blessed = PlayerArrayControl.blessed;
        if(blessed)
        {
            tryLeft = 1;
        }
        else
        {
            tryLeft=maxTry/(PhotonNetwork.CurrentRoom.PlayerCount - 1);
        }
        
        for(int i=0; i<9-tryLeft;i++)
        {
            Destroy(Lifes[tryLeft]);
            Lifes.Remove(Lifes[tryLeft]);
            Debug.Log("foi");
        }
        
        Debug.Log("PlayerStatus Blessed: " + blessed);
        
        
    }

    void Update(){
        
        if(blessed){
            blessedStatus.SetActive(true);
        }

    }

    public void Try()
    {
        lostLife();
    }

    public bool GetBlessed(){
        return blessed;
    }
    public void SetVictory(){
        PV.RPC("RPC_Victory", RpcTarget.AllBuffered);
    }
    public void SetDefeat(){
        PV.RPC("RPC_Defeat", RpcTarget.AllBuffered);
    }

    public void lostLife()
    {
        //erro de índice aqui
        Lifes[tryLeft-1].GetComponent<Image>().sprite = brokenHeart;
        Lifes[tryLeft-1].GetComponent<Image>().color = Color.white;
        Lifes.Remove(Lifes[Lifes.Count-1]);
        tryLeft--;
        Debug.Log("Lifes left: " + tryLeft);
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
