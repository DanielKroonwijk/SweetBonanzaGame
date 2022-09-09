using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;


public class InititiateGameObjects : MonoBehaviour
{
    public GameObject symbol0;
    public GameObject symbol1;
    public GameObject symbol2;
    public GameObject symbol3;
    public GameObject symbol4;
    public GameObject symbol5;
    public GameObject symbol6;
    public GameObject symbol7;
    public GameObject symbol8;
    public GameObject symbol9;
    public GameObject symbol10;

    public void Initiate(out GameObject[] gameObjects)
    {
        gameObjects = new GameObject[11];

        gameObjects[0] = symbol0;
        gameObjects[1] = symbol1;
        gameObjects[2] = symbol2;
        gameObjects[3] = symbol3;
        gameObjects[4] = symbol4;
        gameObjects[5] = symbol5;
        gameObjects[6] = symbol6;
        gameObjects[7] = symbol7;
        gameObjects[8] = symbol8;
        gameObjects[9] = symbol9;
        gameObjects[10] = symbol10;
    }
}


