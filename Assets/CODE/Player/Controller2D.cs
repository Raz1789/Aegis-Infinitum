using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour
{

    private Vector2 stepVec = Vector2.zero;

    private Rigidbody2D rb2D;

    public float moveSpeed = 1f;
    public float moveSmooth = 0.1f;
    public float turnSmooth = 0.5f;
    public float lookSmooth = 0.5f;
    public float projectileForce = 5000f;
    public float camSmooth = 0.5f;

    public Transform damageBubble;
    public Rigidbody2D projectile;
    public HealthManager health;

    public bool isMelee = false;
    public bool isRanged = false;

    void Start()
    {
        health = GetComponent<HealthManager>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (health.isDead)
        {
            FadeOutOccludingObjects();
        }
        else
        {
            Rotation();
            Movement();
            UseWeapon();
        }
    }

    private void UseWeapon()
    {
        if (isMelee && !isRanged)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Transform clone = Instantiate(damageBubble, transform.position + transform.right * .5f, Quaternion.identity) as Transform;

                clone.gameObject.GetComponent<MeleeWeapon>().author = gameObject;
            }
        }

        if (isRanged && !isMelee)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Rigidbody2D clone = Instantiate(projectile, transform.position + transform.right * 1.5f, transform.rotation) as Rigidbody2D;

                clone.gameObject.GetComponent<RangedProjectile>().author = gameObject;

                //clone.AddForce(transform.right * projectileForce);
            }
        }
    }

    void FadeOutOccludingObjects()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y, -10), transform.forward);
        if (hit.collider.tag == "Fade_Out")
        {
            hit.collider.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    private void Rotation()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), lookSmooth);
    }

    private void Movement()
    {
        stepVec = Vector2.Lerp(stepVec, new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")), turnSmooth);

        stepVec = Vector2.ClampMagnitude(stepVec, 1f);

        float angle = (Mathf.Atan2(stepVec.y, stepVec.x) * 180 / Mathf.PI) + 90;

        rb2D.MovePosition(Vector3.Lerp(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x, transform.position.y) + new Vector2(stepVec.x, stepVec.y) * moveSpeed, moveSmooth));
    }
}
