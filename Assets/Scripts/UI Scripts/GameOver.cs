using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text endScoreText;
    public Text rankingPlaceText;

    void Start()
    {
        ShowAllInformation();
    }

    private void ShowAllInformation()
    {
        endScoreText.text = "Your final score:\n" + GameController.Instance.GetScore();

        rankingPlaceText.text = "Your ranking place is: " + SaveLoadSystem.Instance.SaveHighScore(GameController.Instance.GetScore());
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
