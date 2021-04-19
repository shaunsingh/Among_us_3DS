using UnityEngine;
using System.Collections;
using System.Threading;

public class UdsExample : MonoBehaviour
{
	public void Start()
	{
		localId = UnityEngine.N3DS.UDS.CreateLocalId(UnityEngine.N3DS.Application.uniqueId, false);
		state = TopMenu;
	}

	public void OnGUI()
	{
		state();
		PollConnectionStatus();

		GUI.Label(new Rect(5, 190, 100, 30), connectionStatus.nowState.ToString());
		GUI.Label(new Rect(105, 190, 205, 30), connectedNodesMessage);
		GUI.Label(new Rect(5, 215, 310, 30), statusMessage);
	}

	private void TopMenu()
	{
		if (GUI.Button(new Rect(5, 5, 310, 30), "Initialize UDS"))
		{
			N3dsUdsError result = UnityEngine.N3DS.UDS.Init(4096 * 20);
			statusMessage = "UDS.Init() = " + result.ToString();

			if (result == N3dsUdsError.Success)
			{
				state = MainMenu;
			}
		}
	}

	private void MainMenu()
	{
		Rect rect = new Rect(5, 5, 310, 30);
		if (GUI.Button(rect, "Create Network"))
		{
			byte[] beaconData = new byte[200];
			byte value = 1;
			for (int index = 0; index < beaconData.Length; index++)
			{
				beaconData[index] = value;
				value = (byte)(value + index);
			}

			N3dsUdsError result = UnityEngine.N3DS.UDS.CreateNetwork(subId, maxConnections, localId, passPhrase, beaconData);
			statusMessage = "CreateNetwork() = " + result.ToString();

			if (result == N3dsUdsError.Success)
			{
				StartSendRecvThreads();
				state = RunningMaster;
			}
			else
			{
				state = TopMenu;
			}
		}

		rect.y += 35;
		if (GUI.Button(rect, "Start Client"))
		{
			isSpectator = false;
			state = ScanForNetwork;
		}

		rect.y += 35;
		if (GUI.Button(rect, "Start Spectator"))
		{
			isSpectator = true;
			state = ScanForNetwork;
		}
	}

	private void RunningMaster()
	{
		Rect rect = new Rect(5, 5, 155, 30);
		if (GUI.Button(rect, "Destroy Network"))
		{
			N3dsUdsError result = UnityEngine.N3DS.UDS.DestroyNetwork();
			statusMessage = "DestroyNetwork() = " + result.ToString();
			StopSendRecvThreads();
			state = MainMenu;
		}

		rect.y += 35;
		if (GUI.Button(rect, "Allow Connections"))
		{
			N3dsUdsError result = UnityEngine.N3DS.UDS.AllowToConnect();
			statusMessage = "AllowToConnect() = " + result.ToString();
		}

		rect.y += 35;
		if (GUI.Button(rect, "Disallow Connections"))
		{
			N3dsUdsError result = UnityEngine.N3DS.UDS.DisallowToConnect(false);
			statusMessage = "DisallowToConnect(false) = " + result.ToString();
		}

		rect.y += 35;
		if (GUI.Button(rect, "Disallow Reconnections"))
		{
			N3dsUdsError result = UnityEngine.N3DS.UDS.DisallowToConnect(true);
			statusMessage = "DisallowToConnect(true) = " + result.ToString();
		}

		rect = new Rect(165, 5, 150, 30);
		if (GUI.Button(rect, "Kick Clients"))
		{
			N3dsUdsError result = UnityEngine.N3DS.UDS.EjectClient(UnityEngine.N3DS.UDS.BROADCAST_NODE_ID);
			statusMessage = "EjectClient() = " + result.ToString();
		}

		rect.y += 35;
		if (GUI.Button(rect, "Kick Spectators"))
		{
			N3dsUdsError result = UnityEngine.N3DS.UDS.EjectSpectator();
			statusMessage = "EjectSpectator() = " + result.ToString();
		}

		rect.y += 35;
		if (GUI.Button(rect, "Allow Spectators"))
		{
			N3dsUdsError result = UnityEngine.N3DS.UDS.AllowToSpectate();
			statusMessage = "AllowToSpectate() = " + result.ToString();
		}
	}

