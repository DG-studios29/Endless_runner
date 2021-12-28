using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 nextSpawnPoint;

    public void nextGroundSpawn(bool spawnObstacles)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(3).transform.position;
		if (spawnObstacles)
		{
			temp.GetComponent<GroundTile>().createCoin();
			temp.GetComponent<GroundTile>().spawnObstacle1();
			temp.GetComponent<GroundTile>().pickUps();
            temp.GetComponent<GroundTile>().bossCreate();
            temp.GetComponent<GroundTile>().pillarSpawner();

        }

	}
    // Start is called before the first frame update
    void Start()
	{
		for (int i = 0; i < 5; i++)
		{
            if (i < 0)
            {
                nextGroundSpawn(false);
            }
            else
            {
                nextGroundSpawn(true);

            }
            
        }

        
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
