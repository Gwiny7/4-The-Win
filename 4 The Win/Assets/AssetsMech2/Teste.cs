using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    private float[] noiseValues;
    void Start() {
        Random.seed = 42;
        noiseValues = new float[10];
        int i = 0;
        while (i < noiseValues.Length) {
            noiseValues[i] = Random.value;
            print(noiseValues[i]);
            i++;
        }
    }
}
