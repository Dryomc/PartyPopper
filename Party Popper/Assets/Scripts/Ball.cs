using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartyPopper
{
    public class Ball : MonoBehaviour
    {

        [SerializeField]
        ParticleSystem _trailParticleSystem;

        [SerializeField]
        Material _colorableMaterial;

        Team _team;

        ParticleSystem.MainModule _particleMain;
        ParticleSystem.TrailModule _particleTrail;


        private void Start()
        {
            _particleMain = _trailParticleSystem.main;
            _particleTrail = _trailParticleSystem.trails;
        }

        public Team GetTeam()
        {
            return _team;
        }

        public void SetTeam(Team team)
        {
            _team = team;
            Color color;

            switch (_team)
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

            _particleMain.startColor = color;
            _particleTrail.colorOverTrail = color;
            _particleTrail.colorOverLifetime = color;

            _colorableMaterial.SetColor("_EmissionColor", color);
        }
    }
}
