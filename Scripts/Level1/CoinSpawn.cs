using UnityEngine;
using UnityEngine.Audio;

public class CoinSpawn : MonoBehaviour
{
	float CoinRotat = 90f;
	public AudioClip coinSound;

	void Start()
	{
		
	}


	private void OnTriggerEnter(Collider other)
	{
		

		if (other.gameObject.GetComponent<ObstacleTrigger>() != null)
		{
			Destroy(gameObject);
			return;
		}

		if (other.gameObject.name != "Player")
		{
			return;
		}

		Destroy(gameObject);
		AudioSource.PlayClipAtPoint(coinSound, transform.position);
		GameManager.inst.updateScore();
		

	}

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(0, CoinRotat * Time.deltaTime, 0);




	}
}
