using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snapSpawner : MonoBehaviour
{
    public Vector3 GridSize;

    public Transform player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        snapToGrid();
    }

    void snapToGrid()
    {

        //transform.position = new Vector3(Mathf.Round(transform.position.x) * 30, Mathf.Round(transform.position.y) * 30, Mathf.Round(transform.position.z) * 30);

        transform.position = player.position;

        transform.position = new Vector3(((int)(transform.position.x / GridSize.x)) * GridSize.x, ((int)(transform.position.y / GridSize.y)) * GridSize.y, 0);
    }
}
