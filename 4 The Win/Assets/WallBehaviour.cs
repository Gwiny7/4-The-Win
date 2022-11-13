using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehaviour : MonoBehaviour
{
    public bool isFake;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(!isFake)
        {
            if(other.gameObject.tag == "Player")
            {
                Debug.Log("GameOver");
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
}
