using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void levelOne()
	{
		PlayerPrefs.SetInt("Coin", 0);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	public void levelTwo()
	{
		PlayerPrefs.SetInt("Coin", 0);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
	}
	public void levelThree()
	{
		PlayerPrefs.SetInt("Coin", 0);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
	}

	public void quitGame()
	{
		Debug.Log("You Quit the game");
		Application.Quit();
	}
}
