using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChancesLeft : MonoBehaviour
{   
   
    public List<GameObject> Lifes = new List<GameObject>();
    private int lifesLeft;    

    // Start is called before the first frame update
    void Start()
    {
        lifesLeft = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void Spawn()
    // {
    //     for(int i=0;i<3;i++)
    //     {
    //         Lifes.Add(lifePoint);
    //         Instantiate(Lifes[i],transform.position,transform.rotation);
    //         transform.position = new Vector3(transform.position.x, transform.position.y -2f,transform.position.z);
    //     }
    // }

    public void lostLife()
    {
        Lifes[Lifes.Count-1].SetActive(false);
        Lifes.Remove(Lifes[Lifes.Count-1]);
        lifesLeft--;
        Debug.Log("Lifes left: " + lifesLeft);
    }

}
