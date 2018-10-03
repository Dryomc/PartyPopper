using PartyPopper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartyPopper
{
    public class PlayerCircle : MonoBehaviour
    {

        [SerializeField]
        private TeamMember _Player;

        private float _yPos;

        private void Start()
        {
            _yPos = transform.position.y;
            SetTeam(_Player.GetTeam());
        }

        void Update()
        {
            transform.position = new Vector3(_Player.transform.position.x, _yPos, _Player.transform.position.z);
            // transform.rotation = _Player.transform.rotation;
        }

        public void SetTeam(Team team)
        {
            GetComponent<Renderer>().material.color = team.GetColor();
        }
    }
}
