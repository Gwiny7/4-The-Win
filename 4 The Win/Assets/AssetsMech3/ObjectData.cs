using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ObjectType{circle,square,triangle,cross,diamond}

public class ObjectData : MonoBehaviour
{
    public ObjectType objType;
    public int qtdObj;


    public void setQtd(int qtd){
        qtdObj = qtd;
    }

    public int getQtd(){
        return qtdObj;
    }
}
