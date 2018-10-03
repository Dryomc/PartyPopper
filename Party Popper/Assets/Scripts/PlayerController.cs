using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;


namespace PartyPopper
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        private float _Horizontal;
        private float _Vertical;

        private float _HorizontalRotation;
        private float _VerticalRotation;

        [SerializeField]
        private int _Index;

        XboxController _Controller;

        Rigidbody _RB;

        private bool _kicking;

        private void Start()
        {
            _RB = GetComponent<Rigidbody>();
            _kicking = false;

            switch (_Index)
            {
                case 1:
                    _Controller = XboxController.First;
                    break;
                case 2:
                    _Controller = XboxController.Second;
                    break;
                case 3:
                    _Controller = XboxController.Third;
                    break;
                case 4:
                    _Controller = XboxController.Fourth;
                    break;
            } 
        }

        void FixedUpdate()
        {
            transform.Translate(new Vector3(_Horizontal, 0, _Vertical) * 20 * Time.fixedDeltaTime);
            //transform.Translate(new Vector3(, 0, 0) * 100 * Time.fixedDeltaTime);

            transform.Rotate(new Vector3(0, _HorizontalRotation, 0) * 200 * Time.fixedDeltaTime);

            if (IsGrounded())
            {
                _RB.AddForce(Vector3.up * 20000 * Time.fixedDeltaTime);
            }
        }

        void Update()
        {
            _Horizontal = XCI.GetAxis(XboxAxis.LeftStickX, _Controller);
            _Vertical = XCI.GetAxis(XboxAxis.LeftStickY, _Controller);

            _kicking = XCI.GetButton(XboxButton.LeftBumper) || XCI.GetButton(XboxButton.RightBumper);

            _HorizontalRotation = XCI.GetAxis(XboxAxis.RightStickX, _Controller);
        }

        public Vector3 GetNormal()
        {
            return Vector3.forward;
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

                if(_kicking)
                    ballBody.AddForce(transform.forward * (Time.deltaTime * 50));
            }           
        }
    }

}
