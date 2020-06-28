using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{ 

    private bool facengleft=false;
    bool dead=false;
	public Animator animator ;
     
     public bool iamAttaking=false;

    public bool isgrounded;
    public bool walltouch;
    
    public Transform groundcheck;
     public Transform wallcheck;
    public float checkradius;
    public LayerMask whatisground;
public float runspeed=10f;
 float runspeedvalue;

public int  rorationforce=100;

public int jumpForce=200;
 public int extrajump ;
 public int extrajumpsvalue ;
  bool faceingRight;

  private Rigidbody2D rb;

public float slideVilocity;

public GameObject dustPrefab;
public GameObject JumpEffectPrefab;

	public float dustSpawnDelay = .5f;
	private float timeElapsed = 0f;

    public Transform attackPos;
    public LayerMask whatIsenmies;
    public float attackRangeX;
    public float attackRangeY;



 void Start()
 {
    
      runspeedvalue=runspeed;
      
     extrajump=extrajumpsvalue;
     rb=GetComponent<Rigidbody2D>();

 }

 
 void FixedUpdate()
 {
isgrounded= Physics2D.OverlapCircle(groundcheck.position,checkradius,whatisground);
 walltouch= Physics2D.OverlapCircle(wallcheck.position,checkradius,whatisground);
     rb.velocity=new Vector2 (runspeedvalue,rb.velocity.y);
    
 }

 
void Update()
{


/*  flim and move if wall touch */
 if (walltouch)
 {
     moveFunc();
 }


    /*silde in wall */
    if (walltouch && !isgrounded && rb.velocity.y<0  && dead==false)
{
    iamAttaking=false;
    if(Mathf.Abs(runspeedvalue) ==  runspeed/2)
    runspeedvalue=0;
    
    
           AnimState(4);
          rb.velocity= new Vector2(rb.velocity.x,slideVilocity);

          /*add effect */
          if(timeElapsed > dustSpawnDelay){

				var dust = Instantiate(dustPrefab);
               
				var pos = transform.position;
				pos.y += 1;
				dust.transform.position = pos;
                 dust.transform.Rotate(0,0,transform.localScale.x*90); 
				dust.transform.localScale=new Vector3 (-transform.localScale.x,transform.localScale.y,transform.localScale.z) ;
				timeElapsed = 0;

			}

			timeElapsed += Time.deltaTime;
}



/*if grounded */

    if (isgrounded==true && iamAttaking==false && dead==false )
    {
        extrajump=extrajumpsvalue;
        AnimState(1);
        timeElapsed = 0;
    }
    else if (isgrounded==false && !walltouch  && iamAttaking==false  && dead==false )
    {
         AnimState(2);
    }



   

/*attack animation */

    if (Input.GetKeyDown(KeyCode.Space) && iamAttaking==false && !walltouch && dead==false)
    {

          iamAttaking=true;
          Collider2D [] enemiestoDammage=Physics2D.OverlapBoxAll(attackPos.position,new Vector2(attackRangeX,attackRangeY),0,whatIsenmies);
 for (int i = 0; i < enemiestoDammage.Length; i++)
 {
    /* enemiestoDammage[i].GetComponent<enemy>().takeDammage(1); */
    enemiestoDammage[i].GetComponent<Collider2D>().enabled = false;
    /*push enmy */
    Rigidbody2D rbeenmy=enemiestoDammage[i].GetComponent<Rigidbody2D>();
    rbeenmy.isKinematic=true;
    rbeenmy.AddForce(transform.right *runspeedvalue*1000);
 }
   rb.AddForce(transform.right *runspeedvalue*120);
        AnimState(5);
    }
} 

public void  stopAttack(){
       iamAttaking=false ;
     
       
}

 
 void Flip (){
      facengleft=  !facengleft;
     Vector3 scaler =transform.localScale;
     scaler.x*=-1;
     transform.localScale=scaler;
 }


 public  void runEffect (){
     var dust = Instantiate(dustPrefab);
               
				var pos = transform.position;
				
				dust.transform.position = pos;
                 /* dust.transform.Rotate(0,0,transform.localScale.x*90); */
				dust.transform.localScale=new Vector3 (transform.localScale.x,transform.localScale.y,transform.localScale.z) ;
				
 }
 
 private  void jumpEffect(){
     var dust = Instantiate(JumpEffectPrefab);
               
				var pos = transform.position;
				dust.transform.position = pos; 
				dust.transform.localScale=new Vector3 (transform.localScale.x,transform.localScale.y,transform.localScale.z) ;
				
 }

  void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color =Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX,attackRangeY,1));
    }

    public void deadNinja(){
        dead=true;
        runspeedvalue=0;
        Time.timeScale = 0.5f;
        AnimState (6);   
    }

void AnimState (int value){
     animator.SetInteger("animstate",value);
}

    
 public  void jumpFunc(){
      if ( extrajump >0    && iamAttaking==false  && dead==false)
    {
            jumpEffect();
        rb.velocity=Vector2.up*jumpForce;
        extrajump--;
    }
    else if ( extrajump < 0   && iamAttaking==false  && dead==false )
    {/*double jump */
            jumpEffect();           
        rb.velocity=Vector2.up*jumpForce;
          
    } 
    /*jump when slide in wall */
   if (walltouch && !isgrounded /*&& Input.GetKeyDown(KeyCode.UpArrow) */ && dead==false)
{
      extrajump=0;
          rb.velocity=Vector2.up*jumpForce;
          Flip();
    runspeedvalue=runspeedvalue*-1;

}
}

 public  void moveFunc(){

     /*run  move */
if (isgrounded   && dead==false  )
{
  
    Flip();
    runspeedvalue=runspeedvalue*-1;
}
 }

    
 
}
