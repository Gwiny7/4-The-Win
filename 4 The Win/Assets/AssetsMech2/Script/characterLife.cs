using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterLife : MonoBehaviour
{
    public int hitPoints;
    public lifeStatus lStatus;
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
            lStatus.lostLife();
            //Debug.Log("Ainda tem:" + hitPoints);
        }

        if(col.gameObject.tag=="GreatProjectile"){
            Destroy(col.gameObject);
            for(int i=0;i<hitPoints;i++)
            {
                hitPoints--;
                lStatus.lostLife();
            }
            
            //Debug.Log("Ainda tem:" + hitPoints);
        }
    }

    public int GetLife(){
        return hitPoints;
    }

}
