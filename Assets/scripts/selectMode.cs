using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class selectMode : MonoBehaviour {

	[Header("start")]
	public GameObject[] toEnable;
	public GameObject[] toDisable;

	[Header("on the canvas")]
	public Text gameMode;
	public GameObject amogusText;

	[Header("sprites")]
	public GameObject shhh;
	public SpriteRenderer background;

	[Header("colors")]
	public Color impostorBg;
	public Color crewmateBg;
	public Color impostor;
	public Color crewmate;

	[Header("random game mode")]
	public double randomMode;
	public string mode = "crewmate";

	[Header("audio")]
	public AudioSource showAudioSource;


	void Start () {
		StartCoroutine(wait());
	}

	IEnumerator wait()
	{
		genRandomNumber();
		compareRandomNumber();
		saveMode();
		yield return new WaitForSeconds(3);

		setColor();

		foreach(GameObject toEnableAll in toEnable)
		{
			toEnableAll.SetActive(true);
		}
		foreach(GameObject toDisableAll in toDisable)
		{
			toDisableAll.SetActive(false);
		}

		yield return new WaitForSeconds(5);

		SceneManager.LoadScene("skeld");

	}

	void genRandomNumber()
	{
		randomMode = System.Math.Round(UnityEngine.Random.Range(0f, 200f));
	}

	void compareRandomNumber()
	{
		if (randomMode <= 90)
		{
			mode = "imposter";
		}
		else
		{
			mode = "crewmate";
		}
	}

	void setColor()
	{
		if (mode == "imposter")
		{
			background.color = impostorBg;

			gameMode.text = "imposter";
			gameMode.color = impostor;
		}
		else if (mode == "crewmate")
		{
			background.color = crewmateBg;

			gameMode.text = "crewmate";
			gameMode.color = crewmate;
			amogusText.SetActive(true);
		}

		showAudioSource.Play();
	}

	void saveMode()
	{
		PlayerPrefs.SetString("whichMode", mode);
		PlayerPrefs.Save();
	}
	

}
