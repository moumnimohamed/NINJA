using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
 public Animator animator ;
    // Start is called before the first frame update
    public Transform ninja ;
    public Vector3 coinPosFromNinja ;
    public float speed ;
      private bool moveCoin =false;

    void Start()
    {
          animator=GetComponent<Animator>();
             ninja =  GameObject.FindGameObjectWithTag("ninja").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {  
        if(moveCoin){
  transform.position = Vector2.MoveTowards(transform.position,ninja.position+coinPosFromNinja, speed*Time.deltaTime);
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "ninja")
        {
                moveCoin=true;
                StartCoroutine("startCoin");
         }
    }


    IEnumerator startCoin() 
{
        
     
            yield return new WaitForSeconds(3); 
            animator.SetBool("coin",true);
}
}

