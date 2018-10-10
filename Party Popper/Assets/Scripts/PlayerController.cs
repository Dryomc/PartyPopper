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
            transform.Translate(new Vector3(_Horizontal, 0, _Vertical) * 20 * Time.fixedDeltaTime, Space.World);
            
            if (IsGrounded())
            {
                _RB.AddForce(Vector3.up * 20000 * Time.fixedDeltaTime);
            }
        }

        void Update()
        {
            _Horizontal = XCI.GetAxis(XboxAxis.LeftStickX, _Controller);
            _Vertical = XCI.GetAxis(XboxAxis.LeftStickY, _Controller);

            Vector3 movement = new Vector3(_Horizontal, 0, _Vertical);

            _kicking = XCI.GetButton(XboxButton.LeftBumper) || XCI.GetButton(XboxButton.RightBumper);

            if(movement != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.2f);
            }
        }
            
        private bool IsGrounded()
        {
            return Physics.Raycast(transform.position, -transform.up, 0.1f);
        }

        private void OnCollisionStay(Collision collision)
        {
            if(collision.gameObject.tag == "Ball")
            {
                GameObject ball = collision.gameObject;
                Rigidbody ballBody = ball.GetComponent<Rigidbody>();

                if(_kicking)
                    ballBody.AddForce(transform.forward * (Time.deltaTime * 10));
            }           
        }
    }

}
