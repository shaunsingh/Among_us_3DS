using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class button_controller : MonoBehaviour {

	public GameObject[] main;
	public GameObject[] local;
	public GameObject[] online;
	public GameObject[] how;

	public string window = "main";

	[Header("for connection checks")]
	//public Image localPlay;
	//public Image onlinePlay;
	public Button localPlayButton;
	public Button onlinePlayButton;

	public void localPlay()
	{

	}

	public void onlinePlay()
	{
		SceneManager.LoadScene("lobby");
	}

	public void freePlay()
	{
		SceneManager.LoadScene("skeld");
		Resources.UnloadUnusedAssets();
	}

	public void howToPlay()
	{
		foreach(GameObject mainObjects in main)
		{
			mainObjects.SetActive(false);
		}

		foreach(GameObject helpObjects in how)
		{
			helpObjects.SetActive(true);
			window = "help";
		}
	}

	public void back()
	{
		if (window == "local")
		{

		}
		else if (window == "online")
		{

		}
		else if (window == "help")
		{
			foreach (GameObject mainObjects in main)
			{
				mainObjects.SetActive(true);
			}

			foreach (GameObject helpObjects in how)
			{
				helpObjects.SetActive(false);
				window = "main";
			}
		}
	}

	public void accessPointConnected()
	{
		onlinePlayButton.interactable = true;
	}

	public void wirelessConnected()
	{
		localPlayButton.interactable = true;
	}
}
