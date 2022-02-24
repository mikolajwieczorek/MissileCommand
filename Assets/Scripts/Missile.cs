using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
	private Transform tr;

	//Drawing a tail of a missile (to beautify the project ^^)
	private GameObject[] dotsArray = new GameObject[300];
	private int actualDot = 0;
	private float timeToDrawNextDot = 0;

	//Starting and destination point of a missile
	private Vector2 startingPoint = new Vector2(-20f,-20f);
    private Vector2 destinationPoint;

	//Used to determine time needed to reach the target
	private float timePassed = 0;
	private float timeToReachTarget = 0;

	private void OnEnable()
	{
		timeToDrawNextDot = TimeBetweenDotsDraw();
		tr = GetComponent<Transform>();
		tr.position = startingPoint;
		InvokeRepeating("DrawTheLine", 0, timeToDrawNextDot);
	}

	private void OnDisable()
	{
		CancelInvoke("DrawTheLine");

		for (int i = 0; i < dotsArray.Length; i++)
		{
			if (dotsArray[i] == null)
			{
				Debug.Log("...BREAK!");
				break;
			}
			else
			{
				dotsArray[i].SetActive(false);
				dotsArray[i] = null;
			}

		}
		actualDot = 0;

		timePassed = 0;
	}

	void Update()
    {
		timePassed += Time.deltaTime / timeToReachTarget;
		tr.position = Vector3.Lerp(startingPoint, destinationPoint, timePassed);
		if (tr.position == (Vector3)destinationPoint)
		{
			TimeToExplode();
		}
    }

	//Sets starting position of a missile
	public void SetStartingPoint(Vector2 startPos)
	{
		startingPoint = startPos;
		tr.position = startingPoint;
	}

	//Sets destination position of a missile
	//In enemies case it's one of buildings and in player's case its mouse position
	public void SetDestinationPoint(Vector2 destPos, float timeToReach) 
	{
		destinationPoint = destPos;
		timeToReachTarget = timeToReach;
	}

	public void TimeToExplode()
	{
		ExplosionPool.Instance.Explode(tr.position);
		this.gameObject.SetActive(false);
	}

	#region LineDrawing
	private float TimeBetweenDotsDraw() 
	{
		return DistanceBetweenPoints() * timeToReachTarget / 1000;
	}

	private float DistanceBetweenPoints() 
	{
		return Mathf.Sqrt(
			Mathf.Pow(destinationPoint.x - startingPoint.x, 2) + 
			Mathf.Pow(destinationPoint.y - startingPoint.y, 2));
	}

	private void DrawTheLine()
	{
		dotsArray[actualDot] = DotsPool.Instance.DrawDot();
		dotsArray[actualDot].transform.position = tr.position;
		IncrementActualDotValue();
	}

	private void IncrementActualDotValue() 
	{
		actualDot++;
		if (actualDot >= dotsArray.Length)
			actualDot = 0;
	}
	#endregion

	//Detects collisions
	private void OnTriggerEnter2D(Collider2D collision)
	{
		
	}
}
