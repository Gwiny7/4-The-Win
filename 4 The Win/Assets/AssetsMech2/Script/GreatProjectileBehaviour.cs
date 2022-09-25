using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreatProjectileBehaviour : MonoBehaviour
{
    public float projectileSpeed;
    GameObject target;
    public GameObject deadProjectile;
    float angle;
    public int projectileHP;
    private bool isDead = false;


    void Start(){
        target = FindObjectOfType<Target>().gameObject;
        
    }

    // Update is called once per frame
    void Update(){
        Move();
        Rotate();
        
    }

    private void OnMouseDown() {
        projectileHP--;
        if(projectileHP<=0)
        {
            Destroy(this.gameObject);
            Instantiate(deadProjectile,transform.position,transform.rotation);
            isDead = true;
        }
        

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

    public bool GetStatus(){
        return isDead;
    }
}
