using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
     public winning Winning;

    void Start()
    {
        Winning =  GameObject.FindGameObjectWithTag("lantern").GetComponent<winning>();;
       
 
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame 
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "ninja")
        {
              Winning.score +=1;
            FindObjectOfType<audio_manager>().Play("coin");
            animator.SetBool("coin", true);
        }
    }



}

