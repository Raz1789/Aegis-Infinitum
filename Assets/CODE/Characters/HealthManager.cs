using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

    public float healthValue = 100f;

    public float tempHealth = 100;

    public Transform bloodSplatter;

    public Sprite deadSprite;

    private SpriteRenderer rend;
    public bool isDead = false;

	void Start ()
    {
        tempHealth = healthValue;
        rend = GetComponent<SpriteRenderer>();
        Invoke("CheckForDamage", 1.00f);
	}
	
	void Update ()
    {
        if (isDead)
        {

        }
        else
        { 
            Die();
        }
	}

    private void Die()
    {
        if(healthValue <= 0)
        {
            healthValue = 0;
            isDead = true;
            rend.sprite = deadSprite;
        }
    }

    void CheckForDamage()
    {
        if(tempHealth != healthValue)
        {
            Instantiate(bloodSplatter, transform.position + new Vector3(0, 0, 0.25f), Quaternion.Euler(0, 0, Random.Range(0, 359)));
        }

        tempHealth = healthValue;

        if (!isDead)
        {
            Invoke("CheckForDamage", 1.00f);
        }
    }
}
