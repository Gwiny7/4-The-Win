using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyLifeManager : MonoBehaviour
{   

    public GameObject[] lifes = new GameObject[3];
    public GameObject[] demonLifes = new GameObject[3];
    private int TotalLifes = 3;
    int lifesLeft;
    private int TotalDemonLifes = 4;
    int demonLifesLeft;
    bool win;

  
    void Start()
    {
        win = PlayerArrayControl.win;
        lifesLeft = PlayerArrayControl.PartyLife;
        demonLifesLeft = PlayerArrayControl.DemonLife;
        
        if(win)
        {
            if(TotalDemonLifes > demonLifesLeft)
            {
            demonLifes[demonLifesLeft].GetComponent<Animator>().SetTrigger("DemonHeartExploding");
            
            }
        }
        else{
            if(TotalLifes > lifesLeft)
        {
            
            lifes[lifesLeft].GetComponent<Animator>().SetTrigger("LostLife");
            
            
        }
        }
            for(int i = demonLifesLeft; i<TotalDemonLifes;i++)
            {  Debug.Log(";");
                demonLifes[i].GetComponent<Animator>().SetBool("IsExploded",true);
            }
            for(int i = lifesLeft; i<TotalLifes;i++)
            {Debug.Log(";");
                lifes[i].GetComponent<Animator>().SetBool("IsBroken",true);
            }
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
