using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject statisticsPanel;
	public Text rankingText;
	public Text playsCounterText;


	private void Start()
	{
		HideRanking();
	}

	public void RunGameScreen()
	{
		SceneManager.LoadScene("GameScene");
	}

	public void ShowRanking()
	{
		statisticsPanel.SetActive(true);
		rankingText.text = GetStatistics();
		if (PlayerPrefs.HasKey("playsCounter"))
			playsCounterText.text = "Total games played:\n" + PlayerPrefs.GetInt("playsCounter").ToString();
		else
			playsCounterText.text = "Play already.";
	}

	public void HideRanking()
	{
		statisticsPanel.SetActive(false);
	}

	private string GetStatistics()
	{
		if (PlayerPrefs.HasKey("firstGameRun"))
		{
			int[] arr = SaveLoadSystem.Instance.ShowRanking();
			return
				"\n1: " + arr[0] +
				"\n2: " + arr[1] +
				"\n3: " + arr[2] +
				"\n4: " + arr[3] +
				"\n5: " + arr[4] +
				"\n6: " + arr[5] +
				"\n7: " + arr[6] +
				"\n8: " + arr[7] +
				"\n9: " + arr[8] +
				"\n10: " + arr[9];
		}
		return "You haven't\n played yet";
	}
}
