using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPool : MonoBehaviour
{
    public static ExplosionPool Instance;

    private static GameObject[] explosionPool = new GameObject[100]; //Array of explosion objects
    public GameObject explosionPrefab;
    private Vector2 spawnPoolPosition = new Vector2(-15f, -15f);

    private int actualExplosion;    //indicates the next explosion that will be used

    // Start is called before the first frame update
    void Start()
    {
        Instance = GetComponent<ExplosionPool>();
        actualExplosion = 0;

        for (int i = 0; i < explosionPool.Length; i++)
        {
            explosionPool[i] = (GameObject)Instantiate(explosionPrefab, spawnPoolPosition, Quaternion.identity, transform);
            explosionPool[i].SetActive(false);
        }
    }

    private void IncrementActualExplosion()
    {
        actualExplosion++;
        if (actualExplosion >= explosionPool.Length)
            actualExplosion = 0;
    }

    public void Explode(Vector2 explodePosition)
    {
        explosionPool[actualExplosion].SetActive(true);
        explosionPool[actualExplosion].transform.position = explodePosition;

        IncrementActualExplosion();
    }

    public void ExplodeEnded(GameObject explodeGameObject)
    {
        explodeGameObject.transform.position = spawnPoolPosition;
        explodeGameObject.SetActive(false);
    }
}
