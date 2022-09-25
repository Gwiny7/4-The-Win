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
    private int qtdProjectiles;
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
        updateQtdProjectiles();
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

    void updateQtdProjectiles(){
        if(qtdProjectiles <= 2  && FindObjectOfType<ProjectileSpawner>().ProjectileLeft() == 0)
        {
            win = true;
            gameOverPanel.SetActive(true);
        }
    }

    public void hitProjectile(){
        qtdProjectiles--;
    }
}

