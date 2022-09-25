using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    //
    public float projectileSpeed;
    GameObject target;
    public GameObject deadProjectile;
    float angle;

   



    void Start(){
        target = FindObjectOfType<Target>().gameObject;
        
    }

    // Update is called once per frame
    void Update(){
        Move();
        Rotate();
        
    }

    private void OnMouseDown() {
        Destroy(this.gameObject);
        Instantiate(deadProjectile,transform.position,transform.rotation);
    }

    private void Move(){
        transform.position = Vector2.MoveTowards(transform.position,target.transform.position,projectileSpeed * Time.deltaTime);
        
    }

    private void Rotate(){
        Vector3 targetDir = target.transform.position - transform.position;
        if(transform.position.x>0f)
        {
        angle = Vector3.Angle(targetDir, new Vector3(0,1,0));
        }
        else
        {
        angle = -Vector3.Angle(targetDir, new Vector3(0,1,0));
        }
        //Debug.Log(angle);
        transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
    }

}

