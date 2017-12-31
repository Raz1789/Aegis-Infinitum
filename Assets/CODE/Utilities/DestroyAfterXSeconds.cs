using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterXSeconds : MonoBehaviour {

    public float secondsUntilDestroy = 5f;

	void Start ()
    {
        Invoke("DestroySelf", secondsUntilDestroy);	
	}

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
