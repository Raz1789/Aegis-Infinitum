using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOccludingObjects : MonoBehaviour {

    private SpriteRenderer sprite;
    public float alphaLevel = 0;

	void Start ()
    {

	}
	
	void Update ()
    {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        Color colour = new Color();

        if(collision.tag == "OccludingObject")
        {
            sprite = collision.gameObject.GetComponent<SpriteRenderer>();

            float dist = Vector3.Distance(transform.position, collision.transform.position);

            if(dist <= 20)
            {
                alphaLevel = dist / 20;
            }
            
            //alphaLevel = Mathf.Lerp(alphaLevel, 0.2f, 0.1f);

            colour.a = alphaLevel;

            sprite.color = colour;
        }
    }
}
