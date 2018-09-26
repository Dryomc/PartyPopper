using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;


namespace PartyPopper
{
    public class PlayerController : MonoBehaviour
    {
        private float _Horizontal;
        private float _Vertical;

        private float _HorizontalRotation;
        private float _VerticalRotation;

        [SerializeField]
        private int _Index;

        XboxController _Controller;

        private void Start()
        {
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
        }

        void Update()
        {
            _Horizontal = XCI.GetAxis(XboxAxis.LeftStickX, _Controller);
            _Vertical = XCI.GetAxis(XboxAxis.LeftStickY, _Controller);

            _HorizontalRotation = XCI.GetAxis(XboxAxis.RightStickX, _Controller);
        }

        public Vector3 GetNormal()
        {
            return Vector3.forward;
        }
    }

}
