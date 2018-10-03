using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;


namespace PartyPopper
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private XboxController _controller;

        [SerializeField]
        private float _speed;

        [SerializeField]
        private float _kickForce;

        [SerializeField]
        private float _bounceForce;

        private Vector3 _movement;
        private Rigidbody _rigibody;
        private bool _kicking;

        private void Start()
        {
            _rigibody = GetComponent<Rigidbody>();
            _kicking = false;
            _movement = Vector3.zero;
        }

        void FixedUpdate()
        {
            if(_movement.x != 0 || _movement.z != 0)
            {
                float angle = Mathf.Atan2(-_movement.x, - _movement.z) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.Euler(0, angle, 0);
                transform.rotation = rotation;
                transform.position += -transform.forward * _speed * Time.fixedDeltaTime;
            }
            

            if (IsGrounded())
                _rigibody.AddForce(Vector3.up * _bounceForce, ForceMode.VelocityChange);
        }

        void Update()
        {
            // float x = Input.GetAxis("Horizontal");   // Debug purposes
            // float z = Input.GetAxis("Vertical");     // Debug purposes

            // _kicking = Input.GetKey(KeyCode.Space);  // Debug purposes

            float x = XCI.GetAxis(XboxAxis.LeftStickX, _controller);
            float z = XCI.GetAxis(XboxAxis.LeftStickY, _controller);

            _kicking = XCI.GetButton(XboxButton.LeftBumper) || XCI.GetButton(XboxButton.RightBumper);

            _movement = new Vector3(x, 0, z);
        }

        private bool IsGrounded()
        {
            return Physics.Raycast(transform.position, -transform.up, 0.1f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Ball")
            {
                GameObject ball = collision.gameObject;
                Rigidbody ballBody = ball.GetComponent<Rigidbody>();

                if (_kicking)
                {
                    ballBody.AddForce(-transform.forward * _kickForce);
                    ballBody.AddForce(transform.up * _kickForce);
                    Debug.Log("Kick!");
                }
            }           
        }
    }

}