	private void ScanForNetwork()
	{
		Rect rect = new Rect(5, 5, 310, 30);
		if (GUI.Button(rect, "Scan for Networks"))
		{
			N3dsUdsError result = UnityEngine.N3DS.UDS.Scan(subId, localId);
			statusMessage = "Scan() = " + result.ToString();

			if (result == N3dsUdsError.Success)
			{
				state = ConnectNetwork;
			}
			else
			{
				state = MainMenu;
			}
		}

		rect.y += 35;
		if (GUI.Button(rect, "Back"))
		{
			state = MainMenu;
		}
	}

	private void ConnectNetwork()
	{
		uint numDiscoveredNetworks = UnityEngine.N3DS.UDS.GetNumDiscoveredNetworks();
		statusMessage = "GetDiscoveredNetworks() = " + numDiscoveredNetworks;

		if (numDiscoveredNetworks == 0)
		{
			state = ScanForNetwork;
			return;
		}

		Rect rect = new Rect(5, 5, 70, 30);
		for (uint index = 0; index < numDiscoveredNetworks; index++)
		{
			rect.x = (index % 4) * 80 + 5;
			rect.y = (index / 4) * 35 + 35;

			UnityEngine.N3DS.UdsNetworkDescription description;
			UnityEngine.N3DS.UDS.GetDiscoveredNetwork(index, out description);

			if (GUI.Button(rect, description.gameId.ToString("x")))
			{
				System.Text.StringBuilder sb = new System.Text.StringBuilder();
				sb.AppendLine("Connecting to network");
				sb.AppendLine("gameId: 0x" + description.gameId.ToString("x"));
				sb.AppendLine("temporaryId: 0x" + description.temporaryId.ToString("x"));

				sb.AppendLine("bssId length: " + description.bssId.Length);
				sb.Append("bssId: [");
				for (int byteIndex = 0; byteIndex < description.bssId.Length; byteIndex++)
				{
					sb.Append(description.bssId[byteIndex]);
					sb.Append(",");
				}
				sb.AppendLine("]");

				sb.AppendLine("appData length: " + description.appData.Length);
				sb.Append("appData: [");
				for (int byteIndex = 0; byteIndex < description.appData.Length; byteIndex++)
				{
					sb.Append(description.appData[byteIndex]);
					sb.Append(",");
				}
				sb.AppendLine("]");

				sb.AppendLine("channel: " + description.channel);
				sb.AppendLine("subId: " + description.subId);
				sb.AppendLine("nowEntry: " + description.nowEntry);
				sb.AppendLine("maxEntry: " + description.maxEntry);
				Debug.Log(sb.ToString());

				N3dsUdsError result = UnityEngine.N3DS.UDS.ConnectNetwork(index, isSpectator, passPhrase);
				statusMessage = "ConnectNetwork() = " + result.ToString();

				if (result == N3dsUdsError.Success)
				{
					StartSendRecvThreads();
					state = RunningClientOrSpectator;
					return;
				}
				else
				{
					state = ScanForNetwork;
					return;
				}
			}
		}
	}

	private void RunningClientOrSpectator()
	{
		Rect rect = new Rect(5, 5, 310, 30);
		if (GUI.Button(rect, "Disconnect"))
		{
			N3dsUdsError result = UnityEngine.N3DS.UDS.DisconnectNetwork();
			statusMessage = "DisconnectNetwork() = " + result.ToString();
			StopSendRecvThreads();
			state = ScanForNetwork;
		}

		if (connectionStatus.nowState != N3dsUdsState.Client)
		{
			statusMessage = "disconnectReason = " + connectionStatus.disconnectReason;
			StopSendRecvThreads();
			state = ScanForNetwork;
		}
	}

	private void PollConnectionStatus()
	{
		UnityEngine.N3DS.UDS.GetConnectionStatus(ref connectionStatus);

		if (connectionStatus.slotBitmap != oldSlotBitmap)
		{
			oldSlotBitmap = connectionStatus.slotBitmap;

			if (connectedNodes == null)
			{
				connectedNodes = new ushort[16];
			}

			UnityEngine.N3DS.UDS.GetConnectedNodes(ref connectedNodes);

			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("Nodes:");
			for (int index = 0; index < connectedNodes.Length; index++)
			{
				ushort connectedNode = connectedNodes[index];
				if (connectedNode != 0)
				{
					string userName;
					N3dsUdsError err = UnityEngine.N3DS.UDS.GetNodeUserName(connectedNode, out userName);
					if (err == N3dsUdsError.Success)
					{
						sb.Append(userName.ToString());
						sb.Append(",");
					}
				}
			}
			connectedNodesMessage = sb.ToString();
		}
	}

