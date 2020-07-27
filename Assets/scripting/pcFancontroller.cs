using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pcFancontroller : MonoBehaviour
{

    public Transform targetTransform;
    AreaEffector2D AreaEffector;
    SpriteRenderer spriteRenderer;

    private GameObject ninja;
    private SpriteRenderer ninjaSr;
    public GameObject fanChild;
    private Animator fanAnimator;

    // Start is called before the first frame update
    void Awake()
    {

        /* PlayerPrefs.DeleteAll(); */
        string playerName = PlayerPrefs.GetString("playerName");
        if (playerName != "ninja" && playerName != "girl")
        { playerName = "ninja"; }

        GameObject player = Instantiate(Resources.Load(playerName) as GameObject);
        player.transform.position = GameObject.FindGameObjectWithTag("playerPos").transform.position;


        fanChild = GameObject.FindGameObjectWithTag("fan");
        fanAnimator = fanChild.GetComponent<Animator>();
        fanChild.GetComponent<SpriteRenderer>().enabled = false;
        ninja = GameObject.FindGameObjectWithTag("ninja");
        ninjaSr = ninja.GetComponent<SpriteRenderer>();

        targetTransform = ninja.GetComponent<Transform>();
        AreaEffector = GetComponent<AreaEffector2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        /*shoot cal*/
        if (Input.GetMouseButton(1))
        {
            ninja.GetComponent<ninjaControl>().attack = true;
        }

        if (Input.GetMouseButton(0))
        {
            // we want 2m away from the camera position
            fanAnimator.SetBool("openfan", true);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPosition.z = 0f;
            transform.position = touchPosition;
            fanChild.transform.position = touchPosition;
            /*apply wind*/
            Vector3 vectorToTarget = targetTransform.position - transform.position;


            if (vectorToTarget.x > 0)
            {
                ninjaSr.flipX = false;
            }
            else
            {
                ninjaSr.flipX = true;
            }


            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, 1f);
            AreaEffector.enabled = true;
            spriteRenderer.enabled = true;
        }
        else
        {
            fanAnimator.SetBool("openfan", false);
            AreaEffector.enabled = false;
            spriteRenderer.enabled = false;
        }




    }

}
