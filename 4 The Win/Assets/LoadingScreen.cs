using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

public class LoadingScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject button;
    public float timeToShow;
    void Start()
    {
        StartCoroutine(ButtonSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ButtonSpawner()
    {
        yield return new WaitForSeconds(timeToShow);
        if(PhotonNetwork.IsMasterClient){
            button.SetActive(true);
        }
    }
}
