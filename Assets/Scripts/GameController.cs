using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public GameObject gameOverPanel;

    public Text scoreText;
    private int score;

    private float gameDifficulty = 0;
    [HideInInspector]
    public float timeToReachDestination = 0;
    private float startingTimeToReach = 25;
    [HideInInspector]
    public float minSpawnSpeed = 0;
    private float startingMinSpawnSpeed = 0.5f;
    [HideInInspector]
    public float maxSpawnSpeed = 0;
    private float startingMaxSpawnSpeed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
        timeToReachDestination = startingTimeToReach;
        minSpawnSpeed = startingMinSpawnSpeed;
        maxSpawnSpeed = startingMaxSpawnSpeed;

        Instance = this;
        score = 0;
        UpdateScoreOnScreen();
    }

    private void RecalculateDifficulty()
    {
        gameDifficulty = (float)score / 1000;
        UpdateDifficulty();
    }

    //Updating values of: time of a enemy missile to reach the target, min and max time to spawn next enemy missile
    private void UpdateDifficulty()
    {
        timeToReachDestination = startingTimeToReach - (gameDifficulty * 25);
        minSpawnSpeed = startingMinSpawnSpeed - (gameDifficulty * 0.5f);
        maxSpawnSpeed = startingMaxSpawnSpeed - (gameDifficulty * 0.5f);
    }

    public void GameOver() 
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    #region scoreHandler

    public int GetScore() 
    {
        return score;
    }

	public void IncreaseScore()
	{
        score += 5;
        UpdateScoreOnScreen();
        RecalculateDifficulty();
	}

    public void DecreaseScore() 
    {
        score -= 50;
        if (score < 0)
            score = 0;
        UpdateScoreOnScreen();
    }

    private void UpdateScoreOnScreen() 
    {
        scoreText.text = score.ToString();
    }

	#endregion
}
