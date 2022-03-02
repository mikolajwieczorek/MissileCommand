using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("WaitForLaunch");
    }

    private void LaunchMissile()
    {
        Vector2 startPosition = RandomizeStartPosition();
        Vector2 destinationPosition = RandomizeTarget();
        MissileSpawnPool.Instance.LaunchMissile(startPosition, destinationPosition, GameController.Instance.timeToReachDestination, "Enemy");
    }

    private Vector2 RandomizeStartPosition()
    {
        Vector2 startPos = new Vector2(Random.Range(-9f, 9f), 5);
        return startPos;
    }

    private Vector2 RandomizeTarget()
    {
        Vector2 temp = BuildingsHolder.Instance.GetRandomBuildingPosition();
        
        return temp;
    }

    IEnumerator WaitForLaunch()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(GameController.Instance.minSpawnSpeed, GameController.Instance.maxSpawnSpeed));
            LaunchMissile();
        }
    }
}
