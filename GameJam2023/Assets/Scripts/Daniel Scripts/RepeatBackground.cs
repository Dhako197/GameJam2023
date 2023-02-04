using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private BoxCollider2D boxC;
    public float backgroundSize;
    void Start()
    {
        boxC= GetComponent<BoxCollider2D>();
        backgroundSize = boxC.size.y * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -backgroundSize) RepeatBack();
    }

    private void RepeatBack()
    {
        Vector2 BGoffset = new Vector2(0, backgroundSize *2 );
        transform.position = (Vector2)transform.position + BGoffset;
    }
}
