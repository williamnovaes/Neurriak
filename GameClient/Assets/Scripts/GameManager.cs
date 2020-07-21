using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NeurriakClient {
    public class GameManager : MonoBehaviour {
        public static GameManager instance;
        private static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();
        public static Dictionary<int, PlayerManager> Players {
            get {
                return players;
            }
        }

        public GameObject localPlayerPrefab;
        public GameObject playerPrefab;
        private void Awake() {
            if (instance == null) {
                instance = this;
            } else if (instance != this) {
                Debug.Log("Instance already exists, destroying object");
                Destroy(this);
            }
        }

        public void SpawnPlayer(int _id, string _username, Vector3 _position, Quaternion _rotation) {
            Debug.Log($"Spawning player {_username}");
            GameObject _player;
            if (_id == Client.instance.myId) {
                _player = Instantiate(localPlayerPrefab, _position, _rotation);
            } else {
                _player = Instantiate(playerPrefab, _position, _rotation);
            }

            PlayerManager _playerManager = _player.GetComponent<PlayerManager>();
            _playerManager.id = _id;
            _playerManager.username = _username;
            players.Add(_id, _playerManager);
        }
    }
}