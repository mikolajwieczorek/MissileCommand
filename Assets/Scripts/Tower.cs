using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Transform tr;   //This tower Transform component
    [SerializeField] private Transform usedMissilesHolder;

    //Missiles controller
    private Transform[] missiles = new Transform[10];
    private int actualMissile = 0;  

    
    void Start()
    {
        tr = GetComponent<Transform>();

        actualMissile = 0;
		for (int i = 0; i < missiles.Length; i++)
		{
            missiles[i] = tr.GetChild(i).transform;
		}
    }

    //When all missiles are used, this reloads them 
    private void RefreshAllMissiles() 
    {
		for (int i = 0; i < missiles.Length; i++)
		{
            missiles[i].parent = tr;
            missiles[i].gameObject.SetActive(true);
        }
    }

    //Removes one missile on single launch
    private void RemoveMissile() 
    {
        missiles[actualMissile].parent = usedMissilesHolder;
        missiles[actualMissile].gameObject.SetActive(false);
        IncrementActualMissile();
    }

    //Returns missiles left at the tower
    private int MissilesLeft()
    {
        return tr.childCount;
    }

    public Vector2 TowerPosition()
    {
        if (MissilesLeft() <= 0)
            return new Vector2(-10f,-10f);

        RemoveMissile();
        return tr.position;
    }

    private void IncrementActualMissile()
    {
        actualMissile++;
        if (actualMissile > 9)
        {
            StartCoroutine(WaitForMissilesRefresh());
            actualMissile = 0;
        }
    }

    //Wait for missiles refresh
    IEnumerator WaitForMissilesRefresh() 
    {
        yield return new WaitForSeconds(10);
        RefreshAllMissiles();
    }
}
