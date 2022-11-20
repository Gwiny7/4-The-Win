using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeStatus : MonoBehaviour
{
    private blessStatus BS;
    bool blessed;
    public GameObject fog;
    public GameObject player;
    public GameObject cam;
    public Vector3 newCamView;

    private void Start() {
        BS = GetComponent<blessStatus>();
        StartCoroutine(Wait(5.0f));
    }

    public bool GetBlessed()
    {
        return blessed;
    }

    IEnumerator Wait(float sec){
        yield return new WaitForSeconds(sec);
        blessed = BS.IsBlessed();
        if(blessed)
        {   cam.GetComponent<CameraFollow>().blessed = blessed;
            cam.GetComponent<Camera>().orthographicSize = 18.0f;
            cam.transform.position = newCamView;
            fog.SetActive(false);
            player.SetActive(false);
        }
        yield return null;
    }
}
