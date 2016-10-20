// *********************************************************
// UDP SPEECH RECOGNITION
// *********************************************************
using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace UnityStandardAssets.Characters.FirstPerson {
public class UDP_RecoServer : MonoBehaviour
{
	public FirstPersonController fpc;
	Thread receiveThread;
	UdpClient client;
	public int port = 26000; // DEFAULT UDP PORT !!!!! THE QUAKE ONE ;)
	string strReceiveUDP = "";
	string LocalIP = String.Empty;
	string hostname;

	public void Start()
	{
		Application.runInBackground = true;
		init();
	}
	// init
	private void init()
	{
		receiveThread = new Thread( new ThreadStart(ReceiveData));
		receiveThread.IsBackground = true;
		receiveThread.Start();
		hostname = Dns.GetHostName();
		IPAddress[] ips = Dns.GetHostAddresses(hostname);
		if (ips.Length > 0)
		{
			LocalIP = ips[0].ToString();
			Debug.Log(" MY IP : "+LocalIP);
		}
	}

	private  void ReceiveData()
	{
		client = new UdpClient(port);
		while (true)
		{
			try
			{
				IPEndPoint anyIP = new IPEndPoint(IPAddress.Broadcast, port);
				byte[] data = client.Receive(ref anyIP);
				strReceiveUDP = Encoding.UTF8.GetString(data);
				// ***********************************************************************
				// Simple Debug. Must be replaced with SendMessage for example.
				// ***********************************************************************
				Debug.Log(strReceiveUDP);
				if (strReceiveUDP.Equals("jump")) {
					fpc.jumpCommand = "jump";
				} else {
					fpc.moveCommand = strReceiveUDP;
				}								
				// ***********************************************************************
			}
			catch (Exception err)
			{
				print(err.ToString());
			}
		}
	}

	public string UDPGetPacket()
	{
		return strReceiveUDP;
	}

	void OnDisable()
	{
		if ( receiveThread != null) receiveThread.Abort();
		client.Close();
	}
}
}
// *********************************************************
