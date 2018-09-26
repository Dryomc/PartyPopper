using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PartyPopper
{
    public class PlayerController : MonoBehaviour
    {
        private float _Horizontal;
        private float _Vertical;

        private float _HorizontalRotation;
        private float _VerticalRotation;


        void FixedUpdate()
        {
            transform.Translate(new Vector3(_Horizontal, 0, _Vertical) * 20 * Time.fixedDeltaTime);
            //transform.Translate(new Vector3(, 0, 0) * 100 * Time.fixedDeltaTime);

            transform.Rotate(new Vector3(0, _HorizontalRotation, 0) * 200 * Time.fixedDeltaTime);
        }

        void Update()
        {
            _Horizontal = Input.GetAxis("Horizontal");
            _Vertical = Input.GetAxis("Vertical");

            _HorizontalRotation = Input.GetAxis("HorizontalRotation");
        }

        public Vector3 GetNormal()
        {
            return Vector3.forward;
        }
    }

}
