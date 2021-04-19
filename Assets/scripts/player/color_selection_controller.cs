using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class color_selection_controller : MonoBehaviour {

	//public int thisId;
	public color_controller colorCtrl;

	public void onCLick(int thisId)
	{
		colorCtrl.randomColorOut = thisId;
		colorCtrl.setColor();
		colorCtrl.saveColor();
	}
}
