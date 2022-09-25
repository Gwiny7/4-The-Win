using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class lifeStatus : MonoBehaviour
{
    private int lifePoints;
    private bool lose;
    private bool win;
    public TextMeshProUGUI lifeText;
    public GameObject gameOverPanel;


    void Start(){
        lose = false;
        win = false;
        lifePoints = FindObjectOfType<characterLife>().GetLife();
    }
    void Update()
    {   
        updateLifePoints();
        updateGameOver();
        
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
}

