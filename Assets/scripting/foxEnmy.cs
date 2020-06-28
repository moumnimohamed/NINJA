using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foxEnmy : MonoBehaviour
{
     public GameObject bloodEffect;
     public GameObject bloodPos;

    public GameObject [] bodyParts;

    public Transform attackPos;
    public LayerMask whatIsenmies;
    public float attackRangeX;
    public float attackRangeY;
 
    
bool enmyDead=false;
    public int health;
     public  int healthValue;
       public Animator animator ;
  public float distanceX ;
  public float distanceY ;

public bool attaking=false;
       public float speed=0;
      // public float retreatDistance=0;
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
     distanceX=player.position.x-transform.position.x;
      distanceY=player.position.y-transform.position.y;
      if (distanceX >  0)
      {
      Flip(0.5f);
          
      }else if (distanceX < 0)

      {
         Flip(-0.5f); 
      }
    

  float distance=Vector2.Distance(transform.position,player.position);
  //Debug.Log(distance);
//folow ninja to kill hime
 if (distance > stopingDistance && !attaking)
 {
     transform.position=Vector2.MoveTowards(transform.position,player.position,speed * Time.deltaTime);
     AnimState(1);

 }
 //attack in stop postion
 /*else if (distance < retreatDistance   )
 {
 
     transform.position=Vector2.MoveTowards(transform.position,player.position,-speed * Time.deltaTime);

       AnimState(2);
     
     
 }*/
 // stop enmy from moving 
 //normally must not stoping
  else if (distance < stopingDistance && !attaking /* Vector2.Distance(transform.position,player.position) > retreatDistance*/  )
 {
     transform.position= this.transform.position;
         attaking=true;
             AnimState(2);
     
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

        var clo=  Instantiate(bloodEffect, bloodPos.transform.position  , transform.rotation );
          clo.transform.localScale =new Vector3 (transform.localScale.x*-2 ,1, 1);
              /*bodyParts when died*/
                      
        var t = transform;

		 

			t.TransformPoint (0, -100, 0);
            Instantiate (bodyParts[1], t.position, Quaternion.identity) ;
			var head = Instantiate (bodyParts[0], t.position, Quaternion.identity) ;
			var body2D = head.GetComponent<Rigidbody2D> ();
			body2D.AddForce (Vector3.right *-transform.localScale.x * 100f );
            	body2D.AddForce (Vector3.up  * Random.Range (-100f, 100f));
			 
		          



         Destroy(this.gameObject);
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
    
    }
       void OnTriggerExit2D(Collider2D col)
    {
    
    }



public void attack (){
   
         Collider2D [] enemiestoDammage=Physics2D.OverlapBoxAll(attackPos.position,new Vector2(attackRangeX,attackRangeY),0,whatIsenmies);
 for (int i = 0; i < enemiestoDammage.Length; i++)
 {
    enemiestoDammage[i].GetComponent<ninjamovement>().DammageNinja(1);
     

 }
}

    void AnimState (int value){
     animator.SetInteger("anistate",value);
}

 

public void stopAttack(){
    //*run away from enmy*/
    attaking=false;
    AnimState(1);
    StartCoroutine("startPatrol");
    
}

IEnumerator startAttackAgain() 
{
     
       /*  this.gameObject.GetComponent<patrol>().enabled =false; */
    this.gameObject.GetComponent<foxEnmy>().enabled =true;
            yield return new WaitForSeconds(Random.Range(4,8)); 
}

IEnumerator startPatrol() 
{
       /*  this.gameObject.GetComponent<patrol>().enabled =true; */
    this.gameObject.GetComponent<foxEnmy>().enabled =false;
     yield return new WaitForSeconds(Random.Range(4,8)); 
     StartCoroutine("startAttackAgain");
          
}

  void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color =Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX,attackRangeY,1));
    }

 void Flip (float value){
       
     Vector3 scaler =transform.localScale;
     scaler.x=value;
          transform.localScale=scaler;
 
}
}
