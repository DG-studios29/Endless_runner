using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
	public TextMeshProUGUI coinText;
	public TextMeshProUGUI distanceText;

	

	// Start is called before the first frame update
	void Start()
	{
		
		getCoins();
		getDistance();
	}

	// Update is called once per frame
	void Update()
	{

	}
	public void restartGame()
	{
		SceneManager.LoadScene(1);

		GameManager.distanceMade = 0;
		GameManager.coinCollected = 0;
	}
	public void quitGame()
	{
		Debug.Log("You Quit the game");
		Application.Quit();
	}
	public void loadMenu()
	{
		SceneManager.LoadScene(0);
	}
	public void getCoins()
	{
		int collected = GameManager.coinCollected;
		coinText.text = "Coins: " + collected.ToString();

	}
	public void getDistance()
	{
		float distance = GameManager.distanceMade;
		distanceText.text = "Distance: " + distance.ToString("0")+ "m";

	}
	public void levelOne()
	{
		PlayerPrefs.SetInt("Coin", 0);
		SceneManager.LoadScene(1);
		
		GameManager.coinCollected = 0;
	}
	public void levelTwo()
	{
		PlayerPrefs.SetInt("Coin", 0);
		SceneManager.LoadScene(2);
		
		GameManager.coinCollected = 0;
	}
	public void levelThree()
	{
		PlayerPrefs.SetInt("Coin", 0);
		SceneManager.LoadScene(3);
		
		GameManager.coinCollected = 0;
	}
}
