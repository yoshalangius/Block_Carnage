﻿using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
	public GameObject enemy;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	void Start ()
	{
		StartCoroutine (SpawnWaves ());
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Instantiate (enemy);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}