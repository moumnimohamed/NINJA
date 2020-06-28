using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        
        if(col.gameObject.name == "ninja")
        {
          col.gameObject.GetComponent<CharacterController2D>().deadNinja();
        }
    
        }
}
