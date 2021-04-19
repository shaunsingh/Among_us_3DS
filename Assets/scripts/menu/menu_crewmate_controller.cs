using UnityEngine;
using System;

public class menu_crewmate_controller : MonoBehaviour {

	public Color[] colorList;
	public SpriteRenderer[] crewmates;
	public double[] randomCrewmate;
	public int[] randomCrewmateOut;

	void Start () 
	{
		selectCrewmate();
	}
	void selectCrewmate()
	{
		randomCrewmate[0] = System.Math.Round(UnityEngine.Random.Range(0f, 5f));
		randomCrewmate[1] = System.Math.Round(UnityEngine.Random.Range(0f, 5f));
		randomCrewmate[2] = System.Math.Round(UnityEngine.Random.Range(0f, 5f));
		randomCrewmate[3] = System.Math.Round(UnityEngine.Random.Range(0f, 5f));
		randomCrewmate[4] = System.Math.Round(UnityEngine.Random.Range(0f, 5f));
		randomCrewmate[5] = System.Math.Round(UnityEngine.Random.Range(0f, 5f));

		randomCrewmateOut[0] = (int)randomCrewmate[0];
		randomCrewmateOut[1] = (int)randomCrewmate[1];
		randomCrewmateOut[2] = (int)randomCrewmate[2];
		randomCrewmateOut[3] = (int)randomCrewmate[3];
		randomCrewmateOut[4] = (int)randomCrewmate[4];
		randomCrewmateOut[5] = (int)randomCrewmate[5];

		checkDoubles();
	}

	void checkDoubles()
	{
		if (randomCrewmateOut[0] == randomCrewmateOut[1] || randomCrewmateOut[0] == randomCrewmateOut[2] || randomCrewmateOut[0] == randomCrewmateOut[3] || randomCrewmateOut[0] == randomCrewmateOut[4] || randomCrewmateOut[0] == randomCrewmateOut[5])
		{
			selectCrewmate();
		}
		else if (randomCrewmateOut[1] == randomCrewmateOut[0] || randomCrewmateOut[1] == randomCrewmateOut[2] || randomCrewmateOut[1] == randomCrewmateOut[3] || randomCrewmateOut[1] == randomCrewmateOut[4] || randomCrewmateOut[1] == randomCrewmateOut[5])
		{
			selectCrewmate();
		}
		else if (randomCrewmateOut[2] == randomCrewmateOut[0] || randomCrewmateOut[2] == randomCrewmateOut[1] || randomCrewmateOut[2] == randomCrewmateOut[3] || randomCrewmateOut[2] == randomCrewmateOut[4] || randomCrewmateOut[2] == randomCrewmateOut[5])
		{
			selectCrewmate();
		}
		else if (randomCrewmateOut[3] == randomCrewmateOut[0] || randomCrewmateOut[3] == randomCrewmateOut[1] || randomCrewmateOut[3] == randomCrewmateOut[2] || randomCrewmateOut[3] == randomCrewmateOut[4] || randomCrewmateOut[3] == randomCrewmateOut[5])
		{
			selectCrewmate();
		}
		else if (randomCrewmateOut[4] == randomCrewmateOut[0] || randomCrewmateOut[4] == randomCrewmateOut[1] || randomCrewmateOut[4] == randomCrewmateOut[2] || randomCrewmateOut[4] == randomCrewmateOut[3] || randomCrewmateOut[4] == randomCrewmateOut[5])
		{
			selectCrewmate();
		}
		else if (randomCrewmateOut[5] == randomCrewmateOut[0] || randomCrewmateOut[5] == randomCrewmateOut[1] || randomCrewmateOut[5] == randomCrewmateOut[2] || randomCrewmateOut[5] == randomCrewmateOut[3] || randomCrewmateOut[5] == randomCrewmateOut[4])
		{
			selectCrewmate();
		}
		else
		{
			setColor();
		}
	}
	void setColor()
	{
		crewmates[randomCrewmateOut[0]].color = colorList[0];
		crewmates[randomCrewmateOut[1]].color = colorList[1];
		crewmates[randomCrewmateOut[2]].color = colorList[2];
		crewmates[randomCrewmateOut[3]].color = colorList[3];
		crewmates[randomCrewmateOut[4]].color = colorList[4];
		crewmates[randomCrewmateOut[5]].color = colorList[5];
	}
}
