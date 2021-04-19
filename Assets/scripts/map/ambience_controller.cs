using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ambience_controller : MonoBehaviour {

	public Text room;
	public AudioSource ambiencePlayer;

	public AudioClip[] ambienceClips;
	public int whichRoom = 0;

	public bool isCafeteria = true;
	public bool isMedbay = false;
	public bool isEngine = false;
	public bool isReactor = false;
	public bool isSecurity = false;
	public bool isElectrical = false;
	public bool isStorage = false;
	public bool isAdmin = false;
	public bool isCommunication = false;
	public bool isShields = false;
	public bool isO2 = false;
	public bool isNavigation = false;
	public bool isWeapons = false;
	public bool isHallway = false;

	void Start()
	{
		setSound();
	}

	public void setSound () {
		if (isCafeteria)
		{
			whichRoom = 0;
			room.text = "Cafeteria";
		}
		else if (isMedbay)
		{
			whichRoom = 1;
			room.text = "Medbay";
		}
		else if (isEngine)
		{
			whichRoom = 2;
			room.text = "Engine Room";
		}
		else if (isReactor)
		{
			whichRoom = 3;
			room.text = "Reactor";
		}
		else if (isSecurity)
		{
			whichRoom = 4;
			room.text = "Security";
		}
		else if (isElectrical)
		{
			whichRoom = 5;
			room.text = "Electrical";
		}
		else if (isStorage)
		{
			whichRoom = 6;
			room.text = "Storage";
		}
		else if (isAdmin)
		{
			whichRoom = 7;
			room.text = "Admin";
		}
		else if (isCommunication)
		{
			whichRoom = 8;
			room.text = "Communication";
		}
		else if (isShields)
		{
			whichRoom = 9;
			room.text = "Shields";
		}
		else if (isO2)
		{
			whichRoom = 10;
			room.text = "o2";
		}
		else if (isNavigation)
		{
			whichRoom = 11;
			room.text = "Navigation";
		}
		else if (isWeapons)
		{
			whichRoom = 12;
			room.text = "Weapons";
		}
		else if (isHallway)
		{
			whichRoom = 13;
			room.text = "Hallway";
		}

		ambiencePlayer.clip = ambienceClips[whichRoom];
		ambiencePlayer.Play();
	}
}
