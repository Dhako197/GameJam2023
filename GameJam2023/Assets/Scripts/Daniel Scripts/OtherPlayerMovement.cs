using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OtherPlayerMovement : MonoBehaviour
{
    

    private float horizontal;
    private float _speed = 8f;
    public float _jumpingPower = 16f;
    private bool isFacingRight = true;
    public AudioSource jumpsound;
    //private bool inAir = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public Heritage script;
    //Singleton Player
    public static OtherPlayerMovement instance;

    public float speed { get => _speed; set => _speed = value; }
    public float jumpingPower { get => _jumpingPower; set => _jumpingPower = value; }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            //inAir = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && rb.velocity.y > 0f)
        {
            jumpsound.Play();
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeadSpace")) DestroyPlayer();
    }

    private void DestroyPlayer()
    {
        Debug.Log("Manco hp");
        //SceneManager.LoadScene("Daniel Scene");
        gameObject.SetActive(false);
    }
}
