using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame 
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "ninja")
        {
             
            FindObjectOfType<audio_manager>().Play("coin");
            animator.SetBool("coin", true);
        }
    }



}

