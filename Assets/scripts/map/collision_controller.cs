using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class collision_controller : MonoBehaviour {

	public bool isCafeteria = false;
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

	[Header("important scripts")]
	public ambience_controller ambContrl;

	void Start()
	{
		ambContrl = GameObject.FindObjectOfType<ambience_controller>();
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "player")
		{
			ambContrl = GameObject.FindObjectOfType<ambience_controller>();

			if (isCafeteria)
			{
				ambContrl.isCafeteria = true;
				ambContrl.isMedbay = false;
				ambContrl.isEngine = false;
				ambContrl.isReactor = false;
				ambContrl.isSecurity = false;
				ambContrl.isElectrical = false;
				ambContrl.isStorage = false;
				ambContrl.isAdmin = false;
				ambContrl.isCommunication = false;
				ambContrl.isShields = false;
				ambContrl.isO2 = false;
				ambContrl.isNavigation = false;
				ambContrl.isWeapons = false;
				ambContrl.isHallway = false;

				ambContrl.setSound();
			}
			else if (isMedbay)
			{
				ambContrl.isCafeteria = false;
				ambContrl.isMedbay = true;
				ambContrl.isEngine = false;
				ambContrl.isReactor = false;
				ambContrl.isSecurity = false;
				ambContrl.isElectrical = false;
				ambContrl.isStorage = false;
				ambContrl.isAdmin = false;
				ambContrl.isCommunication = false;
				ambContrl.isShields = false;
				ambContrl.isO2 = false;
				ambContrl.isNavigation = false;
				ambContrl.isWeapons = false;
				ambContrl.isHallway = false;

				ambContrl.setSound();
			}
			else if (isEngine)
			{
				ambContrl.isCafeteria = false;
				ambContrl.isMedbay = false;
				ambContrl.isEngine = true;
				ambContrl.isReactor = false;
				ambContrl.isSecurity = false;
				ambContrl.isElectrical = false;
				ambContrl.isStorage = false;
				ambContrl.isAdmin = false;
				ambContrl.isCommunication = false;
				ambContrl.isShields = false;
				ambContrl.isO2 = false;
				ambContrl.isNavigation = false;
				ambContrl.isWeapons = false;
				ambContrl.isHallway = false;

				ambContrl.setSound();
			}
			else if (isReactor)
			{
				ambContrl.isCafeteria = false;
				ambContrl.isMedbay = false;
				ambContrl.isEngine = false;
				ambContrl.isReactor = true;
				ambContrl.isSecurity = false;
				ambContrl.isElectrical = false;
				ambContrl.isStorage = false;
				ambContrl.isAdmin = false;
				ambContrl.isCommunication = false;
				ambContrl.isShields = false;
				ambContrl.isO2 = false;
				ambContrl.isNavigation = false;
				ambContrl.isWeapons = false;
				ambContrl.isHallway = false;

				ambContrl.setSound();
			}
			else if (isSecurity)
			{
				ambContrl.isCafeteria = false;
				ambContrl.isMedbay = false;
				ambContrl.isEngine = false;
				ambContrl.isReactor = false;
				ambContrl.isSecurity = true;
				ambContrl.isElectrical = false;
				ambContrl.isStorage = false;
				ambContrl.isAdmin = false;
				ambContrl.isCommunication = false;
				ambContrl.isShields = false;
				ambContrl.isO2 = false;
				ambContrl.isNavigation = false;
				ambContrl.isWeapons = false;
				ambContrl.isHallway = false;

				ambContrl.setSound();
			}
			else if (isElectrical)
			{
				ambContrl.isCafeteria = false;
				ambContrl.isMedbay = false;
				ambContrl.isEngine = false;
				ambContrl.isReactor = false;
				ambContrl.isSecurity = false;
				ambContrl.isElectrical = true;
				ambContrl.isStorage = false;
				ambContrl.isAdmin = false;
				ambContrl.isCommunication = false;
				ambContrl.isShields = false;
				ambContrl.isO2 = false;
				ambContrl.isNavigation = false;
				ambContrl.isWeapons = false;
				ambContrl.isHallway = false;

				ambContrl.setSound();
			}
			else if (isStorage)
			{
				ambContrl.isCafeteria = false;
				ambContrl.isMedbay = false;
				ambContrl.isEngine = false;
				ambContrl.isReactor = false;
				ambContrl.isSecurity = false;
				ambContrl.isElectrical = false;
				ambContrl.isStorage = true;
				ambContrl.isAdmin = false;
				ambContrl.isCommunication = false;
				ambContrl.isShields = false;
				ambContrl.isO2 = false;
				ambContrl.isNavigation = false;
				ambContrl.isWeapons = false;
				ambContrl.isHallway = false;

				ambContrl.setSound();
			}
			else if (isAdmin)
			{
				ambContrl.isCafeteria = false;
				ambContrl.isMedbay = false;
				ambContrl.isEngine = false;
				ambContrl.isReactor = false;
				ambContrl.isSecurity = false;
				ambContrl.isElectrical = false;
				ambContrl.isStorage = false;
				ambContrl.isAdmin = true;
				ambContrl.isCommunication = false;
				ambContrl.isShields = false;
				ambContrl.isO2 = false;
				ambContrl.isNavigation = false;
				ambContrl.isWeapons = false;
				ambContrl.isHallway = false;

				ambContrl.setSound();
			}
			else if (isCommunication)
			{
				ambContrl.isCafeteria = false;
				ambContrl.isMedbay = false;
				ambContrl.isEngine = false;
				ambContrl.isReactor = false;
				ambContrl.isSecurity = false;
				ambContrl.isElectrical = false;
				ambContrl.isStorage = false;
				ambContrl.isAdmin = false;
				ambContrl.isCommunication = true;
				ambContrl.isShields = false;
				ambContrl.isO2 = false;
				ambContrl.isNavigation = false;
				ambContrl.isWeapons = false;
				ambContrl.isHallway = false;

				ambContrl.setSound();
			}
			else if (isShields)
			{
				ambContrl.isCafeteria = false;
				ambContrl.isMedbay = false;
				ambContrl.isEngine = false;
				ambContrl.isReactor = false;
				ambContrl.isSecurity = false;
				ambContrl.isElectrical = false;
				ambContrl.isStorage = false;
				ambContrl.isAdmin = false;
				ambContrl.isCommunication = false;
				ambContrl.isShields = true;
				ambContrl.isO2 = false;
				ambContrl.isNavigation = false;
				ambContrl.isWeapons = false;
				ambContrl.isHallway = false;

				ambContrl.setSound();
			}
			else if (isO2)
			{
				ambContrl.isCafeteria = false;
				ambContrl.isMedbay = false;
				ambContrl.isEngine = false;
				ambContrl.isReactor = false;
				ambContrl.isSecurity = false;
				ambContrl.isElectrical = false;
				ambContrl.isStorage = false;
				ambContrl.isAdmin = false;
				ambContrl.isCommunication = false;
				ambContrl.isShields = false;
				ambContrl.isO2 = true;
				ambContrl.isNavigation = false;
				ambContrl.isWeapons = false;
				ambContrl.isHallway = false;

				ambContrl.setSound();
			}
			else if (isNavigation)
			{
				ambContrl.isCafeteria = false;
				ambContrl.isMedbay = false;
				ambContrl.isEngine = false;
				ambContrl.isReactor = false;
				ambContrl.isSecurity = false;
				ambContrl.isElectrical = false;
				ambContrl.isStorage = false;
				ambContrl.isAdmin = false;
				ambContrl.isCommunication = false;
				ambContrl.isShields = false;
				ambContrl.isO2 = false;
				ambContrl.isNavigation = true;
				ambContrl.isWeapons = false;
				ambContrl.isHallway = false;

				ambContrl.setSound();
			}
			else if (isWeapons)
			{
				ambContrl.isCafeteria = false;
				ambContrl.isMedbay = false;
				ambContrl.isEngine = false;
				ambContrl.isReactor = false;
				ambContrl.isSecurity = false;
				ambContrl.isElectrical = false;
				ambContrl.isStorage = false;
				ambContrl.isAdmin = false;
				ambContrl.isCommunication = false;
				ambContrl.isShields = false;
				ambContrl.isO2 = false;
				ambContrl.isNavigation = false;
				ambContrl.isWeapons = true;
				ambContrl.isHallway = false;

				ambContrl.setSound();
			}
			else if (isHallway)
			{
				ambContrl.isCafeteria = false;
				ambContrl.isMedbay = false;
				ambContrl.isEngine = false;
				ambContrl.isReactor = false;
				ambContrl.isSecurity = false;
				ambContrl.isElectrical = false;
				ambContrl.isStorage = false;
				ambContrl.isAdmin = false;
				ambContrl.isCommunication = false;
				ambContrl.isShields = false;
				ambContrl.isO2 = false;
				ambContrl.isNavigation = false;
				ambContrl.isWeapons = false;
				ambContrl.isHallway = true;

				ambContrl.setSound();
			}
		}
	}
}
