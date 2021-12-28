using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{
	public static bool gamePause2 = false;
	public GameObject pauseUI2;
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (gamePause2)
			{
				resumeGame();
			}
			else
			{
				pauseGame();
			}
		}
	}
	public void resumeGame()
	{
		pauseUI2.SetActive(false);
		Time.timeScale = 1f;
		gamePause2 = false;

	}
	void pauseGame()
	{
		pauseUI2.SetActive(true);
		Time.timeScale = 0f;
		gamePause2 = true;
	}

	public void loadMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(0);
	}
	public void quitGame()
	{
		Debug.Log("You Quit the game");
		Application.Quit();
	}
	public void restartGame()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
