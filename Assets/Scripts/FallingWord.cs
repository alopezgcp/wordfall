using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingWord : MonoBehaviour {
    public float fallrate = 0.0f;

    private void Start()
    {
        fallrate = Random.Range(.5f, 1.5f);
    }
    private void Update()
    {
        Vector2 newpos = new Vector2(transform.position.x, transform.position.y - fallrate);
        transform.position = newpos;

        if(transform.position.y < 100)
        {
            GameObject.Destroy(this);
        }
    }
}
