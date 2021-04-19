using UnityEngine;
using System.Collections;

public class AccessPointScript : MonoBehaviour
{
	void OnGUI()
	{
		if (UnityEngine.N3DS.AccessPoint.Status != N3dsAccessPointStatus.Connected)
		{
			if (GUI.Button(buttonRectL, "Connect"))
			{
				connectResult = UnityEngine.N3DS.AccessPoint.Connect();
			}

			if (GUI.Button(buttonRectR, "Connect Async"))
			{
				UnityEngine.N3DS.AccessPoint.ConnectAsync();
			}
		}
		else
		{
			if (GUI.Button(buttonRectL, "Close"))
			{
				closeResult = UnityEngine.N3DS.AccessPoint.Close();
			}

			if (GUI.Button(buttonRectR, "Close Async"))
			{
				UnityEngine.N3DS.AccessPoint.CloseAsync();
			}
		}

		Rect rect = new Rect(10, 60, 300, 25);

		GUI.Label(rect, "Status: " + UnityEngine.N3DS.AccessPoint.Status.ToString());
		rect.y += 25;

		GUI.Label(rect, "Connect() result: " + connectResult.ToString());
		rect.y += 25;

		GUI.Label(rect, "ConnectAsync() result: " + UnityEngine.N3DS.AccessPoint.ConnectResult.ToString());
		rect.y += 25;

		GUI.Label(rect, "Close() result: " + closeResult.ToString());
		rect.y += 25;

		GUI.Label(rect, "CloseAsync() result: " + UnityEngine.N3DS.AccessPoint.CloseResult.ToString());
		rect.y += 25;

		if (UnityEngine.N3DS.AccessPoint.Status == N3dsAccessPointStatus.Connected)
		{
			GUI.Label(rect, "LinkLevel: " + UnityEngine.N3DS.AccessPoint.LinkLevel.ToString());
			rect.y += 25;

			GUI.Label(rect, "ConnectedNetworkAreaType: " + UnityEngine.N3DS.AccessPoint.ConnectedNetworkAreaType.ToString());
			rect.y += 25;

			int flags = UnityEngine.N3DS.AccessPoint.ConnectedTypeFlags;
			string flagsStr = "ConnectedTypeFlags: ";
			if ((flags & (int)N3dsApFlag.Freespot) != 0)					flagsStr += "F,";
			if ((flags & (int)N3dsApFlag.Hotspot) != 0)						flagsStr += "H,";
			if ((flags & (int)N3dsApFlag.NintendoWiFiUsbConnector) != 0)	flagsStr += "NW,";
			if ((flags & (int)N3dsApFlag.NintendoZone) != 0)				flagsStr += "NZ,";
			if ((flags & (int)N3dsApFlag.WiFiStation) != 0)					flagsStr += "W,";
			if ((flags & (int)N3dsApFlag.UserSetting1) != 0)				flagsStr += "U1";
			if ((flags & (int)N3dsApFlag.UserSetting2) != 0)				flagsStr += "U2";
			if ((flags & (int)N3dsApFlag.UserSetting3) != 0)				flagsStr += "U3";
			if ((flags & (int)N3dsApFlag.Temporary) != 0)					flagsStr += "T";
			GUI.Label(rect, flagsStr);
			rect.y += 25;
		}
	}

	private N3dsAccessPointError connectResult = N3dsAccessPointError.NotInitialized;
	private N3dsAccessPointError closeResult = N3dsAccessPointError.NotInitialized;

	private static Rect buttonRectL = new Rect(10, 10, 145, 40);
	private static Rect buttonRectR = new Rect(165, 10, 145, 40);
}
