using UnityEngine;

public class GroundSpawner2 : MonoBehaviour
{
	public GameObject groundTile;
	Vector3 nextSpawnPoint2;

	public void nextGroundSpawn2()
	{
		GameObject temp = Instantiate(groundTile, nextSpawnPoint2, Quaternion.identity);
		nextSpawnPoint2 = temp.transform.GetChild(3).transform.position;
		
		

	}
	// Start is called before the first frame update
	void Start()
	{
		for (int i = 0; i < 5; i++)
		{
			if (i < 0)
			{
				nextGroundSpawn2();
			}
			else
			{
				nextGroundSpawn2();

			}

		}



	}

	// Update is called once per frame
	void Update()
	{

	}
}
