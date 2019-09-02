using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public  bool move=false;
    public  bool idle=false;
    public  bool facengleft=false;
    
    public float runspeed=10f;
public float runspeedvalue;
bool enmyDead=false;
    public int health;
       int healthValue;
       public Animator animator ;
    // Start is called before the first frame update
    public bool groundtouch;
     public Transform groundcheck;

    public bool walltouch;
     public Transform wallcheck;
    public float checkradius;

    public LayerMask whatiswall;
    public LayerMask whatisground;



  private Rigidbody2D rb;

    void Start()
    {
        if (!idle && !enmyDead)
        {
         runspeedvalue=runspeed;            
        } 
        rb=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        healthValue=health;
        
    }

    void FixedUpdate()
 {
 
     rb.velocity=new Vector2 (runspeedvalue,rb.velocity.y);
    walltouch= Physics2D.OverlapCircle(wallcheck.position,checkradius,whatiswall);
    groundtouch= Physics2D.OverlapCircle(groundcheck.position,checkradius,whatisground);

 }

    // Update is called once per frame
    void Update()
    {

        if (  walltouch || !groundtouch  )
        {
            Flip();
             runspeedvalue=runspeedvalue*-1;
        }


         

         if (move && enmyDead==false)
        {
           
                AnimState(1);
        }
        else if (idle && enmyDead==false)
        {
            runspeedvalue=0;
                AnimState(0);
        }
    }
 

    public void takeDammage (int dmg){
         healthValue-=dmg;
         if (healthValue<=0)
         {
             enmyDead=true;
             runspeedvalue=0;
            AnimState(3);
            
         }
    }
     
       void OnCollisionEnter2D(Collision2D col)
    {
        if (enmyDead==false )
        {
        if(col.gameObject.name == "ninja")
        {
          col.gameObject.GetComponent<CharacterController2D>().deadNinja();
        }
    }      
        }

        void OnTriggerEnter2D(Collider2D col)
    {
         
        if (col.tag == "ninja"){
             
             takeDammage (1);
             runspeedvalue=0;
            col.GetComponent<Rigidbody2D>().velocity=Vector2.up*20;
             

        }
    }

    void AnimState (int value){
     animator.SetInteger("anistate",value);
}

 
 void Flip (){
      facengleft=  !facengleft;
     Vector3 scaler =transform.localScale;
     scaler.x*=-1;
     transform.localScale=scaler;
    
 }
}
