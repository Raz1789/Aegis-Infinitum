using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffCollider : MonoBehaviour {

    public float timeUntilColliderIsDisabled = 0.1f;
    private BoxCollider2D box;

	void Start ()
    {
        Invoke("DisableCollider", timeUntilColliderIsDisabled);
        box = GetComponent<BoxCollider2D>();
	}
	
	void Update ()
    {
		
	}

    void DisableCollider()
    {
        box.enabled = false;
    }
}
