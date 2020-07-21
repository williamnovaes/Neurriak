using System;
using System.Collections.Generic;
using UnityEngine;
using System.Net;

namespace NeurriakClient {
	public class ClientHandle : MonoBehaviour {
		public static void Welcome(Packet _packet) {
			string _msg = _packet.ReadString();
			int _myId = _packet.ReadInt();

			Debug.Log($"Mensagem received from the server {_msg}");
			Client.instance.myId = _myId;
			ClientSend.WelcomeReceived();

			Client.instance.udp.Connect(((IPEndPoint) Client.instance.tcp.socket.Client.LocalEndPoint).Port);
		}

		// public static void UDPTest(Packet _packet) {
		// 	string _msg = _packet.ReadString();

		// 	Debug.Log($"Received packet via UDP. Contains message: {_msg}");
		// 	ClientSend.UDPTestReceived();
		// }

		public static void SpawnPlayer(Packet _packet) {
			int _id = _packet.ReadInt();
			string _username = _packet.ReadString();
			Vector3 _position = _packet.ReadVector3();
			Quaternion _rotation = _packet.ReadQuaternion();

			GameManager.instance.SpawnPlayer(_id, _username, _position, _rotation);
		}

		public static void PlayerPosition(Packet _packet) {
			int _id = _packet.ReadInt();
			Vector3 _position = _packet.ReadVector3();

			GameManager.Players[_id].transform.position = _position;
		}

		public static void PlayerRotation(Packet _packet) {
			int _id = _packet.ReadInt();
			Quaternion _rotation = _packet.ReadQuaternion();

			GameManager.Players[_id].transform.rotation = _rotation;
		}
	}
}