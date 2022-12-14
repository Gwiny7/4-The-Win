using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

public class TileBehaviour : MonoBehaviour
{   
    private Vector2 tilePos;
    private bool isSafe = false;
    private Vector2 safePoint;
    private GameObject canvas;
    public Image image;
    private bool blessed;
    public PhotonView PV;
    private PlayerStatus PS;
    
    
    void Start()
    {
        PS = GameObject.Find("StatusManager").GetComponent<PlayerStatus>();
        PV = GameObject.Find("StatusManager").GetComponent<PhotonView>();
        blessed = FindObjectOfType<PlayerStatus>().GetBlessed();
        Debug.Log("TileBehaviour Blessed: " + blessed);        
       // transform.SetParent(canvas.transform,false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTilePos(int x, int y)
    {
        tilePos =  new Vector2(x,y);
    }

    public void SetSafeTile(Vector2 sp)
    {
        this.isSafe = true;
        safePoint = sp;
    }
    public bool getTile()
    {
        return isSafe;
    }

    public void OnClickBlock()
    {
        if(FindObjectOfType<PlayerStatus>().tryLeft > 0){
            PV.RPC("testClick", RpcTarget.AllBuffered, tilePos, PhotonNetwork.LocalPlayer.ActorNumber);
        }
    }

    public void testClick(int actor)
    {   
        if(FindObjectOfType<PlayerStatus>().tryLeft > 0)
        {
            Debug.Log(isSafe);

        Vector2 safePos = FindObjectOfType<MapCreation>().getSafeLocation();
        int distX,distY;
        float colorModifier;

        distX = (int)tilePos.x - (int)safePos.x;
        distX = Mathf.Abs(distX);
        distY = (int)tilePos.y - (int)safePos.y;
        distY = Mathf.Abs(distY);
        if(blessed)
        {
            if(tilePos == safePos)
            {
                image.GetComponent<Image>().color = Color.cyan;
                if(PhotonNetwork.LocalPlayer.ActorNumber == actor){
                    PS.SetVictory();
                }
            }
            else if(distX >= distY)
            {
                if(distX>5)
                {
                image.GetComponent<Image>().color = Color.yellow;
                }
                else{
                colorModifier = distX * 0.2f;
                image.GetComponent<Image>().color = new Color(1f ,0.92f - Mathf.Abs(distX-5)*0.23f,0.016f - Mathf.Abs(distX-5)*0.004f,1f);
                }
                if(PhotonNetwork.LocalPlayer.ActorNumber == actor){
                    PS.SetDefeat();
                }
            }
            else{
                if(distY>5)
                {
                image.GetComponent<Image>().color = Color.yellow;
                }
                else{
                colorModifier = distX * 0.2f;
                image.GetComponent<Image>().color = new Color(1f ,0.92f - Mathf.Abs(distY-5)*0.23f,0.016f - Mathf.Abs(distY-5)*0.004f,1f);
                }
                if(PhotonNetwork.LocalPlayer.ActorNumber == actor){
                    PS.SetDefeat();
                }
            }
        }
        else{
            image.GetComponent<Image>().color = Color.gray;
        }
        if(PhotonNetwork.LocalPlayer.ActorNumber == actor){
            FindObjectOfType<PlayerStatus>().Try();
        }
    }
        
        


        // switch(isSafe)
        // {   case true:
        //     image.GetComponent<Image>().color = new Color32(255,255,225,100);
        //     break;
        //     case false:
        //     image.GetComponent<Image>().color = new Color32(0,0,0,50);
        //     break;

        // }
    }
}
