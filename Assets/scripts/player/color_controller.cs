using UnityEngine;

public class color_controller : MonoBehaviour {

	public Color[] colors;
	public double randomColor;
	public int randomColorOut;
	public SpriteRenderer player;

	public bool isDummy;

	// Use this for initialization
	void Start () {

		if (PlayerPrefs.HasKey("whichColor"))
		{
			randomColorOut = PlayerPrefs.GetInt("whichColor");
		}
		if (randomColorOut == 0 || isDummy == true)
		{
			genRandomNumber();
			setColor();
		}
		else
		{
			setColor();
		}
		
	}
	
	void genRandomNumber()
	{
		randomColor = System.Math.Round(UnityEngine.Random.Range(1f, 13f));
		randomColorOut = (int)randomColor;

		if (isDummy == false)
		{
			saveColor();
		}
	}

	

	public void setColor()
	{
		player.color = colors[randomColorOut];
	}

	public void saveColor()
	{
		PlayerPrefs.SetInt("whichColor", randomColorOut);
		PlayerPrefs.Save();
	}
}
