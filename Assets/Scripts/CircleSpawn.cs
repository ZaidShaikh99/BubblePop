using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawn : MonoBehaviour
{
    public GameObject spawn;
    Vector2 position;

    // Start is called before the first frame update
    private void Start()
    {
        spawnCircle();
    }
    public void spawnCircle()
    {
        for(int i = 0; i < 16; i++)
        {
            position = new Vector2(Random.Range(-8.0f, 8.0f), Random.Range(-4.0f, 4.0f));
            Instantiate(spawn, position, Quaternion.identity);
        }
    }
}
