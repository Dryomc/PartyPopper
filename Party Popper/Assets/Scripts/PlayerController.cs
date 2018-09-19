using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PartyPopper
{
    public class PlayerController : MonoBehaviour
    {
        private float _Horizontal;
        private float _Vertical;


        void FixedUpdate()
        {
            transform.Translate(new Vector3(0, 0, _Vertical) * 20 * Time.fixedDeltaTime);
            transform.Rotate(new Vector3(0, _Horizontal, 0) * 100 * Time.fixedDeltaTime);
        }

        void Update()
        {
            _Horizontal = Input.GetAxis("Horizontal");
            _Vertical = Input.GetAxis("Vertical");
        }

        public Vector3 GetNormal()
        {
            return Vector3.forward;
        }
    }

}
