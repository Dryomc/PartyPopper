using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCircle : MonoBehaviour {

    [SerializeField]
    private GameObject _Player;
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(_Player.transform.position.x, 3.15f, _Player.transform.position.z);
        transform.rotation = _Player.transform.rotation;
	}
}
