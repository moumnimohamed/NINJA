using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ninjaControl : MonoBehaviour
{
    // Start is called before the first frame update

    public bool grounded;
    public bool alive = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whaIsGround;

    public Animator animator;
    private Rigidbody2D rb;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whaIsGround);
    }
    void Update()
    {
        if (grounded && alive)
        {
            animator.SetInteger("animstate", 0);
        }
        else if (!grounded && alive && rb.velocity.y >= 0.1)
        {
            animator.SetInteger("animstate", 1);

        }
        else if (!grounded && alive && rb.velocity.y < 0)
        {
            animator.SetInteger("animstate", 7);
        }

        if (alive && grounded && Mathf.Abs(rb.velocity.x) > 1)
        {
            animator.SetInteger("animstate", 2);
        }

    }





}
