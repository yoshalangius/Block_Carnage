using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class TempSpawn : MonoBehaviour {

	public GameObject start;
	public GameObject end;
	public GameObject enemy;
	public GameObject enemyCar;
	public GameObject enemyDroid;
	public GameObject enemyCannonDroid;
	public GameObject enemyShieldDroid;
	public GameObject selectedEnemy;
	public static float upgradeLife = 0;

	public static bool wait = true;

	public static float number = 0f;

	public int enemyChoice = 0;

	public float passedTime = 0.1f;
	public float maxTime = 1000f;

	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public float SpawnTime = 3f;

	void Start () 
	{
		Instantiate (start, transform.position, Quaternion.identity);
		StartCoroutine (SpawnWaves ());
	}

	void Update()
	{
		if(health.dead == true)
		{
			number = 0;
			Instantiate (end, transform.position, Quaternion.identity);
			Destroy(gameObject);

		}

		passedTime = passedTime + 0.2f;

		if(selectedEnemy == null)
		{
			selectedEnemy = enemy;
		}
		else if(enemyChoice <= 0)
		{
			selectedEnemy = enemy;
		}
		else if(enemyChoice <= 1)
		{
			selectedEnemy = enemyDroid;
		}
		else if(enemyChoice <= 2)
		{
			selectedEnemy = enemyCar;
		}
		else if(enemyChoice <= 3)
		{
			selectedEnemy = enemyShieldDroid;
		}
		else if(enemyChoice <= 4)
		{
			selectedEnemy = enemyCannonDroid;
		}

		if(passedTime >= maxTime)
		{
			passedTime = 0f;
			enemyChoice = enemyChoice + 1;

		}

		if(enemyChoice >= 5)
		{
			enemyChoice = 0;
		}


	}





	IEnumerator SpawnWaves ()
	{
		if(health.dead == false)
		{

		wait = true;
			yield return new WaitForSeconds (startWait);
			while (true)
			{
			wait = true;

				for (int i = 0; i < hazardCount; i++)
				{

					Instantiate (selectedEnemy);

					yield return new WaitForSeconds (spawnWait);
				}
			wait = false;

				yield return new WaitForSeconds (waveWait);
			}
		wait = true;
		}
	}

	void UpgradeEnemies()
	{
		number = number + 1;
		number = number;
		upgradeLife = number;
		wait = true;
	}

	public void FixedUpdate()
	{

			if(wait == false)
			{
				
				UpgradeEnemies ();
				
			}

	}
}
