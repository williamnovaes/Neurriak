using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NeurriakWorldServer {
    public class Player : MonoBehaviour {
        public int id;
        public string username;

        private float moveSpeed = 5f / Constants.TICKS_PER_SEC;

        private bool[] inputs;
        private Vector3 m_InputDirection;

        public void Initialize(int _id, string _username) {
            id = _id;
            username = _username;

            inputs = new bool[4];
        }

        void Update() {
           
        }

        private void FixedUpdate() {
            m_InputDirection = Vector2.zero;
            if (inputs[0]) {
                m_InputDirection.y = 1;
            } else if (inputs[1]) {
                m_InputDirection.y = 1;
            } else if (inputs[2]) {
                m_InputDirection.x = 1;
            } else if (inputs[3]) {
                m_InputDirection.x = 1;
            }
            Move();
        }

        public void Move() {
            // Vector3 _forward = Vector3.Transform(new Vector3(0, 1, 0), rotation);
            // Vector3 _right = Vector3.Normalize(Vector3.Cross(_forward, new Vector3(0, 1, 0)));
            // Vector3 _right = Vector3.Normalize(new Vector3(1, 0, 0));

            Vector3 _moveDirection = transform.right * m_InputDirection.x + transform.forward * m_InputDirection.y;
            transform.position += _moveDirection * moveSpeed;

            ServerSend.PlayerPosition(this);
            ServerSend.PlayerRotation(this);
        }

        public void SetInput(bool[] _inputs, Quaternion _rotation) {
            inputs = _inputs;
            transform.rotation = _rotation;
        }
    }
}