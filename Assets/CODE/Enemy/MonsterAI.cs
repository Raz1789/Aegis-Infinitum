using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour {

    #region Numbers

    public float turnSmooth = 0.1f;
    public float moveSmooth = 0.1f;
    public float distFromZ = 0.5f;

    #endregion

    #region Vectors

    public Vector3 randPos = Vector3.zero;

    #endregion  

    #region Components

    private Rigidbody2D rb2D;
    public HealthManager health;

    #endregion

    void Start ()
    {
        rb2D = GetComponent<Rigidbody2D>();
        health = GetComponent<HealthManager>();

        Invoke("GetRandPos", 0.00f);
	}

    void FixedUpdate()
    {
        if (!health.isDead)
        {
            RandomMovement();
        }
        else
        {

        }
    }

	void Update ()
    {
		if(!health.isDead)
        {
            
        }
        else
        {

        }
	}

    void RandomMovement()
    {
        if(Vector3.Distance(transform.position, randPos) > 0.3f)
        {
            Vector3 dir = randPos - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), turnSmooth);

            Vector2 thisPos = new Vector2(transform.position.x, transform.position.y);

            Vector2 posToGoTo = new Vector2(randPos.x, randPos.y);

            rb2D.MovePosition(Vector2.Lerp(thisPos, posToGoTo, moveSmooth));
        }
    }

    void GetRandPos()
    {
        randPos = new Vector3(Random.Range(-5, 5), -distFromZ, Random.Range(-5, 5));

        Invoke("GetRandPos", Random.Range(0.5f, 2.5f));
    }
}
