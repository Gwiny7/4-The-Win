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
    private PhotonView PV;

    void Start(){
        PV = GetComponent<PhotonView>();
    }

    public void OnClickExit(){
        PhotonNetwork.LeaveRoom();
    }

    public void OnClickAdvance(int level){
        PhotonNetwork.LoadLevel(level);
    }

    public void OnClickPassLevel(){
        PV.RPC("RPC_PlayersWin", RpcTarget.AllBuffered);
        for(int x = 0; x < 4; x++){
            if(PlayerArrayControl.LevelsPassed[x] == 0){
                PlayerArrayControl.LevelsPassed[x] = PlayerArrayControl.currentLevel;
                if(x == 3){
                    PhotonNetwork.LoadLevel("Finish");
                    return;
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
        PhotonNetwork.LoadLevel("WinLossScreen");
    }

    public void OnClickLostLevel(){
        PV.RPC("RPC_PlayersLose", RpcTarget.AllBuffered);
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
        PhotonNetwork.LoadLevel("WinLossScreen");
    }

    public override void OnLeftRoom(){
        for(int x = 0; x < 4; x++){
            PlayerArrayControl.LevelsPassed[x] = 0;
        }
        PlayerArrayControl.DemonLife = 4;
        PlayerArrayControl.PartyLife = 3;
        PlayerArrayControl.win = false;
        SceneManager.LoadScene(0);
    }

    [PunRPC]
    void RPC_PlayersWin(){
        PlayerArrayControl.DemonLife--;
        PlayerArrayControl.win = true;
    }

    [PunRPC]
    void RPC_PlayersLose(){
        PlayerArrayControl.PartyLife--;
        PlayerArrayControl.win = false;
    }
}
