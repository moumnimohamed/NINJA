using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanAnimation : MonoBehaviour
{
     public float speed;
     public bool rotateNow=false;
    void Start()
    {
        
    }

    // Update is called once per frame
     // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (rotateNow)
         transform.Rotate (Vector3.forward * Time.deltaTime* speed);
    }

    public void startRotation (){
        rotateNow=true;
    }
    public void stopRotation (){
        rotateNow=false;
    }
}
