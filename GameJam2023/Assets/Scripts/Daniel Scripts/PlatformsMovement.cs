using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float speed = -0.7f;

    void Start()
    {
        
    }
    private void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
       
        rb2d.velocity = new Vector2(0, speed);
        speed -= 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeadSpace")) DestroyPlatform();
    }

    private void DestroyPlatform()
    {
        PlataformaBasicaPool.Instance.Return(gameObject);
    }
}
