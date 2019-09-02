using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    // Start is called before the first frame update
   
    
	public float smoothSpeed = 0.125f;
	public Vector3 offset;
          public Transform target;
   


    public float maxDown ;
    public float maxright = 1147f;
    public float maxleft = 1147f;
 


    void Start (){

    
}

   void LateUpdate ()
    {
     
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp   (transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;



         Vector3   campos=transform.position;

            if (campos.x >= maxright)
            {
                campos.x = maxright;
            }
            else if (campos.x <= maxleft)
            {
                campos.x = maxleft;

            } 
             if (campos.y <= maxDown)
            {
                campos.y = maxDown;

            }
          
            transform.position = campos;
        }
       
    }


