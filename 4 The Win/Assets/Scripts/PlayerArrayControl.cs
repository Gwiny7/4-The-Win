using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrayControl : MonoBehaviour
{
    static public int[] PlayersActorOrder = { 0, 0, 0, 0 };
    static public bool blessed = false;
    static public int[] Levels = { 2, 3, 4, 5 };
    static public int[] LevelsPassed = { 0, 0, 0, 0 };
    static public int currentLevel = 0;
    static public int RandomSeed = 0;
    static public int PartyLife = 3;
    static public int DemonLife = 4;
    static public bool win = false;
}
