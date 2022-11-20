using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehaviour : MonoBehaviour
{
    public bool isFake;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        int colorDecider = Random.Range(0,3);
        switch(colorDecider)
        {
            case 0:
            rend.material.color = new Color(0.5f,0.5f,0.5f);
            break;
            case 1:
            rend.material.color = new Color(0.55f,0.55f,0.55f);
            break;
            case 2:
            rend.material.color = new Color(0.6f,0.6f,0.6f);
            break;

        }

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
