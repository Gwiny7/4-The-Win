using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float projectileSpeed;
    GameObject target;
    public GameObject deadProjectile;


    void Start()
    {
        target = FindObjectOfType<Target>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        
    }

    private void OnMouseDown() {
        Destroy(this.gameObject);
        Instantiate(deadProjectile,transform.position,transform.rotation);
    }

    private void Move(){
        transform.position = Vector2.MoveTowards(transform.position,target.transform.position,projectileSpeed * Time.deltaTime);
    }
}

