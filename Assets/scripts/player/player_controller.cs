using System.Collections;
using UnityEngine;

public class player_controller : MonoBehaviour {

	[Header("player sprite renderer")]
	public SpriteRenderer player;

	[Header("all player sprites")]
	public Sprite[] normal;
	public Sprite[] mirror;
	public Sprite stillNormal;
	public Sprite stillMirror;

	[Header("what frame to display")]
	public int currFrame = 0;

	[Header("the normal speed of the player, the multiplier is easy to change")]
	public float speed;
	public float multiplier;

	[Header("audiosource of the player")]
	public AudioSource playerAudio;

	[Header("audio files")]
	public AudioClip[] steps;

	[Header("what step sound to play")]
	public int currStepSound = 0;

	[Header("direction of player, decides which sprites to use")]
	public string currDir = "right";
	public string dir;
	public string prevDir;

	[Header("important bools")]
	public bool isMoving = false;
	public bool animating = false;
	public bool sounding = false;

	[Header("game mode dependent rules")]
	public bool canAttack = false;

	void Start () {
		currFrame = 0;
		isMoving = false;
		animating = false;

		currDir = "right";
	}

	void Update () 
	{
		if (Input.GetKey(KeyCode.Keypad4) || Input.GetKey(KeyCode.LeftArrow))
		{
			dir = "left";
			currDir = "left";

			prevDir = dir;

			isMoving = true;
		}
		else if (Input.GetKey(KeyCode.Keypad8) || Input.GetKey(KeyCode.UpArrow))
		{
			currDir = "up";

			if (prevDir == "left")
			{
				dir = "left";
			}
			else if (prevDir == "right")
			{
				dir = "right";
			}

			isMoving = true;
		}
		else if (Input.GetKey(KeyCode.Keypad6) || Input.GetKey(KeyCode.RightArrow))
		{
			dir = "right";
			currDir = "right";

			prevDir = dir;

			isMoving = true;
		}
		else if (Input.GetKey(KeyCode.Keypad2) || Input.GetKey(KeyCode.DownArrow))
		{
			currDir = "down";

			if (prevDir == "left")
			{
				dir = "left";
			}
			else if (prevDir == "right")
			{
				dir = "right";
			}

			isMoving = true;
		}

		//8th direction
		else if (Input.GetKey(KeyCode.Keypad1))
		{
			currDir = "down+left";

			if (prevDir == "left")
			{
				dir = "left";
			}
			else if (prevDir == "right")
			{
				dir = "right";
			}

			isMoving = true;
		}
		else if (Input.GetKey(KeyCode.Keypad3))
		{
			currDir = "down+right";

			if (prevDir == "left")
			{
				dir = "left";
			}
			else if (prevDir == "right")
			{
				dir = "right";
			}

			isMoving = true;
		}
		else if (Input.GetKey(KeyCode.Keypad7))
		{
			currDir = "up+left";

			if (prevDir == "left")
			{
				dir = "left";
			}
			else if (prevDir == "right")
			{
				dir = "right";
			}

			isMoving = true;
		}
		else if (Input.GetKey(KeyCode.Keypad9))
		{
			currDir = "up+right";

			if (prevDir == "left")
			{
				dir = "left";
			}
			else if (prevDir == "right")
			{
				dir = "right";
			}

			isMoving = true;
		}
		else
		{
			currDir = "none";
			isMoving = false;
		}


		if (isMoving)
		{
			movePlayer();
			updateSprite();
		}
		else
		{
			if (currDir == "none")
			{
				if (prevDir == "left")
				{
					player.sprite = stillMirror;
				}
				else if (prevDir == "right")
				{
					player.sprite = stillNormal;
				}
			}
		}
	}

	void movePlayer()
	{
		if (currDir == "left")
		{
			player.transform.Translate(Vector3.left * speed * multiplier);
		}
		else if (currDir == "up")
		{
			player.transform.Translate(Vector3.up * speed * multiplier);
		}
		else if (currDir == "up+left")
		{
			player.transform.Translate(Vector3.left * speed * multiplier);
			player.transform.Translate(Vector3.up * speed * multiplier);
		}
		else if (currDir == "up+right")
		{
			player.transform.Translate(Vector3.right * speed * multiplier);
			player.transform.Translate(Vector3.up * speed * multiplier);
		}
		else if (currDir == "right")
		{
			player.transform.Translate(Vector3.right * speed * multiplier);
		}
		else if (currDir == "down") 
		{
			player.transform.Translate(Vector3.down * speed * multiplier);
		}
		else if (currDir == "down+left")
		{
			player.transform.Translate(Vector3.left * speed * multiplier);
			player.transform.Translate(Vector3.down * speed * multiplier);
		}
		else if (currDir == "down+right")
		{
			player.transform.Translate(Vector3.right * speed * multiplier);
			player.transform.Translate(Vector3.down * speed * multiplier);
		}
	}

	void updateSprite()
	{

		if (prevDir == "left")
		{
			player.sprite = mirror[currFrame];
		}
		else if (prevDir == "right")
		{
			player.sprite = normal[currFrame];
		}

		if (animating == false)
		{
			StartCoroutine(animatePlayer());
		}
		if (sounding == false)
		{
			StartCoroutine(updateSound());
		}
	}

	void playAudio()
	{
		playerAudio.clip = steps[currStepSound];
		playerAudio.Play();
	}

	IEnumerator animatePlayer()
	{
		animating = true;

		yield return new WaitForSeconds(0.06f);

		if (currFrame < 5)
		{
			currFrame += 1;
		}
		else if (currFrame == 5)
		{
			currFrame = 0;
		}

		if (isMoving == false)
		{
			animating = false;
			yield break;
		}
		else if (isMoving == true)
		{
			StartCoroutine(animatePlayer());
		}
	}

	IEnumerator updateSound()
	{
		sounding = true;

		yield return new WaitForSeconds(0.3f);

		if (currStepSound < 7)
		{
			currStepSound += 1;
		}
		else if (currStepSound == 7)
		{
			currStepSound = 0;
		}

		if (isMoving == false)
		{
			sounding = false;
			yield break;
		}
		else if (isMoving == true)
		{
			playAudio();
			StartCoroutine(updateSound());
		}
	}
}
