using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LockButton : MonoBehaviour
{
    private int number;
    public TMP_Text numberText;
    void Start()
    {
        number = 1; 
    }

    // Update is called once per frame
    void Update()
    {
        
        numberText.text = number.ToString();
        
    }

    public void Clicked()
    {
        number++;
        if(number == 10)
        {
            number = 0;
        }
    }


    public int GetNumber(){
        return number;
    }

}
