using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartyPopper
{
    public class Ball : MonoBehaviour
    {

        [SerializeField]
        ParticleSystem _particle;

        [SerializeField]
        Material _neon;

        public void SetTeam(Team team)
        {
            Color color;

            switch (team)
            {
                case Team.NONE:
                    color = Color.white;
                    break;

                case Team.BLUE:
                    color = Color.blue;
                    break;

                case Team.GREEN:
                    color = Color.green;
                    break;

                case Team.RED:
                    color = Color.red;
                    break;

                case Team.YELLOW:
                    color = Color.yellow;
                    break;

                default:
                    color = Color.white;
                    break;
            }

            _neon.SetColor("_EmissionColor", color);

            ParticleSystem.MainModule main = _particle.main;
            main.startColor = color;
        }
    }
}
