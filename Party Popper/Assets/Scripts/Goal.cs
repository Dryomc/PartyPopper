using PartyPopper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour {

    [SerializeField]
    private Text _scoreDisplay;

    [SerializeField]
    private float _displayTime;

    private float _displayTimer;

    public delegate void TeamScore(Team team);
    public event TeamScore TeamScoreEvent;

    private void Update()
    {
        if (_displayTimer > 0)
            _displayTimer -= Time.deltaTime;

        if(_displayTimer <= 0)
            _scoreDisplay.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Ball"))
        {
            Ball ball = other.gameObject.GetComponent<Ball>();
            RespawnScript respawn = other.gameObject.GetComponent<RespawnScript>();

            Score(ball.GetTeam());
            ball.SetTeam(Team.NONE);
            respawn.Respawn();
        }
        else if (other.gameObject.tag.Equals("Player"))
        {
            RespawnScript respawn = other.gameObject.GetComponent<RespawnScript>();
            respawn.Respawn();
        }
    }

    private void Score(Team team)
    {
        _scoreDisplay.gameObject.SetActive(true);
        _displayTimer = _displayTime;
        _scoreDisplay.text = team.ToString() + " scored!";
        _scoreDisplay.color = team.GetColor();

        if (TeamScoreEvent != null)
            TeamScoreEvent(team);
    }
}
