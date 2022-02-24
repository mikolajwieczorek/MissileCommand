using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotsPool : MonoBehaviour
{
    public static DotsPool Instance;

    //public static Transform tr; //Pool object transform. Other script is using it to set parent.

    private static GameObject[] dotsPool = new GameObject[10000]; //Array of dots
    public GameObject singleDotPrefab;

    private Vector2 dotsPoolPosition = new Vector2(-10, -10);

    private static int actualDot;    //indicates the next bullet that will be shot

    void Start()
    {
        Instance = GetComponent<DotsPool>();
        //tr = GetComponent<Transform>();
        actualDot = 1;

        //Simply creating desired amount of bullets and assigning them to the array
        for (int i = 0; i < dotsPool.Length; i++)
        {
            dotsPool[i] = (GameObject)Instantiate(singleDotPrefab, dotsPoolPosition, Quaternion.identity, this.transform);
            dotsPool[i].SetActive(false);
        }
    }

    //Setting up the next dot to be drawn
    private static void IncrementActualDot()
    {
        actualDot++;
        if (actualDot >= dotsPool.Length)
            actualDot = 1;
    }

    //Preparing a dot to be drawn on the screen
    public GameObject DrawDot()
    {
        dotsPool[actualDot].SetActive(true);
        IncrementActualDot();
        return dotsPool[actualDot - 1];
    }
}
