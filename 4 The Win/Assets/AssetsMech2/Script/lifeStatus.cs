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
    private bool lose;
    private bool win;
    public TextMeshProUGUI lifeText;
    public GameObject gameOverPanel;
    public GameObject victoryPanel;
    public GameObject nextButton;
    public GameObject nextButtonDeath;

    void Start(){
        lose = false;
        win = false;
        lifePoints = FindObjectOfType<characterLife>().GetLife();
    }
    void Update()
    {   
        updateLifePoints();
        updateGameOver();
        updateVictory();
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
          if(PhotonNetwork.IsMasterClient){
                nextButtonDeath.SetActive(true);
            }
        }
    }
    

    private void updateVictory(){
        if(FindObjectOfType<GreatProjectileBehaviour>())
        {   if(FindObjectOfType<GreatProjectileBehaviour>().GetStatus())
            {
            win = true;
            victoryPanel.SetActive(true);
            if(PhotonNetwork.IsMasterClient){
                nextButton.SetActive(true);
            }
            }
        }
    }
    // void updateVictory(){
    //     // if(FindObjectOfType<GreatProjectileBehaviour>().GetStatus())
    //     // {   win = true;
    //     //     victoryPanel.SetActive(true);
    //     // }
    // }

}

