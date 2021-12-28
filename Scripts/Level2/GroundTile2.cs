using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile2 : MonoBehaviour
{
	
	GroundSpawner2 groundSpawner2;
	public GameObject[] pickUpsSpawn2;
	public GameObject coin2;
	public GameObject[] obstacleSpawn2;
	
	
	// Start is called before the first frame update
	void Start()
    {
        groundSpawner2 = GameObject.FindObjectOfType<GroundSpawner2>();
		spawnObstacle2();
		createCoin2();
		pickUps2();
    }

	private void OnTriggerExit(Collider other)
	{
        groundSpawner2.nextGroundSpawn2();
        Destroy(gameObject, 2);

    }

	public void spawnObstacle2()
	{
		int obstacle = 5;

		for (int i = 0; i < obstacleSpawn2.Length; i++)
		{
			obstacleSpawn2[i].SetActive(false);
		}

		System.Random random = new System.Random();
		int randomNumber2 = random.Next(0, obstacleSpawn2.Length);
		obstacleSpawn2[randomNumber2].SetActive(true);
		for (int i = 0; i < obstacle; i++)
		{
			int spawnIndex = Random.Range(4, 7);
			Transform spawnPoint2 = transform.GetChild(spawnIndex);
			Instantiate(obstacleSpawn2[randomNumber2], spawnPoint2.position, Quaternion.identity, transform);
		}


	}
	public void createCoin2()
	{
		int CoinNum = 20;

		for (int i = 0; i < CoinNum; i++)
		{
			GameObject temp = Instantiate(coin2, transform);
			temp.transform.position = randomPoint(GetComponent<Collider>());
		}

		Vector3 randomPoint(Collider collider)
		{
			Vector3 points = new Vector3(
				Random.Range(collider.bounds.min.x, collider.bounds.max.x),
				Random.Range(collider.bounds.min.y, collider.bounds.max.y),
				Random.Range(collider.bounds.min.z, collider.bounds.max.z));

			if (points != collider.ClosestPoint(points))
			{
				points = randomPoint(collider);
			}

			points.y = 1;
			return points;
		}
	}
	public void pickUps2()
	{
		int pickUpNum2 = 1;

		for (int i = 0; i < pickUpsSpawn2.Length; i++)
		{
			pickUpsSpawn2[i].SetActive(false);
		}

		System.Random random = new System.Random();
		int randomNumber2 = random.Next(0, pickUpsSpawn2.Length);

		pickUpsSpawn2[randomNumber2].SetActive(true);
		for (int i = 0; i < pickUpNum2; i++)
		{
			int spawnIndex = Random.Range(6, 10);
			Transform spawnPoint = transform.GetChild(spawnIndex);
			Instantiate(pickUpsSpawn2[randomNumber2], spawnPoint.position, Quaternion.identity, transform);
		}

	}
	
	// Update is called once per frame
	void Update()
    {
        
    }
}
