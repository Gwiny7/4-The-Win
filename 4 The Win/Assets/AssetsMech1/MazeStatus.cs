using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeStatus : MonoBehaviour
{
    public bool blessed;
    public GameObject fog;
    public GameObject player;
    public GameObject cam;
    public Vector3 newCamView;

    private void Start() {
        if(blessed)
        {   cam.GetComponent<CameraFollow>().blessed = blessed;
            cam.GetComponent<Camera>().orthographicSize = 18.0f;
            cam.transform.position = newCamView;
            fog.SetActive(false);
            player.SetActive(false);
        }

        
    }

    public bool GetBlessed()
    {
        return blessed;
    }
}
