using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PartyPopper
{
    public class PlayerController : MonoBehaviour
    {
        private float _Horizontal;
        private float _Vertical;

        void Start()
        {

        }

        void FixedUpdate()
        {
            transform.Translate(new Vector3(_Horizontal, 0, _Vertical) * 20 * Time.fixedDeltaTime);
        }

        void Update()
        {
            _Horizontal = Input.GetAxis("Horizontal");
            _Vertical = Input.GetAxis("Vertical");
        }
    }

}
