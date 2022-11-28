using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawningObjects : MonoBehaviour
{
    public GameObject unlockButton;
    public List<GameObject> objects = new List<GameObject>();
    public List<GameObject> objImages = new List<GameObject>();
    private int[] password = new int[4];
    private int qtdCircle;
    private int qtdSquare;
    private int qtdCross;
    private int qtdTriangle;
    private int qtdDiamond;
    private int qtdHeart;
    private int qtdStar;
    public int numberOfRows;
    private int objSelector;
    private int qtdTotal;
    
    void Start()
    {
        Random.seed = PlayerArrayControl.RandomSeed;
        qtdTotal=0;
        resetQtd();
        Spawn();
        GeneratePassword();
        unlockButton.GetComponent<UnlockButton>().SetPassword(password[0],password[1],password[2],password[3]);
    }


    void Spawn()
    {
         for(int y = 0; y < numberOfRows; y++)
        {
            for(int x=0; x < 7; x++)
            {      // Debug.Log(x + " , " + y);
                
                    transform.position = new Vector3(transform.position.x + 2*x,transform.position.y - 2*y, transform.position.z);
                    objSelector = Random.Range(0,7);
                   // Debug.Log(objSelector);
                     Instantiate(objects[objSelector],transform.position,transform.rotation);
                     objects[objSelector].GetComponent<ObjectData>().Plus();
                    qtdTotal++;
               
                    transform.position = new Vector3(-6.0f,3.5f,transform.position.z);

            }
        }
        for(int i = 0 ; i<7 ; i++)
        {
         Debug.Log("Obj1: " + objects[i].GetComponent<ObjectData>().getQtd());
        }
      
       
        
    }
   
    void Update()
    {
        
    }

   public void GeneratePassword()
   {
      int passSelector = 0;
      
      for(int i = 0; i < 4; i++)
      {  
         passSelector = Random.Range(0,objects.Count);
         objImages[i].GetComponent<SpriteRenderer>().sprite = objects[passSelector].GetComponent<SpriteRenderer>().sprite;
         objImages[i].transform.localScale = new Vector3(20f,20f,20f);
         password[i] = objects[passSelector].GetComponent<ObjectData>().getQtd();
         objects.Remove(objects[passSelector]);
         
      }
      Debug.Log("Password is: " + password[0] + " , " + password[1] + " , " + password[2] + " , " + password[3]);
   }

   public void resetQtd()
   {
      for(int i=0; i<7;i++)
      {
         objects[i].GetComponent<ObjectData>().setQtd(0);
      }
   }
}
