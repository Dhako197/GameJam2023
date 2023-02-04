using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{

    public float velocidad = 10;
    public float fuerzaSalto = 10;
    public float repulsionForce = 5.0f;
    private int saltos = 1;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(horizontal *velocidad, rb2d.velocity.y);
        if (Input.GetKeyDown(KeyCode.UpArrow) && saltos > 0)
        {
            rb2d.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
            saltos--;
        }
       if( saltos == 0 && IsGrounded())
       {
            saltos++;

       }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.)
    }
    void Update()
    {
        
    }

    private bool IsGrounded()
    {
        float extraHeightText = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(
            transform.position,
            GetComponent<BoxCollider2D>().size,
            0f,
            Vector2.down,
            extraHeightText,
            LayerMask.GetMask("Suelo")
        );

        return raycastHit.collider != null;
    }
   
}
