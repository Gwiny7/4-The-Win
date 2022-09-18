using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject Projectile;
    private Vector3[] spawnPoints = { new Vector3 { x = 0f, y = 6.5f, z = 0f}, 
                             new Vector3 { x = 10.5f, y = 6.5f,z = 0f},
                             new Vector3 { x = -10.5f, y = 6.5f,z = 0f}, 
                             new Vector3 { x = 10.5f, y = 0,z = 0f},
                             new Vector3 { x = -10.5f, y = 0,z = 0f}, 
                             new Vector3 { x = 0f, y = -6.5f,z = 0f},
                             new Vector3 { x = 10.5f, y = -6.5f,z = 0f},
                             new Vector3 { x = -10.5f, y = -6.5f,z = 0f}};

    public int randSeed;
    public int qtdProjectiles;
    private int randSpawner;
    public float timeBetweenSpawns;
    
    void Start()
    {
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
        randSpawner = Random.Range(0,8);
        Debug.Log(randSpawner);
        transform.position = spawnPoints[randSpawner];
        Instantiate(Projectile,transform.position,transform.rotation);
        yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
}
