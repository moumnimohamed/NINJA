using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour
{

    public float speed;
    private float waitTime;
    public float startWaitTime;
    public Transform [] moveSpots  ;
    private Transform moveSpot  ;
  public Animator animator ;
    public float minX;

    public float maxX;
public float distanceX;
    public float minY;
    public float maxY;

    // Start is called before the first frame update
    void Start()
    { 
        animator=GetComponent<Animator>();
        waitTime=startWaitTime;
        int nbr =Random.Range(0,moveSpots.Length);
         moveSpot=moveSpots[nbr];
        moveSpot.position=new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));
    }

    // Update is called once per frame
    void Update()
    {
        distanceX=moveSpot.position.x-transform.position.x;
      
      if (distanceX >  0)
      {
      Flip(0.5f);
          
      }else if (distanceX < 0)

      {
         Flip(-0.5f); 
      }


     transform.position=Vector2.MoveTowards(transform.position,moveSpot.position,speed * Time.deltaTime);
    
    if (Vector2.Distance(transform.position,moveSpot.position  ) <.2f)
    {
        if (waitTime<=0)
        {
        moveSpot.position=new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));
            AnimState(1);
            waitTime=startWaitTime;
        }else
        {
            AnimState(0);
            waitTime-=Time.deltaTime;
        }
    }
        
    }

 void AnimState (int value){
     animator.SetInteger("anistate",value);
}
    void Flip (float value){
       
     Vector3 scaler =transform.localScale;
     scaler.x=value;
          transform.localScale=scaler;
 }
}
