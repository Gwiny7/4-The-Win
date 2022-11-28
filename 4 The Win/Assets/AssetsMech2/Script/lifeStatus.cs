using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using TMPro;

public class lifeStatus : MonoBehaviour
{
    
    private int victoriesNeeded;
    private int Defeats = 0;
    private bool lose;
    private bool win;
    public List<GameObject> Lifes = new List<GameObject>();
    private int lifesLeft; 
    public Sprite brokenHeart;
    public GameObject gameOverPanel;
    public GameObject victoryPanel;
    public GameObject nextButton;
    public GameObject nextButtonD;
    private PhotonView PV;

    void Start(){
        victoriesNeeded = PhotonNetwork.CurrentRoom.PlayerCount - 1;
        PV = GetComponent<PhotonView>();
        lose = false;
        win = false;
        lifesLeft = FindObjectOfType<characterLife>().GetLife();
    }
    void Update()
    {   
        updateLifePoints();
        updateGameOver();
        updateVictory();
        if(PhotonNetwork.IsMasterClient && victoriesNeeded <= 0){
            nextButton.SetActive(true);
        }
        if(PhotonNetwork.IsMasterClient && Defeats >= 2){
            gameOverPanel.SetActive(true);
            nextButtonD.SetActive(true);
        }
    }


    void updateLifePoints(){
        lifesLeft = FindObjectOfType<characterLife>().GetLife();
    }
    void updateGameOver(){
        if(lifesLeft == 0 && FindObjectOfType<ProjectileSpawner>().GetStatus())
        { lose = true;
          gameOverPanel.SetActive(true);
          PV.RPC("RPC_Lost", RpcTarget.AllBuffered);
          FindObjectOfType<ProjectileSpawner>().SetStatus(false);
        }
    }
    

    private void updateVictory(){
        if(FindObjectOfType<GreatProjectileBehaviour>())
        {   if(FindObjectOfType<GreatProjectileBehaviour>().GetStatus())
            {
                if(!win){
                    PV.RPC("RPC_PlayerWin", RpcTarget.AllBuffered);
                }
                win = true;
                victoryPanel.SetActive(true);
            }
        }
    }

    public void lostLife()
    {
        Lifes[lifesLeft-1].GetComponent<Image>().sprite = brokenHeart;
        Lifes[lifesLeft-1].GetComponent<Image>().color = Color.white;
        Lifes.Remove(Lifes[Lifes.Count-1]);
        lifesLeft--;
        Debug.Log("Lifes left: " + lifesLeft);
    }
    // void updateVictory(){
    //     // if(FindObjectOfType<GreatProjectileBehaviour>().GetStatus())
    //     // {   win = true;
    //     //     victoryPanel.SetActive(true);
    //     // }
    // }
    [PunRPC]

    void RPC_PlayerWin(){
        victoriesNeeded--;
    }

    [PunRPC]

    void RPC_Lost(){
        Defeats++;
    }
}

