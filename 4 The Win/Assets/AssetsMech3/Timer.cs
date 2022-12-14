using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Photon.Pun;
using Photon.Pun.UtilityScripts;

public class Timer : MonoBehaviour 
{

    [SerializeField] private TMP_Text uiText;
    [SerializeField] private TMP_Text uiText_Shadow;

    public int Duration;

    private int remainingDuration;

    private bool Pause;

    public GameObject defeatScreen;
    public GameObject nextButton;

    private void Start()
    {
        Being(Duration);
    }

    private void Being(int Second)
    {
        remainingDuration = Second;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while(remainingDuration >= 0)
        {
            if (!Pause)
            {
                uiText.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
                uiText_Shadow.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
                remainingDuration--;
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
        OnEnd();
    }

    private void OnEnd()
    {
        //End Time , if want Do something
        defeatScreen.SetActive(true);
        if(PhotonNetwork.IsMasterClient){
            nextButton.SetActive(true);
        }
        print("End");
    }
}
