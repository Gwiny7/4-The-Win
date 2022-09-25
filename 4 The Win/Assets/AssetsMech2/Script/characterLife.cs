using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterLife : MonoBehaviour
{
    public int hitPoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(hitPoints == 0)
        {
            Debug.Log("Está muerto");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="Projectile"){
            Destroy(col.gameObject);
            hitPoints--;
            Debug.Log("Ainda tem:" + hitPoints);
        }
    }

    public int GetLife(){
        return hitPoints;
    }

}
