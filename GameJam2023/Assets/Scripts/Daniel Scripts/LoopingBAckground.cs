using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBAckground : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float speed= -1.5f;
    [SerializeField] private bool stop_scrolling;

    void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, speed);

    }
    void Update()
    {
        if( stop_scrolling) rb2d.velocity = Vector2.zero;
        else rb2d.velocity = new Vector2(0, speed);

    }

}
