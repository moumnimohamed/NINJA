using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        void OnTriggerEnter2D(Collider2D col)
    {
         
        if (col.tag == "ninja"){
                Time.timeScale = 0.2f;
            
        }

        }

           void OnTriggerExit2D(Collider2D col)
    {
         
        if (col.tag == "ninja"){
          if (Time.timeScale != 1.0f)
                Time.timeScale = 1f;
        }

        }
    }


