using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedProjectile : MonoBehaviour {

    public float damage = 25f;
    public float moveSpeed = 0.5f;

    public GameObject author;

    public bool canDoDamage = true;

    private Rigidbody2D rb2D;
    private BoxCollider2D box;

    void Start ()
    {
        rb2D = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
	}
	
	void Update ()
    {
        MoveProjectile();
	}

    private void MoveProjectile()
    {
        rb2D.MovePosition(transform.position + transform.right * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<HealthManager>() && author != collision.gameObject && canDoDamage)
        {
            collision.gameObject.GetComponent<HealthManager>().healthValue -= damage;
            canDoDamage = false;
        }

        if (author != collision.gameObject)
        {
            Destroy(gameObject);
        }
    }
}