	private void StartSendRecvThreads()
	{
		sendThread = new Thread(new ThreadStart(SendThreadEntryPoint));
		sendThread.Start();

		recvThread = new Thread(new ThreadStart(RecvThreadEntryPoint));
		recvThread.Start();
	}

	private void StopSendRecvThreads()
	{
		sendThread.Join();
		sendThread = null;

		recvThread.Join();
		recvThread = null;
	}

	private void SendThreadEntryPoint()
	{
		uint endpointId;
		N3dsUdsError result = UnityEngine.N3DS.UDS.CreateEndpoint(out endpointId);
		if (result != N3dsUdsError.Success)
		{
			statusMessage = "CreateEndpoint() failed with " + result.ToString();
			return;
		}

		for (;;)
		{
			result = UnityEngine.N3DS.UDS.SendTo(endpointId, sendBuffer, sendBuffer.Length, UnityEngine.N3DS.UDS.BROADCAST_NODE_ID, 1, UnityEngine.N3DS.UDS.NO_WAIT);
			if ((result != N3dsUdsError.Success) && (result != N3dsUdsError.BufferIsFull))
			{
				statusMessage = "SendTo() failed with " + result.ToString();
			}

			if ((result == N3dsUdsError.InvalidState) || (result == N3dsUdsError.WirelessOff))
			{
				break;
			}

			System.Threading.Thread.Sleep(250);

			sendBuffer[0]++;
		}

		UnityEngine.N3DS.UDS.DestroyEndpoint(endpointId);
	}

	private void RecvThreadEntryPoint()
	{
		uint endpointId;
		N3dsUdsError result = UnityEngine.N3DS.UDS.CreateEndpoint(out endpointId);
		if (result != N3dsUdsError.Success)
		{
			statusMessage = "CreateEndpoint() failed with " + result.ToString();
			return;
		}

		result = UnityEngine.N3DS.UDS.Attach(endpointId, UnityEngine.N3DS.UDS.BROADCAST_NODE_ID, 1, UnityEngine.N3DS.UDS.ATTACH_BUFFER_SIZE_DEFAULT);
		if (result != N3dsUdsError.Success)
		{
			statusMessage = "Attach() failed with " + result.ToString();
			return;
		}

		for (;;)
		{
			ushort sourceNodeId;
			uint receivedNumBytes;

			result = UnityEngine.N3DS.UDS.ReceiveFrom(endpointId, recvBuffer, out receivedNumBytes, out sourceNodeId, UnityEngine.N3DS.UDS.NO_WAIT);
			if (result == N3dsUdsError.Success)
			{
				if (receivedNumBytes > 0)
				{
					statusMessage = "Received " + receivedNumBytes + " bytes from " + sourceNodeId + " : counter = " + recvBuffer[0];
				}
			}
			else
			{
				statusMessage = "ReceiveFrom() failed with " + result.ToString();

				if (result == N3dsUdsError.InvalidState)
				{
					break;
				}
			}

			System.Threading.Thread.Sleep(250);
		}

		UnityEngine.N3DS.UDS.DestroyEndpoint(endpointId);
	}

	private delegate void State();
	private State state;

	private uint localId;
	private bool isSpectator = false;
	private Thread sendThread;
	private Thread recvThread;
	private byte[] sendBuffer = new byte[UnityEngine.N3DS.UDS.PACKET_PAYLOAD_MAX_SIZE];
	private byte[] recvBuffer = new byte[UnityEngine.N3DS.UDS.ATTACH_BUFFER_SIZE_DEFAULT];
	private string statusMessage = "";
	private string connectedNodesMessage = "";
	private UnityEngine.N3DS.UdsConnectionStatus connectionStatus;
	private ushort[] connectedNodes;
	private ushort oldSlotBitmap;

	private static readonly byte subId = 0x01;						// ID used when dividing communications (for match-ups or exchange) in the application.
	private static readonly byte maxConnections = 5;
	private static readonly string passPhrase = "shibboleth";		// Must be between 8 and 255 characters in length.
}
