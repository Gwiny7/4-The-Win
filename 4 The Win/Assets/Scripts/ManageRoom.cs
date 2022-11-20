using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class ManageRoom : MonoBehaviourPunCallbacks
{
    public void OnClickExit(){
        PhotonNetwork.LeaveRoom();
    }

    public void OnClickAdvance(int level){
        PhotonNetwork.LoadLevel(level);
    }

    public override void OnLeftRoom(){
        SceneManager.LoadScene(0);
    }
}
