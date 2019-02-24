using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingWord : MonoBehaviour {
    public float minfallrate = 0.4f, maxfallrate = 1.2f;
    private float fallrate;

    private void Start()
    {
        fallrate = Random.Range(minfallrate, maxfallrate);
    }
    private void Update()
    {
        Vector2 newpos = new Vector2(transform.position.x, transform.position.y - fallrate);
        transform.position = newpos;
    }
}
