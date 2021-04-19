using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemode_controller : MonoBehaviour {

	public bool isCrewmate = false;
	public bool isImposter = false;

	public string mode;
	void Start () {
		if (PlayerPrefs.HasKey("whichMode"))
		{
			mode = PlayerPrefs.GetString("whichMode");
		}

		if (mode == "crewmate")
		{
			isCrewmate = true;
		}
		else if (mode == "imposter")
		{
			isImposter = true;
		}

		/*
		if (isCrewmate)
			isImposter = false;

		if (isImposter)
			isCrewmate = false;

		*/
	}

}
