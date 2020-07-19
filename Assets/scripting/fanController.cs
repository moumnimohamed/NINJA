using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanController : MonoBehaviour
{

    public Transform targetTransform;
    Vector3 touchPosition;
    AreaEffector2D AreaEffector;
    SpriteRenderer spriteRenderer;
    public float speed;
    // Start is called before the first frame update

    public GameObject fanChild;
    private Animator fanAnimator;
      private GameObject ninja;
    private SpriteRenderer ninjaSr;
    void Start()
    {

        fanChild = GameObject.FindGameObjectWithTag("fan");
        fanAnimator = fanChild.GetComponent<Animator>();
        fanChild.GetComponent<SpriteRenderer>().enabled = false;
         ninja=GameObject.FindGameObjectWithTag("ninja")  ;
        targetTransform = ninja.GetComponent<Transform>();
        ninjaSr=ninja.GetComponent<SpriteRenderer>();

        AreaEffector = GetComponent<AreaEffector2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
             
                fanAnimator.SetBool("openfan", true);
                // we want 2m away from the camera position
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0f;
                transform.position = touchPosition;
                fanChild.transform.position = touchPosition;
                /*apply wind*/
                Vector3 vectorToTarget = targetTransform.position - transform.position;

                Debug.Log(vectorToTarget.x);

                float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, speed);
                AreaEffector.enabled = true;
                spriteRenderer.enabled = true;

                 if (vectorToTarget.x > 0)
            {
                ninjaSr.flipX  = false;
            }
            else
            {
                ninjaSr.flipX  = true;
            }
            
        }
           else {
                fanAnimator.SetBool("openfan", false);
                AreaEffector.enabled = false;
                spriteRenderer.enabled = false;
            }


        }

    

}
