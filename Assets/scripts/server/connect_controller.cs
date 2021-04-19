using UnityEngine;
using System.Threading;

public class connect_controller : MonoBehaviour {

	[Header("internet/wifi connected")]
	public string routerConnectStatus = "disconnected";
	public bool routerIsConnected = false;

	[Header("wireless connected")]
	public string wirelessConnectStatus = "disconnected";
	public bool wirelessConnected = false;

	[Header("scripts needed")]
	public button_controller buttonCtrl;

	[Header("only use when testing, otherwise online WILL NOT work!!!")]
	public bool testingRouter = false;
	public bool testingWireless = false;



	void Start () {

		if (testingRouter == false)
		{
			if (UnityEngine.N3DS.AccessPoint.Status != N3dsAccessPointStatus.Connected)
			{
				UnityEngine.N3DS.AccessPoint.Connect();

				if (UnityEngine.N3DS.AccessPoint.Status == N3dsAccessPointStatus.Connected)
				{
					routerConnectStatus = "connected";
				}
				else
				{
					routerConnectStatus = "disconnected";
				}
			}

			if (routerConnectStatus == "disconnected")
			{
				routerIsConnected = false;
			}
			else
			{
				routerIsConnected = true;
			}
		}
		if (testingRouter == true)
		{
			routerConnectStatus = "connected";
		}

		if (testingWireless == false)
		{
			uint endpointId;
			N3dsUdsError result = UnityEngine.N3DS.UDS.CreateEndpoint(out endpointId);

			if ((result == N3dsUdsError.InvalidState) || (result == N3dsUdsError.WirelessOff))
			{
				wirelessConnectStatus = "disconnected";
			}
			else
			{
				wirelessConnectStatus = "connected";
			}
		}
		if (testingWireless == true)
		{
			wirelessConnectStatus = "connected";
		}

		setButtons();

	}

	void setButtons()
	{
		if (routerConnectStatus == "connected")
		{
			buttonCtrl.accessPointConnected();
		}
		
		if (wirelessConnectStatus == "connected")
		{
			buttonCtrl.wirelessConnected();
		}
	}
}
