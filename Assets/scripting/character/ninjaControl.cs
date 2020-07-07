using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ninjaControl : MonoBehaviour
{
    // Start is called before the first frame update

  public bool   grounded ;
public Transform groundCheck;
public float checkRadius;
public LayerMask whaIsGround;

    public Animator animator ;
    void Start()
    {
         animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      grounded=  Physics2D.OverlapCircle(groundCheck.position,checkRadius,whaIsGround);
    }
    void Update()
    {
        if(grounded){
            animator.SetInteger("animstate",0);
        }else{
              animator.SetInteger("animstate",1);
        }
        
    }


   public void Flip (float value){
       
     Vector3 scaler =transform.localScale;
     scaler.x=value;
          transform.localScale=scaler;
 }


}
