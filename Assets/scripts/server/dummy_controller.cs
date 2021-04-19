using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class dummy_controller : MonoBehaviour {

	public float xPos;
	public float yPos;

	[Header("testing only")]
	public NetworkTransform player;

	
	void Update () 
	{
		xPos = player.transform.position.x;
		yPos = player.transform.position.y;

		this.transform.position = player.transform.position;
	}
}
