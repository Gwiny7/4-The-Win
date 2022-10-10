using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningObjects : MonoBehaviour
{
    public GameObject circle;
    public GameObject square;
    public GameObject cross;
    public GameObject diamond;
    public GameObject triangle;

    private int qtdCircle;
    private int qtdSquare;
    private int qtdCross;
    private int qtdTriangle;
    private int qtdDiamond;

    public int randSeed;

    private int objSelector;
    private int qtdTotal;
    
    void Start()
    {
        Random.seed = randSeed;
        qtdTotal=0;
        Spawn();
        
    }


    void Spawn()
    {
         for(int y = 0; y < 3; y++)
        {
            for(int x=0; x < 7; x++)
            {      // Debug.Log(x + " , " + y);
                
                    transform.position = new Vector3(transform.position.x + 2*x,transform.position.y - 2*y, transform.position.z);
                    objSelector = Random.Range(1,6);
                   // Debug.Log(objSelector);
                    switch(objSelector){
                        case 1:
                     //   Debug.Log("case1");
                        Instantiate(circle,transform.position,transform.rotation);
                        qtdCircle++;
                        break;
                        case 2:
                     //   Debug.Log("case2");
                        Instantiate(square,transform.position,transform.rotation);
                        qtdSquare++;
                        break;
                        case 3:
                     //   Debug.Log("case3");
                        Instantiate(cross,transform.position,transform.rotation);
                        qtdCross++;
                        break;
                        case 4:
                     //   Debug.Log("case4");
                        Instantiate(diamond,transform.position,transform.rotation);
                        qtdDiamond++;
                        break;
                        case 5:
                     //   Debug.Log("case5");
                        Instantiate(triangle,transform.position,transform.rotation);
                        qtdTriangle++;
                        break;
                    }
                    qtdTotal++;
               
                    transform.position = new Vector3(-6.0f,3.5f,transform.position.z);

            }
        }
        Debug.Log("Quantidade de Círculos: " + qtdCircle);
        Debug.Log("Quantidade de Quadrados: " + qtdSquare);
        Debug.Log("Quantidade de Cruzes: " + qtdCross);
        Debug.Log("Quantidade de Triangulo: " + qtdTriangle);
        Debug.Log("Quantidade de Diamantes: " + qtdDiamond);
        Debug.Log("Quantidade Total: " + qtdTotal);
        circle.GetComponent<ObjectData>().setQtd(qtdCircle);
        square.GetComponent<ObjectData>().setQtd(qtdSquare);
        cross.GetComponent<ObjectData>().setQtd(qtdCross);
        diamond.GetComponent<ObjectData>().setQtd(qtdDiamond);
        triangle.GetComponent<ObjectData>().setQtd(qtdTriangle);
       
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    // int getQtdObject(string name)
    // {   switch(name)
    //     {   case "circle":
    //         return qtdCircle.y;
    //         break
    //         case "square":
    //         return qtdSquare.y;
    //         break
    //         case "triangle":
    //         return qtdTriangle.y;
    //         break
    //         case "diamond":
    //         return qtdDiamond.y;
    //         break
    //         case "cross":
    //         return qtdCross.y;
    //         break

    //     }

    // }
}
