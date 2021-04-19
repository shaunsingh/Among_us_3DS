using UnityEngine;
using System.Collections;

public class GamepadScript : MonoBehaviour
{
	void Start()
	{
		UnityEngine.N3DS.Keyboard.SetType(N3dsKeyboardType.Qwerty);
	}

	void OnGUI()
	{
		int xpos = spacing;
		int ypos = spacing;

		width = 100;
		Label(ref xpos, ref ypos, N3dsButton.A);
		Label(ref xpos, ref ypos, N3dsButton.B);
		Label(ref xpos, ref ypos, N3dsButton.X);
		Label(ref xpos, ref ypos, N3dsButton.Y);
		Label(ref xpos, ref ypos, N3dsButton.L);
		Label(ref xpos, ref ypos, N3dsButton.R);
		Label(ref xpos, ref ypos, N3dsButton.ZL);

		xpos = 80;
		ypos = spacing;
		Label(ref xpos, ref ypos, N3dsButton.ZR);
		Label(ref xpos, ref ypos, N3dsButton.Up);
		Label(ref xpos, ref ypos, N3dsButton.Down);
		Label(ref xpos, ref ypos, N3dsButton.Left);
		Label(ref xpos, ref ypos, N3dsButton.Right);
		Label(ref xpos, ref ypos, N3dsButton.Start);

		xpos = 160;
		width = 140;
		ypos = spacing;
		Label(ref xpos, ref ypos, N3dsButton.Emulation_Up);
		Label(ref xpos, ref ypos, N3dsButton.Emulation_Down);
		Label(ref xpos, ref ypos, N3dsButton.Emulation_Left);
		Label(ref xpos, ref ypos, N3dsButton.Emulation_Right);
		Label(ref xpos, ref ypos, N3dsButton.Emulation_R_Right);
		Label(ref xpos, ref ypos, N3dsButton.Emulation_R_Left);
		Label(ref xpos, ref ypos, N3dsButton.Emulation_R_Up);
		Label(ref xpos, ref ypos, N3dsButton.Emulation_R_Down);
	}

	private void Label(ref int xpos, ref int ypos, N3dsButton button)
	{
		string text = button.ToString();

		if (UnityEngine.N3DS.GamePad.GetButtonHold(button))
		{
			text += " *";
		}

		GUI.Label(new Rect(xpos, ypos, width, height), text);

		ypos += height + spacing;
	}

	private int width;
	private const int height = 20;
	private const int spacing = 5;
}
