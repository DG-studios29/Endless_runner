using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
	GameManager manager;
	// Start is called before the first frame update
	void Start()
	{
		manager = GameObject.FindObjectOfType<GameManager>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Player")
		{
			manager.gameOver();

		}
		else
		{
			GameManager.coinCollected = GameManager.coinCollected + 2;
		}
	}
}
