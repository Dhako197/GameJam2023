using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private int ToKid, ToYoung, ToOld;
    bool PassToKid, PassToYoung, PassToOld;

    private Rigidbody2D rb;
    public Heritage script;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ToKid = 0;
        ToYoung = 23;
        ToOld = 48;
        PassToKid = true;
        PassToYoung = false;
        PassToOld = false;
    }

    void Update()
    {
        PassAnimation();

        animator.SetFloat("Movement", (((rb.velocity.x) * (rb.velocity.x)) / 2));

        animator.SetFloat("Jump", rb.velocity.y);
    }
    private void PassAnimation()
    {
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
    }
}
