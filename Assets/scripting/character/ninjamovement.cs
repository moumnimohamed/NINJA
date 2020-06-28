using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ninjamovement : MonoBehaviour
{
     public int health;
     public  int healthValue;

public Transform attackPos;
    public LayerMask whatIsenmies;
    public float attackRangeX;
    public float attackRangeY;

public bool amAttaking =false;


    public float moveSped =5f;
    public Animator animator ;
    public Rigidbody2D rb;
    Vector2 movement;
    // Start is callded before the first frame update
    void Start()
    {
        healthValue=health;
        rb=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();

        
    }

    void Flip (float value){
       
     Vector3 scaler =transform.localScale;
     scaler.x=value;
          transform.localScale=scaler;
 }

    // Update is called once per frame
    void Update()
    {
        movement.x=Input.GetAxisRaw("Horizontal");
         movement.y=Input.GetAxisRaw("Vertical");
         
    }
    // Update is called once per frame
    void FixedUpdate()
    {
           
            rb.MovePosition(rb.position + movement * moveSped *Time.fixedDeltaTime);
   
     animator.SetFloat("horizontal",movement.x);
         animator.SetFloat("speed",movement.sqrMagnitude);
         if(movement.x >0){
             
         Flip (0.5f);

         }else if(movement.x <0)
         {
         Flip (-0.5f);
             
         
        }
       


         
    /*attack animation */

    if (Input.GetKeyDown(KeyCode.Z)  &&  amAttaking==false)
    {
        
         //play random  animation
         Random rnd = new Random();
                  int animRang   = Random.Range(1, 3);
                  Debug.Log(animRang);
                  if (animRang==1)
                  {
         animator.SetBool("attack",true);
                      
                  } else  if (animRang==2)
                  {
         animator.SetBool("attack2",true);
                      
                  }

                
        
    }
    }


public void Attack (){
     // Time.timeScale = .2f;
         amAttaking=true;

          Collider2D [] enemiestoDammage=Physics2D.OverlapBoxAll(attackPos.position,new Vector2(attackRangeX,attackRangeY),0,whatIsenmies);
 for (int i = 0; i < enemiestoDammage.Length; i++)
 {
    enemiestoDammage[i].GetComponent<foxEnmy>().takeDammage(1);
   
 }
 
}

 

    public void stopAttack () {
         animator.SetBool("attack",false);
        
         amAttaking=false;
       //  Time.timeScale = 1f;
    }

     public void stopAttack2 () {
             animator.SetBool("attack2",false);
         amAttaking=false;
    }


     void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color =Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX,attackRangeY,1));
    }

 public void  DammageNinja (int dmg){
         healthValue-=dmg;
         if (healthValue<=0)
         {
             
            
             //enmyDead=true;
              Destroy(gameObject);
            //AnimState(3);
            
         }
    }
 }
