using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeFinal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("WIN");
        }
        
    }
}
