using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawnPool : MonoBehaviour
{
	public static MissileSpawnPool Instance; //Other scripts have to use that script's functions

	//Array of missiles used by enemies and player
	private GameObject[] missileArray = new GameObject[50];
	[SerializeField] private GameObject missilePrefab;
	private int actualMissile = 0;

	private void Start()
	{
		
		actualMissile = 0;
		Instance = GetComponent<MissileSpawnPool>();

		for (int i = 0; i < missileArray.Length; i++)
		{
			missileArray[i] = (GameObject)Instantiate(missilePrefab, Vector2.zero, Quaternion.identity, transform);
			missileArray[i].SetActive(false);
		}
	}

	//Used for launching missile at position and setting destination of missile as 'destination' variable
	public void LaunchMissile(Vector2 parentPosition, Vector2 destination, float time, string tag)
	{
		GameObject tempGo = missileArray[actualMissile];

		tempGo.GetComponent<Missile>().SetStartingPoint(parentPosition); //Setting start position
		tempGo.GetComponent<Missile>().SetDestinationPoint(destination, time); //Setting destination point
		tempGo.SetActive(true);
		tempGo.tag = tag;
		IncrementActualMissile();
	}

	//Changing missile of array to manipulate
	private void IncrementActualMissile()
	{
		actualMissile++;
		if (actualMissile >= missileArray.Length)
			actualMissile = 0;
	}
}
