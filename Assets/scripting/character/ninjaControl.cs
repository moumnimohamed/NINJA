using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ninjaControl : MonoBehaviour
{
    // Start is called before the first frame update

    public bool grounded;
    public bool alive = true;
    public bool attack = false;
    public Rigidbody2D bullet;
    public float bulletSpeed;

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

        if (attack)
        {
            animator.SetInteger("animstate", 5);
        }

        if (!attack && grounded && alive)
        {
            animator.SetInteger("animstate", 0);
        }
        else if (!attack && !grounded && alive && rb.velocity.y >= 0.1)
        {
            animator.SetInteger("animstate", 1);

        }
        else if (!attack && !grounded && alive && rb.velocity.y < 0)
        {
            animator.SetInteger("animstate", 7);
        }

        if (!attack && alive && grounded && Mathf.Abs(rb.velocity.x) > 1)
        {
            animator.SetInteger("animstate", 2);
        }

    }



    public void shootBullet()
    {
        bool flipX = this.GetComponent<SpriteRenderer>().flipX;
        int der = flipX ? -1 : 1;
        Vector3 plus = new Vector3( der * 1, 0, 0);
        Rigidbody2D bulletInstance = Instantiate(bullet,  transform.position + plus, Quaternion.Euler(new Vector3(0, 0, 1))) as Rigidbody2D;
        bulletInstance.velocity = transform.forward * der * bulletSpeed;
         FindObjectOfType<audio_manager>().Play("change");
    }

    public void stopAttack()
    {
        attack = false;
    }



}
