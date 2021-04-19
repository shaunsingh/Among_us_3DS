using UnityEngine;
using System.Collections;

public class KeyboardScript : MonoBehaviour
{
	void Start()
	{
		UnityEngine.N3DS.Keyboard.SetType(N3dsKeyboardType.Qwerty);
	}

	void OnGUI()
	{
		int xpos = 0;
		int ypos = 5;
		width = 180;

		if (ButtonPressed(xpos, ref ypos, "Display Language: ", ref displayLanguage, displayLanguages))
		{
			UnityEngine.N3DS.Keyboard.SetDisplayLanguage((N3dsKeyboardDisplayLanguage)displayLanguage);
		}

		if (ButtonPressed(xpos, ref ypos, "Finish Condition: ", ref finishableCondition, finishableConditions))
		{
			UnityEngine.N3DS.Keyboard.SetFinishableCondition((N3dsKeyboardFinishableCondition)finishableCondition);
		}

		if (ButtonPressed(xpos, ref ypos, "Mask Mode: ", ref maskMode, maskModes))
		{
			UnityEngine.N3DS.Keyboard.SetMaskMode((N3dsKeyboardMaskMode)maskMode);
		}

		if (ButtonPressed(xpos, ref ypos, "Parental Controls: ", ref parentalControl, parentalControls))
		{
			UnityEngine.N3DS.Keyboard.SetParentalControls((N3dsKeyboardParentalControls)parentalControl);
		}

		if (ButtonPressed(xpos, ref ypos, "Type: ", ref keyboardType, keyboardTypes))
		{
			UnityEngine.N3DS.Keyboard.SetType((N3dsKeyboardType)keyboardType);
		}

		if (ButtonPressed(xpos, ref ypos, "Num Buttons: ", ref numBottomButtons, 1, 3))
		{
			UnityEngine.N3DS.Keyboard.SetNumBottomButtons(numBottomButtons);
		}

		xpos = 185;
		ypos = 5;
		width = 135;

		if (ButtonPressed(xpos, ref ypos, "Fixed Width: ", ref fixedWidth))
		{
			UnityEngine.N3DS.Keyboard.SetFixedWidthMode(fixedWidth);
		}

		if (ButtonPressed(xpos, ref ypos, "Home Button: ", ref homeButton))
		{
			UnityEngine.N3DS.Keyboard.SetHomeButtonEnabled(homeButton);
		}

		if (ButtonPressed(xpos, ref ypos, "Line Feed: ", ref lineFeedEnabled))
		{
			UnityEngine.N3DS.Keyboard.SetLineFeedEnabled(lineFeedEnabled);
		}

		if (ButtonPressed(xpos, ref ypos, "Power Button: ", ref powerButton))
		{
			UnityEngine.N3DS.Keyboard.SetPowerButtonEnabled(powerButton);
		}

		if (ButtonPressed(xpos, ref ypos, "Prediction: ", ref predictionEnabled))
		{
			UnityEngine.N3DS.Keyboard.SetPredictionEnabled(predictionEnabled);
		}

		if (ButtonPressed(xpos, ref ypos, "Software Reset: ", ref softwareReset))
		{
			UnityEngine.N3DS.Keyboard.SetSoftwareResetEnabled(softwareReset);
		}

		if (ButtonPressed(xpos, ref ypos, "Top Screen Dims: ", ref topScreenDims))
		{
			UnityEngine.N3DS.Keyboard.SetTopScreenDims(topScreenDims);
		}

		if (GUI.Button(new Rect(160 - 60, 240 - 32, 120, 30), "Show Keyboard"))
		{
			UnityEngine.N3DS.Keyboard.Show();
		}

		N3dsKeyboardResult result = UnityEngine.N3DS.Keyboard.GetResult();
		GUI.Label(new Rect(0, 220, 60, 20), result.ToString());

		inputString = UnityEngine.N3DS.Keyboard.GetText();
		GUI.Label(new Rect(70, 220, 250, 20), inputString);
	}

	private bool ButtonPressed(int xpos, ref int ypos, string label, ref int index, string[] enumNames)
	{
		bool result = false;
		if (GUI.Button(new Rect(xpos, ypos, width, height), label + enumNames[index]))
		{
			if (++index >= enumNames.Length)
			{
				index = 0;
			}
			result = true;
		}
		ypos += height + spacingV;
		return result;
	}

	private bool ButtonPressed(int xpos, ref int ypos, string label, ref bool flag)
	{
		bool result = false;
		string state = flag ? "Yes" : "No";
		if (GUI.Button(new Rect(xpos, ypos, width, height), label + state))
		{
			flag = !flag;
			result = true;
		}
		ypos += height + spacingV;
		return result;
	}

	private bool ButtonPressed(int xpos, ref int ypos, string label, ref int variable, int min, int max)
	{
		bool result = false;
		if (GUI.Button(new Rect(xpos, ypos, width, height), label + variable))
		{
			if (++variable > max)
			{
				variable = min;
			}
			result = true;
		}
		ypos += height + spacingV;
		return result;
	}

	private readonly string[] displayLanguages = { "Default", "Japanese", "English", "French", "German", "Italian", "Spanish", "Chinese", "Korean", "Dutch", "Portuguese", "Russian" };
	private int displayLanguage = 0;

	private readonly string[] finishableConditions = { "None", "Any", "Non Space", "Except Space" };
	private int finishableCondition = 0;

	private readonly string[] maskModes = { "Disable", "Immediate", "WaitOneSecond" };
	private int maskMode = 0;

	private readonly string[] parentalControls = { "Disable", "Enable", "System" };
	private int parentalControl = 0;

	private readonly string[] keyboardTypes = { "Full", "Qwerty", "TenKey", "NoJapanese", "NNID", "AccountPassword" };
	private int keyboardType = 1;

	private int numBottomButtons = 2;

	private bool fixedWidth = false;
	private bool homeButton = false;
	private bool lineFeedEnabled = false;
	private bool powerButton = false;
	private bool predictionEnabled = false;
	private bool softwareReset = false;
	private bool topScreenDims = false;

	private int width;
	private const int height = 25;
	private const int spacingV = 2;

	private string inputString = "Hello";
}
