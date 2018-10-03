using PartyPopper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartyPopper
{
    public class PlayerCircle : MonoBehaviour
    {

        [SerializeField]
        private GameObject _Player;

        [SerializeField]
        public float _offset;

        void Update()
        {
            transform.position = new Vector3(_Player.transform.position.x, _offset, _Player.transform.position.z);
            transform.rotation = _Player.transform.rotation;
        }

        public void SetTeam(Team team)
        {
            GetComponent<Renderer>().material.color = team.GetColor();
        }
    }
}
