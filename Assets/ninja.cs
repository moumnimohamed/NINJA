using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ninja : MonoBehaviour
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
       grounded= Physics2D.OverlapCircle(groundCheck.position,checkRadius,whaIsGround);
    }
    void Update()
    {
        
    }
}
