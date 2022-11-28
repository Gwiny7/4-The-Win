using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;

public class MazeStatus : MonoBehaviour
{
    private int victoriesNeeded;
    private bool blessed;
    public GameObject fog;
    public GameObject player;
    public GameObject cam;
    public Vector3 newCamView;
    public GameObject victoryScreen;
    public GameObject nextButton;

    private void Start() {
        if(PhotonNetwork.CurrentRoom.PlayerCount == 2){
            victoriesNeeded = PhotonNetwork.CurrentRoom.PlayerCount - 1;
        }
        else{
            victoriesNeeded = PhotonNetwork.CurrentRoom.PlayerCount - 2;
        }

        blessed = PlayerArrayControl.blessed;
        if(blessed)
        {   
            cam.GetComponent<CameraFollow>().blessed = blessed;
            cam.GetComponent<Camera>().orthographicSize = 18.0f;
            cam.transform.position = newCamView;
            fog.SetActive(false);
            player.SetActive(false);
        }
    }

    private void Update(){
        if(victoriesNeeded <= 0){
            victoryScreen.SetActive(true);
            if(PhotonNetwork.IsMasterClient){
                nextButton.SetActive(true);
            }
        }
    }

    public bool GetBlessed()
    {
        return blessed;
    }

    [PunRPC]
    void RPC_SetVictory(){
        victoriesNeeded--;
    }
}
