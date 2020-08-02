using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class borders : MonoBehaviour
{
    public loadScenes loadSceneScript;
    public  GameObject ninja;
    private  ninjaControl ninjaCont;
    public  CameraShake cameraShake;
    private  Animator anim;
    // Start is called before the first frame update
    void Start()
    {
         ninja =  GameObject.FindGameObjectWithTag("ninja") ;
         cameraShake =  GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>(); ;
         anim =  ninja.GetComponent<Animator>();
         ninjaCont =  ninja.GetComponent<ninjaControl>();
 loadSceneScript = GameObject.FindGameObjectWithTag("loadScene").GetComponent<loadScenes>();
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    // called when the cube hits the floor
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "ninja")
        { 
            ninjaCont.alive=false;
             cameraShake.shakeDuration=1;
             anim.SetInteger("animstate",6);
             loadSceneScript.LoadSameLevel();
            
            
        } 
          if (col.tag == "shuraken")
        {
            Destroy(col.gameObject);
            
        }
    }
}
