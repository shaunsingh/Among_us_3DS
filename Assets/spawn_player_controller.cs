using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_player_controller : MonoBehaviour {

	[Header("prefabs to spawn")]
	public GameObject playerPrefab;
	public GameObject dummyPrefab;

	[Header("positions to spawn at")]
	public Transform[] spawnPoints;
	public spawn_point[] spawnPointController;
	public double randSpawn;
	public int randSpawnOut;

	[Header("dummy amount to spawn")]
	public float dummyAmount = 0;
	public float playerAmount = 1;

	[Header("testing")]
	public bool noDummy;
	

	void Start () 
	{
		genRand();
	}

	void genRand()
	{
		randSpawn = System.Math.Round(UnityEngine.Random.Range(0f, 10f));
		randSpawnOut = (int)randSpawn;

		checkDouble();
	}

	void checkDouble()
	{
		if (spawnPointController[randSpawnOut].isTaken == true)
		{
			genRand();
		}
		else if (spawnPointController[randSpawnOut].isTaken == false)
		{
			spawnPlayer();
			if (noDummy == false)
			{
				spawnDummy();
			}
			spawnPointController[randSpawnOut].isTaken = true;
		}
	}

	void spawnDummy()
	{
		if (dummyAmount >= 0)
		{
			Instantiate(dummyPrefab, spawnPoints[randSpawnOut].transform.position, spawnPoints[randSpawnOut].transform.rotation);
			dummyAmount -= 1;
			genRand();
		}
	}

	void spawnPlayer()
	{
		if (playerAmount > 0)
		{
			Instantiate(playerPrefab, spawnPoints[randSpawnOut].transform.position, spawnPoints[randSpawnOut].transform.rotation);
			playerAmount -= 1;
		}
	}
}
