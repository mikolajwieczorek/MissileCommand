using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsHolder : MonoBehaviour
{
    public static BuildingsHolder Instance;

    private GameObject[] buildings = new GameObject[9];

    void Start()
    {
        if(Instance == null)
            Instance = this;

		for (int i = 0; i < buildings.Length; i++)
		{
            buildings[i] = transform.GetChild(i).gameObject;
		}
    }

    private bool CheckIfAnyBuildingIsEnabled() 
    {
		for (int i = 0; i < buildings.Length; i++)
		{
            if (buildings[i].CompareTag("Tower") && buildings[i].activeSelf)
                return true;
		}
        return false;
    }

    public Vector2 GetRandomBuildingPosition()
    {
        if (CheckIfAnyBuildingIsEnabled())
        {
            int rand = 0;

            do
            {
                rand = Random.Range(0, 9);
            } while (!buildings[rand].activeSelf);
            return buildings[rand].transform.position;
        }
        GameController.Instance.GameOver();
        return Vector2.zero;
    }
}
