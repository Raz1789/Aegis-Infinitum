using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour {

    public float damage = 25f;

    public Transform bloodSplatter;
    public GameObject author;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != author)
        {
            collision.gameObject.GetComponent<HealthManager>().healthValue -= damage;
        }
    }
}
