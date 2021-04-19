using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Net.NetworkInformation;

public class connect_player_controller : MonoBehaviour {

	[Header("information")]
	public Text pingAmount;
	public Text playerAmount;

	[Header("button and text color")]
	public Button start;
	public Color notEnough;
	public Color enough;

	[Header("sees the amount of players in the lobby")]
	public GameObject[] player;
	public GameObject[] dummys;

	[Header("random spawn position")]
	public double spawnPosRand;
	public int spawnPosRandOut;

	[Header("actual player amount minimal is 4 to begin game")]
	public float currentPlayerAmount;
	public float maxPlayerAmount = 10;

	[Header("actual ping count if more than 300 you get kicked")]
	public int ping;

	[Header("dummy prefab")]
	public GameObject playerPrefab;
	public GameObject dummy;

	[Header("random dummy spawn positions")]
	public GameObject[] spawn;

	void Start () {
		spawnPlayer();

		//StartCoroutine(updatePingAmount());

		player = GameObject.FindGameObjectsWithTag("player");

		playerAmount = GameObject.Find("playerAmount").GetComponent<Text>();
		pingAmount = GameObject.Find("ping").GetComponent<Text>();
		start = GameObject.Find("start game").GetComponent<Button>();
	}

	void Update () 
	{
		updatePlayerAmount();
	}


	void updatePlayerAmount()
	{
		dummys = GameObject.FindGameObjectsWithTag("dummy");

		currentPlayerAmount = dummys.Length + player.Length;

		playerAmount.text = "Players: " + currentPlayerAmount.ToString() + "/" + maxPlayerAmount.ToString();
		if (currentPlayerAmount <= 3)
		{
			playerAmount.color = notEnough;
			start.interactable = false;
		}
		else
		{
			playerAmount.color = enough;
			start.interactable = true;
		}
	}

	void spawnPlayer()
	{
		spawnPosRand = System.Math.Round(UnityEngine.Random.Range(0f, spawn.Length - 1));
		spawnPosRandOut = (int)spawnPosRand;

		Instantiate(playerPrefab, spawn[spawnPosRandOut].transform.position, spawn[spawnPosRandOut].transform.rotation);
	}

	void spawnDummy()
	{
		
	}

	void despawnDummy()
	{

	}

	/*
	IEnumerator updatePingAmount()
	{

		string IP = NetworkManager.singleton.networkAddress;
		System.Net.NetworkInformation.Ping pingTest = new Ping(IP);

		while (!pingTest.isDone)
		{
			yield return new WaitForSeconds(.1f);
		}
		
		if (pingTest.isDone)
		{
			ping = pingTest.time;
			pingAmount.text = "Ping: " + ping.ToString();
			StartCoroutine(updatePingAmount());
		}
	}
	*/
}
