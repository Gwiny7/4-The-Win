using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

public class TimerSceneEnd : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SkipScene());
    }

    IEnumerator SkipScene(){
        yield return new WaitForSeconds(time);
        if(PhotonNetwork.IsMasterClient){
            PhotonNetwork.LoadLevel(PlayerArrayControl.currentLevel);
        }
    }
}
