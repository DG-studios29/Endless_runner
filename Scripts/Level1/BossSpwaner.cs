using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpwaner : MonoBehaviour
{

    private int distanceFromPlayer = 2;
    private GameObject player;
    public List<activatorBoss> activatorBosses;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        activatorBosses = new List<activatorBoss>();

        StartCoroutine(CheckActive());
        
    }

   
    IEnumerator CheckActive()
	{
        List<activatorBoss> removeList = new List<activatorBoss>();

        if (activatorBosses.Count > 0)
		{
            foreach(activatorBoss boss in activatorBosses)
			{
                if (Vector3.Distance(player.transform.position,boss.bossPos) > distanceFromPlayer)
				{
                    if (boss.boss == null)
                    {
                        removeList.Add(boss);
                    }
                    else
                    {
                        boss.boss.SetActive(true);


                    }
                }
                else
				{
                    if (boss.boss == null)
                    {
                        removeList.Add(boss);
                    }
                    else
                    {
                        boss.boss.SetActive(false);
                       
                    }
                }
			}
		}
        yield return new WaitForSeconds(1.0f);

        if (removeList.Count > 0)
        {
            foreach (activatorBoss boss in removeList)
            {
                activatorBosses.Remove(boss);
            }
        }
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(CheckActive());
    }

    public class activatorBoss
    {
        public GameObject boss;
        public Vector3 bossPos;



    }

}
