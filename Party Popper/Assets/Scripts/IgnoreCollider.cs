using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollider : MonoBehaviour {

    [SerializeField]
    private string[] _tagsToIgnore;

    private Collider[] _colliders;

	void Start () {
        _colliders = gameObject.GetComponents<Collider>();
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (IsIgnoredTag(collision.gameObject.tag))
            foreach (Collider collider in _colliders)
                Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), collider, true);
    }

    private bool IsIgnoredTag(string otherTag)
    {
        foreach (string tag in _tagsToIgnore)
            if (otherTag.Equals(tag))
                return true;

        return false;
    }
}
