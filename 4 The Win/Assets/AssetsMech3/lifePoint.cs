using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifePoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void lostLife()
    {
        Destroy(this.gameObject);
    }
}
