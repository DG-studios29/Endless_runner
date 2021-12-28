using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Audio;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	public AudioClip gameOverSound;
	public static int coinCollected = 0;
	public static float distanceMade = 0;
	public static bool level2 = false;
	public Transform player;
	public static GameManager inst;
	public TextMeshProUGUI coinText;
	public TextMeshProUGUI distanceText;
	public PlayerControls playerControls;
	bool gameIsOver = false;

	public void gameOver()
	{
		if (gameIsOver == false)
		{
			gameIsOver = true;
			AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
			SceneManager.LoadScene(4);

		}
	}

	public void updateScore()
	{ 

		if (PlayerControls.isMagnet == true)
		{
			coinCollected += coinCollected * 2;
		}
		else
		{
			coinCollected++;
		}
		
		coinText.text = "Coins:" + coinCollected.ToString();
	}
	private void Awake()
	{
		inst = this;



	}
	// Start is called before the first frame update
	void Start()
	{

	}
	
		
// Update is called once per frame
void Update()
	{
		distanceMade = player.position.z;
		distanceText.text = "Distance:" + distanceMade.ToString("0") + "m";

		
		
	}
	private void FixedUpdate()
	{
		if (distanceMade >= 800)
		{
			level2 = true;
			if (level2)
			{
				StartCoroutine(nextLevel());
				SceneManager.LoadScene(2);
			}
		}
	}

	IEnumerator nextLevel()
	{
		yield return new WaitForSeconds(0.2f);
		
	}
}

