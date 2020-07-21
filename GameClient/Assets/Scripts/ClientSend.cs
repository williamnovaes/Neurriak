using System;
using UnityEngine;

namespace NeurriakClient {
	public class ClientSend : MonoBehaviour {
		private static void SendTCPData (Packet _packet) {
			_packet.WriteLength();
			Client.instance.tcp.SendData(_packet);
		}

		private static void SendUDPData(Packet _packet) {
			_packet.WriteLength();
			Client.instance.udp.SendData(_packet);
		}

		#region Packets
		public static void WelcomeReceived() {
			using (Packet _packet = new Packet((int) ClientPackets.welcomeReceived)) {
				//a leitura no servidor deve ser feita na mesma sequencia dessa escrita
				_packet.Write(Client.instance.myId);
				_packet.Write(UIManager.instance.usernameField.text);
				SendTCPData(_packet);
			}
		}

		public static void PlayerMovement(bool[] _inputs) {
			using (Packet _packet = new Packet((int)ClientPackets.playerMovement)) {
				_packet.Write(_inputs.Length);
				foreach (var _input in _inputs) {
					_packet.Write(_input);
				}
				_packet.Write(GameManager.Players[Client.instance.myId].transform.rotation);
				SendUDPData(_packet);
			}
		}
		#endregion
	}
}