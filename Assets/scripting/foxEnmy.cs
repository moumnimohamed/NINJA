using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foxEnmy : MonoBehaviour
{
 
    
bool enmyDead=false;
    public int health;
     public  int healthValue;
       public Animator animator ;


       public float speed=0;
       public float retreatDistance=0;
       public float stopingDistance=0;

public Transform player;
     
    



  private Rigidbody2D rb;

    void Start()
    {
        
        rb=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        healthValue=health;
        player =GameObject.FindGameObjectWithTag("ninja").transform;
        
    }

    void FixedUpdate()
 {
  
//folow ninja to kill hime
 if (Vector2.Distance(transform.position,player.position) > stopingDistance)
 {
     transform.position=Vector2.MoveTowards(transform.position,player.position,speed * Time.deltaTime);
     AnimState(1);

 }
 //run far  from ninja if i attacked him
 else if (Vector2.Distance(transform.position,player.position) < retreatDistance   )
 {
     transform.position=Vector2.MoveTowards(transform.position,player.position,-speed * Time.deltaTime);
     AnimState(1);
     
 }
 // stop enmy from moving 
 //normally must not stoping
  else if (Vector2.Distance(transform.position,player.position) < stopingDistance &&  Vector2.Distance(transform.position,player.position) > retreatDistance  )
 {
     transform.position= this.transform.position;
       AnimState(0);
     
 }

 }

    // Update is called once per frame
    void Update()
    {    
 
         

       /*  if ( enmyDead==false)
        {
           
                AnimState(1);
        }
        else if ( enmyDead==false)
        {
         
                AnimState(0);
        }*/
    }
 

    public void takeDammage (int dmg){
         healthValue-=dmg;
         if (healthValue<=0)
         {
             enmyDead=true;
              
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
            //col.GetComponent<Rigidbody2D>().velocity=Vector2.up*20;
             

        }
    }

    void AnimState (int value){
     animator.SetInteger("anistate",value);
}

 
 void Flip (){
//      facengleft=  !facengleft;
     Vector3 scaler =transform.localScale;
     scaler.x*=-1;
     transform.localScale=scaler;
    
 }
}
