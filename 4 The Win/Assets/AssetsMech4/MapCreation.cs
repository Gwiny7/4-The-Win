using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapCreation : MonoBehaviour
{
    public Vector2 gridSize;
    public GameObject Tile;
    
    public GameObject[,] tileMap;
    public GameObject canvas;
    private Vector3 initPosition;
    private Vector2 safePoint;
    public int randSeed;

    void Start()
    {
        Random.seed = randSeed;
        safePoint = new Vector2((int)Random.Range(0,gridSize.x),(int)Random.Range(0,gridSize.y));
        initPosition = transform.position;
        tileMap = new GameObject[(int)gridSize.x,(int)gridSize.y];
        Spawn();
        SafeTileDecider();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        
        
        for(int x = 0; x < gridSize.x; x++)
        {
            
            for(int y=0; y < gridSize.y; y++)
            {      // Debug.Log(x + " , " + y);
               
                transform.position = new Vector3(transform.position.x + 1f*x,transform.position.y - 1f*y, transform.position.z);
                GameObject go;
                
                go = Instantiate(Tile,transform.position,transform.rotation,GameObject.FindGameObjectWithTag("Canvas").transform) as GameObject;
                go.GetComponent<TileBehaviour>().SetTilePos(x,y);
                // if((int)safePoint.x == x && (int)safePoint.y == y)
                // {
                //      go.GetComponent<TileBehaviour>().SetSafeTile(new Vector2(x,y));
                // }
        
                tileMap[x,y] = go; 
                
                
                
                transform.position = initPosition;
            }
        }
        
        

         for(int x = 0; x < gridSize.x; x++)
        {
            
            for(int y=0; y < gridSize.y; y++)
            {
                //Debug.Log("Pos: " + x + "," + y + "bool:" + tileMap[x,y].GetComponent<TileBehaviour>().getTile());

            }
        }
    }

    void SafeTileDecider()
    {
        Debug.Log(safePoint);

        tileMap[(int)safePoint.x,(int)safePoint.y].GetComponent<TileBehaviour>().SetSafeTile(safePoint);
    }
    
    public Vector2 getSafeLocation()
    {
        return safePoint;
    }

    //  Vector2 gridSize;
    //  GameObject[][] gridOfGameObjects;
     
    //  // Use this for initialization
    //  void Start ()
    //  {
    //      gridSize = new Vector2(10, 10);
    //      gridOfGameObjects = new GameObject[(int)gridSize.x][];
    //      for (int x = 0; x < gridSize.x; x++)
    //      {
    //          gridOfGameObjects[x] = new GameObject[(int)gridSize.y];
    //          for (int y = 0; y < gridSize.y; y++)
    //          {
    //              GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //              // manipulate gameobject here
    //              gridOfGameObjects[x][y] = go;
    //          }
    //      }
}
