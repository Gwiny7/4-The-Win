using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{


    public bool blessed;
    public int maxTry;
    public int qntPlayers;
    public int tryLeft;
    
    void Start()
    {
        if(blessed)
        {
            tryLeft = 1;
        }
        else
        {
            tryLeft=maxTry/(qntPlayers-1);
        }
    }

    public void Try()
    {
        tryLeft--;
    }
}
