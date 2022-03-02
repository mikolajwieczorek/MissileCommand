using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    //Instance to that script so the other scripts may use this script functions
    public static SaveLoadSystem Instance;
    private int rankingPlace = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null) 
        {
            Instance = GetComponent<SaveLoadSystem>();
            DontDestroyOnLoad(this);
        }
		else 
        {
            Destroy(this);
        }
    }

    public int SaveHighScore(int endScore)
    {
        //True if it's first start of the game 
        if (!PlayerPrefs.HasKey("firstGameRun"))
        {
            for (int i = 0; i < 10; i++)
            {
                PlayerPrefs.SetInt("highScore_" + i, 0);
            }
            PlayerPrefs.SetInt("playsCounter", 0);
            PlayerPrefs.SetInt("firstGameRun", 1);
        }

        //Iterate through every place in ranking to find where player's score belongs
        for (int i = 0; i < 10; i++)
        {
            if (endScore > PlayerPrefs.GetInt("highScore_" + i))
            {
                rankingPlace = i;
                for (int j = 10; j > i; j--)
                {
                    PlayerPrefs.SetInt("highScore_" + j, PlayerPrefs.GetInt("highScore_" + (j - 1)));
                }
                PlayerPrefs.SetInt("highScore_" + rankingPlace, endScore);
                break;
            }
        }
        PlayerPrefs.SetInt("playsCounter", PlayerPrefs.GetInt("playsCounter") + 1);
        return rankingPlace + 1;  //Returns player's place in ranking
    }

    public void ResetRanking()
    {
        PlayerPrefs.DeleteAll();
    }

    public int[] ShowRanking()
    {
        if (PlayerPrefs.HasKey("firstGameRun"))
        {
            int[] rankArray = new int[10];

            for (int i = 0; i < 10; i++)
            {
                rankArray[i] = PlayerPrefs.GetInt("highScore_" + i);
            }
            return rankArray;
        }
        return null;
    }
}
