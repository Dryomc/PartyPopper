using PartyPopper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartyPopper
{
    public class PlayerCircle : MonoBehaviour
    {

        [SerializeField]
        private TeamMember _player;

        private float _yPos;

        private void Start()
        {
            _yPos = transform.position.y;
            SetTeam(_player.GetTeam());
        }

        void Update()
        {
            transform.position = new Vector3(_player.transform.position.x, _yPos, _player.transform.position.z);
            // transform.rotation = _Player.transform.rotation;
        }

        public void SetTeam(Team team)
        {
            GetComponent<Renderer>().material.color = team.GetColor();
        }
    }
}
