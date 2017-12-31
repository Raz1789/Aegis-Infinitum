using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTerrainDetail : MonoBehaviour {

    public int numberOfObjectsToPlace = 500;
    public float radius = 500f;
    public int iterationsPerLoop = 99999;
    public Transform objectToPlace;
    public Transform objectParent;
    public float sizeMinimum = 0.5f;
    public float sizeMaximum = 1f;
    public float depth = 2f;

    void Start()
    {

    }

    void Update()
    {
        if (numberOfObjectsToPlace > 0)
        {
            for (int i = 0; i < iterationsPerLoop; i++)
            {
                Vector2 castPos = Random.insideUnitCircle * radius;

                RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(castPos.x, castPos.y, -10), transform.forward);

                if (hit.collider == null)
                {
                    float randNum = Random.Range(sizeMinimum + 0.012345f, sizeMaximum + 0.012345f);

                    Transform clone = Instantiate(objectToPlace, new Vector3(castPos.x, castPos.y, Random.Range(-depth, -depth - 0.12345f)), 
                        Quaternion.Euler(0, 0, Random.Range(0, 359))) as Transform;
                    clone.localScale = clone.localScale * randNum;
                    clone.SetParent(objectParent);

                    numberOfObjectsToPlace--;

                    if(numberOfObjectsToPlace == 0)
                    {
                        break;
                    }
                }

            }
        }
    }
}
