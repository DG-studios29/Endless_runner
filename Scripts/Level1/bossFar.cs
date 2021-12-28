using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossFar : MonoBehaviour
{
    private GameObject bossActive;
    private BossSpwaner spwaner;
    // Start is called before the first frame update
    void Start()
    {
        bossActive = GameObject.Find("bossActive");
        spwaner = bossActive.GetComponent<BossSpwaner>();

        StartCoroutine(addToList());
    }

   IEnumerator addToList()
	{
        yield return new WaitForSeconds(0.1f);
        spwaner.activatorBosses.Add(new BossSpwaner.activatorBoss { boss = this.gameObject, bossPos = transform.position });
    }
}
