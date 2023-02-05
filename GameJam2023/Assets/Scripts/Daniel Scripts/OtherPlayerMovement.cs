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

    //A
    private Animator animator;
    private int ToKid, ToYoung, ToOld;
    bool PassToKid, PassToYoung, PassToOld;

    void Start()
    {
        animator = GetComponent<Animator>();
        ToKid = 0;
        ToYoung= 23;
        ToOld = 48;
        PassToKid = true;
        PassToYoung = false; 
        PassToOld = false;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            //inAir = true;
        }
        /*
        if(script.currentlife >= ToYoung  && script.currentlife < ToOld && PassToYoung==false)
        {
            PassToKid = false;
            animator.SetBool("ToYoung", true);
            PassToYoung = true;
        }

        if (script.currentlife >= ToOld && PassToOld == false)
        {
            PassToYoung = false;
            animator.SetBool("ToOld", true);
            PassToOld = true;
        }

        if (script.currentlife >= ToKid && script.currentlife < ToYoung && PassToKid == false)
        {
            PassToOld = false;
            animator.SetBool("ToKid", true);
            PassToKid = true;
        }
        */

        if (script.currentlife == ToYoung && PassToYoung == false)
        {
            PassToKid = false;
            animator.SetBool("ToYoung", true);
            animator.SetBool("ToKid", false);
            PassToYoung = true;
        }

        if (script.currentlife == ToOld && PassToOld == false)
        {
            PassToYoung = false;
            animator.SetBool("ToOld", true);
            animator.SetBool("ToYoung", false);
            PassToOld = true;
        }

        if (script.currentlife == ToKid && PassToKid == false)
        {
            PassToOld = false;
            animator.SetBool("ToKid", true);
            animator.SetBool("ToOld", false);
            PassToKid = true;
        }

        animator.SetFloat("Movement", (((rb.velocity.x)* (rb.velocity.x))/2));

        animator.SetFloat("Jump", rb.velocity.y);

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
