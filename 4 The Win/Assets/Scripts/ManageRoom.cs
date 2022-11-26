using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class ManageRoom : MonoBehaviourPunCallbacks
{
    bool pass = false;
    int nextIndex;
    public void OnClickExit(){
        PhotonNetwork.LeaveRoom();
    }

    public void OnClickAdvance(int level){
        PhotonNetwork.LoadLevel(level);
    }

    public void OnClickPassLevel(){
        for(int x = 0; x < 4; x++){
            if(PlayerArrayControl.LevelsPassed[x] == 0){
                PlayerArrayControl.LevelsPassed[x] = PlayerArrayControl.currentLevel;
                if(x == 3){
                    PhotonNetwork.LoadLevel("Finish");
                }
                break;
            }
        }
        
        do{
            pass = true;
            nextIndex = Random.Range(2, 6);
            for(int y = 0; y < 4; y++){
                if(nextIndex == PlayerArrayControl.LevelsPassed[y]){
                    pass = false;
                    break;
                }
            }
        }while(pass == false);
        PlayerArrayControl.currentLevel = nextIndex;
        PhotonNetwork.LoadLevel(nextIndex);
    }

    public override void OnLeftRoom(){
        for(int x = 0; x < 4; x++){
            PlayerArrayControl.LevelsPassed[x] = 0;
        }
        SceneManager.LoadScene(0);
    }
}
