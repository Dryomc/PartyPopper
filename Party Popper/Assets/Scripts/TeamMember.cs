using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartyPopper
{
    public class TeamMember : MonoBehaviour
    {

        [SerializeField]
        Team _team;

        private void OnCollisionEnter(Collision collision)
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();

            if (ball != null)
                ball.SetTeam(_team);
        }
    }
}
