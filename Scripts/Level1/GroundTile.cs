using UnityEngine;

public class GroundTile : MonoBehaviour
{

	GroundSpawner groundSpawner;
	public GameObject[] pickUpsSpawn;
	public GameObject coin;
	public GameObject[] obstacleSpawn;
	public GameObject boss;
	public GameObject pillar;
	bool bossAvtive = false;

	// Start is called before the first frame update
	void Start()
	{
		groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
	}

	private void OnTriggerExit(Collider other)
	{
		groundSpawner.nextGroundSpawn(true);
		Destroy(gameObject, 2);

	}

	public void spawnObstacle1()
	{
		int obstacle = 5;

		for (int i = 0; i < obstacleSpawn.Length; i++)
		{
			obstacleSpawn[i].SetActive(false);
		}

		System.Random random = new System.Random();
		int randomNumber = random.Next(0, obstacleSpawn.Length);
		obstacleSpawn[randomNumber].SetActive(true);
		for (int i = 0; i < obstacle; i++)
		{
			int spawnIndex = Random.Range(4, 7);
			Transform spawnPoint = transform.GetChild(spawnIndex);
			Instantiate(obstacleSpawn[randomNumber], spawnPoint.position, Quaternion.identity, transform);
		}


	}
	public void createCoin()
	{
		int CoinNum = 20;

		for (int i = 0; i < CoinNum; i++)
		{
			GameObject temp = Instantiate(coin, transform);
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
	public void pickUps()
	{
		int pickUpNum = 1;

		for (int i = 0; i < pickUpsSpawn.Length; i++)
		{
			pickUpsSpawn[i].SetActive(false);
		}

		System.Random random = new System.Random();
		int randomNumber = random.Next(0, pickUpsSpawn.Length);
		pickUpsSpawn[randomNumber].SetActive(true);
		for (int i = 0; i < pickUpNum; i++)
		{
			int spawnIndex = Random.Range(7, 10);
			Transform spawnPoint = transform.GetChild(spawnIndex);
			Instantiate(pickUpsSpawn[randomNumber], spawnPoint.position, Quaternion.identity, transform);
		}

	}
	public void bossCreate()
	{
		int bossSpwaner = 1;
		if (GameManager.distanceMade >= 100)
		{
			bossAvtive = true;
			if (bossAvtive == true)
			{
				
					for (int i = 0; i < bossSpwaner; i++)
					{
						int spawnIndex = Random.Range(10, 13);
						Transform spawnPoints = transform.GetChild(spawnIndex);
						Instantiate(boss, spawnPoints.position, Quaternion.identity, transform);
						
						
					}
					
				

			}

		}
		else if(GameManager.distanceMade == 800)
		{
			bossAvtive = false;
		}
	}

	public void pillarSpawner() 
	{
		int Spwaner = 1;
		for (int i = 0; i < Spwaner; i++)
		{
			int spawnIndex = Random.Range(13, 15);
			Transform spawnPoints = transform.GetChild(spawnIndex);
			Instantiate(pillar, spawnPoints.position, Quaternion.identity, transform);


		}

	}
	// Update is called once per frame
	void Update()
	{
		
	}
}
