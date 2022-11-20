using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 blessView;
    private Camera cam;
    public Transform playerPos;
    public bool blessed;
    
    void Start()
    {
        
    
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(blessed)
        {
            transform.position = blessView;
        }
        else
        {
        transform.position = new Vector3(playerPos.position.x,playerPos.position.y,-10);
        }
        
    }
}
