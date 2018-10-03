using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour {

    [SerializeField]
    private bool _automaticSpawnpointDetection;

    [SerializeField]
    private Vector3 _spawnpoint;


	void Start () {
        if (_automaticSpawnpointDetection)
            _spawnpoint = transform.position;
	}
	
	public void Respawn()
    {
        transform.position = _spawnpoint;
    }
}
