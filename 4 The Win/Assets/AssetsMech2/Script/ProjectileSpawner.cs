using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject Alert;
    
    private Vector3[] spawnPoints = { new Vector3 { x = 13f, y = 2f, z = 0f}, 
                             new Vector3 { x = 12f, y = 5f,z = 0f},
                             new Vector3 { x = 12f, y = -5f,z = 0f}, 
                             new Vector3 { x = 13f, y = -2f,z = 0f},
                             new Vector3 { x = -13f, y = 2,z = 0f}, 
                             new Vector3 { x = -12f, y = 5f,z = 0f},
                             new Vector3 { x = -12f, y = -5f,z = 0f},
                             new Vector3 { x = -13f, y = -2f,z = 0f}};

    public int randSeed;
    public int qtdProjectiles;
    private int randSpawner;
    public float timeBetweenSpawns;
    public float alertTimer;
    private Vector3 alertPosition;
    public bool blessed;
    private bool isAlive;
    
    void Start()
    {   isAlive = true;
        Random.seed = randSeed;
        StartCoroutine(spawnProjectiles());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator spawnProjectiles()
    {
        
            for(int i=0 ; i<qtdProjectiles ; i++)
            {  
                if(isAlive){
                Debug.Log(isAlive);
                randSpawner = Random.Range(0,8);
                //Debug.Log(randSpawner);
                transform.position = spawnPoints[randSpawner];
                if(blessed)
                {
                    alertPosition = new Vector3(-transform.position.x,-transform.position.y,transform.position.z);
                    alertPosition = alertPosition - Vector3.Scale(alertPosition.normalized, new Vector3(5,5,1));
                    alertPosition = -alertPosition;
                    //Debug.Log(alertPosition);
                    Instantiate(Alert,alertPosition,Quaternion.identity);
                    yield return new WaitForSeconds(alertTimer);
                }
                Instantiate(Projectile,transform.position,transform.rotation);
                yield return new WaitForSeconds(timeBetweenSpawns);
                }
                else{
                    StopCoroutine(spawnProjectiles());
                }
            }
            
        
        
    }

    public bool GetStatus(){
        return isAlive;
    }
    public void SetStatus(bool status){
        isAlive = status;
    }
}
