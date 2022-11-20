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
    private int lifePoints;
    private int victoriesNeeded;
    private bool lose;
    private bool win;
    public TextMeshProUGUI lifeText;
    public GameObject gameOverPanel;
    public GameObject victoryPanel;
    public GameObject nextButton;
    public GameObject nextButtonDeath;
    private PhotonView PV;

    void Start(){
        victoriesNeeded = PhotonNetwork.CurrentRoom.PlayerCount - 1;
        PV = GetComponent<PhotonView>();
        lose = false;
        win = false;
        lifePoints = FindObjectOfType<characterLife>().GetLife();
    }
    void Update()
    {   
        updateLifePoints();
        updateGameOver();
        updateVictory();
        if(PhotonNetwork.IsMasterClient && victoriesNeeded <= 0){
            nextButton.SetActive(true);
            nextButtonDeath.SetActive(true);
        }
    }


    void updateLifePoints(){
        lifePoints = FindObjectOfType<characterLife>().GetLife();
        lifeText.text = "Life Points: " + lifePoints;
    }
    void updateGameOver(){
        if(lifePoints == 0 && FindObjectOfType<ProjectileSpawner>().GetStatus())
        { lose = true;
          gameOverPanel.SetActive(true);
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
}

