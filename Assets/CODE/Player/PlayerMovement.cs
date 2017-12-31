using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Player {
    [SerializeField]
    private float startingSpeed;

    private Rigidbody2D rb;

    private void Awake() {
        speed = startingSpeed;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        // Movement
        if ((Input.GetButton("Horizontal")) || (Input.GetButton("Vertical"))) {
            Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            rb.AddForce(dir * speed * speedMultiplier);
        }

        // Rotation
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 targetDir = (Input.mousePosition - pos).normalized;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
