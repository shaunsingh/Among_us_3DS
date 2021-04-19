using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class player_ui_controller : MonoBehaviour {

	[Header("only gets activated when imposter")]
	public GameObject killButton;

	[Header("arrays for buttons on the ui")]
	public Sprite[] uiButtons;
	public Image[] uiImages;

	[Header("cooldowntext")]
	public Text cooldown;

	[Header("button colors to make it easier to see what is going on")]
	public Color unaivalable;
	public Color available;

	[Header("some float variables")]
	public float cooldownTime;

	[Header("game mode dependent rules")]
	public bool canAttack = false;

	[Header("all scripts needed")]
	public player_controller playerCtrl;
	public gamemode_controller gamemodeCtrl;


	// Use this for initialization
	void Start () {
		initializeUi();	
	}

	void initializeUi()
	{
		if (gamemodeCtrl.isImposter == true)
		{
			killButton.SetActive(true);
		}

		setImages();

		foreach (Image uiImage in uiImages)
		{
			uiImage.color = unaivalable;
		}
	}

	void setImages()
	{
		if (gamemodeCtrl.isCrewmate == true)
		{
			uiImages[0].sprite = uiButtons[0];
			uiImages[1].sprite = uiButtons[1];
		}
		else if (gamemodeCtrl.isImposter == true)
		{
			uiImages[0].sprite = uiButtons[2];
			uiImages[1].sprite = uiButtons[3];

			StartCoroutine(imposterCooldown());
		}
	}

	
	IEnumerator imposterCooldown()
	{
		if (cooldownTime > 0)
		{
			yield return new WaitForSeconds(1);
			cooldownTime -= 1;
			cooldown.text = cooldownTime.ToString();
			StartCoroutine(imposterCooldown());
		}
		else
		{
			setKillButton();
			yield break;
		}
	}

	void setKillButton()
	{
		canAttack = true;
		uiImages[2].color = available;
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
