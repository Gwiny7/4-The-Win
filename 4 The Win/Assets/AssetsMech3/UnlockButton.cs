using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class UnlockButton : MonoBehaviour
{

    private int[] number = new int[4];
    private int[] password = new int[4];
    public bool correctPassword = false;
    public GameObject[] locks = new GameObject[4];
    public PhotonView PV;
    
    void Start()
    {   
        for(int i = 0;i<4;i++)
        {
            number[i] = locks[i].GetComponent<LockButton>().GetNumber();
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clicked()
    {   bool correct = true;
        int z=0;
        for(int i = 0;i<4;i++)
        {
            number[i] = locks[i].GetComponent<LockButton>().GetNumber();
        }
        if(CheckPassword())
        {
            Debug.Log("Acertou");
            PV.RPC("RPC_Victory", RpcTarget.AllBuffered);
        }
        else
        {
            wrongPassword();
        }
        
    }

    public void SetPassword(int num1, int num2, int num3, int num4)
    {
        password[0]=num1;
        password[1]=num2;
        password[2]=num3;
        password[3]=num4;
    }

    public bool CheckPassword()
    {
        for(int i=0;i<4;i++)
        {
            if(number[i] != password[i])
            {
                return false;
            }
        }

        return true;
    }

    public void wrongPassword()
    {
        FindObjectOfType<ChancesLeft>().lostLife();
    }
}
