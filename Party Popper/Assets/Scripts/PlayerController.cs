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
        private float _kickForceMultiplier;

        private Rigidbody _rigibody;
        private Ball _touchingBall;
        private bool _isExecutingVibrateRoutine = false;

        private void Start()
        {
            _rigibody                   = GetComponent<Rigidbody>();
            _kickForceMultiplier        = 0;
            _movement                   = Vector3.zero;
            _touchingBall               = null;
            _isExecutingVibrateRoutine  = false;

            // Registering the OnScore function to the Score event of each goal in the scene.
            GameObject[] goalObjects = GameObject.FindGameObjectsWithTag("Goal");
            foreach (GameObject goalObject in goalObjects)
            {
                Goal goal = goalObject.GetComponent<Goal>();
                goal.TeamScoreEvent += OnScore;
            }
        }

        void FixedUpdate()
        {
            // Calculating the facing direction based on the x and y input of a single joystick
            if(_movement.x != 0 || _movement.z != 0)
            {
                float angle = Mathf.Atan2(-_movement.x, -_movement.z) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, angle, 0);
                transform.position += -transform.forward * _speed * Time.fixedDeltaTime;
            }
            

            if (IsGrounded())
                _rigibody.AddForce(Vector3.up * _bounceForce, ForceMode.VelocityChange);

            Kick(_kickForceMultiplier);
        }

        void Update()
        {
            // float x = Input.GetAxis("Horizontal");   // Debug purposes
            // float z = Input.GetAxis("Vertical");     // Debug purposes

            float x = XCI.GetAxis(XboxAxis.LeftStickX, _controller);
            float z = XCI.GetAxis(XboxAxis.LeftStickY, _controller);

            if (XCI.GetButton(XboxButton.LeftBumper, _controller) || XCI.GetButton(XboxButton.RightBumper, _controller))
                _kickForceMultiplier = 1;
            else
                _kickForceMultiplier = Mathf.Max(XCI.GetAxis(XboxAxis.RightTrigger, _controller), XCI.GetAxis(XboxAxis.LeftTrigger, _controller)) * 2;

            _movement = new Vector3(x, 0, z);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ball"))
                _touchingBall = other.gameObject.GetComponent<Ball>();
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Ball"))
                _touchingBall = null;
        }

        private void Kick(float forceMultiplier)
        {
            if (_touchingBall != null && forceMultiplier > 0)
            {
                Rigidbody ballBody = _touchingBall.gameObject.GetComponent<Rigidbody>();

                ballBody.AddForce(-transform.forward * _kickForce);
                ballBody.AddForce(transform.up * (_kickForce * 0.1f));
            }
        }

        private void OnScore(Team team)
        {
            if (gameObject.GetComponent<TeamMember>().GetTeam().Equals(team))
            {
                VibrateController(1f, 1f, 1f);
            }
        }

        private bool IsGrounded()
        {
            return Physics.Raycast(transform.position, -transform.up, 0.1f);
        }

        private void VibrateController(float left, float right, float time)
        {
            StartCoroutine(VibrateControllerRoutine(left, right, time));
        }

        private IEnumerator VibrateControllerRoutine(float left, float right, float time)
        {
            if (_isExecutingVibrateRoutine)
                yield break;

            XCI.SetVibration(_controller, right, left);
            _isExecutingVibrateRoutine = true;

            yield return new WaitForSeconds(time);

            _isExecutingVibrateRoutine = false;

            XCI.SetVibration(_controller, 0, 0);
        }
    }

}
