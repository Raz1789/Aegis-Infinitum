using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceMovementDirection : MonoBehaviour {

    private Vector3 lastPos = Vector3.zero;
    public float turnSmooth = 0.1f;
    public float stopDist = 0.2f;

	void Start ()
    {
        InvokeRepeating("SetPos", 0.00f, 0.1f);
	}
	
	void Update ()
    {
        Rotate();
	}

    void Rotate()
    {
        if (Vector3.Distance(lastPos, transform.position) > stopDist)
        {
            Vector3 dir = transform.position - lastPos;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), turnSmooth);
        }
    }

    void SetPos()
    {
        lastPos = transform.position;
    }
}
