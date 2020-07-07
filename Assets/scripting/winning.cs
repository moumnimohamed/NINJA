using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* using UnityEngine.Experimental.Rendering.Universal; */
public class winning : MonoBehaviour
{

    public loadScenes loadSceneScript;
    public Animator animator;
    public bool light;

    /* public Light2D pointLight; */
    // Start is called before the first frame update
    void Awake()
    {
        
        loadSceneScript = GameObject.FindGameObjectWithTag("loadScene").GetComponent<loadScenes>();
        animator = GetComponent<Animator>();
        if(light){
            animator.SetBool("start", true);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ninja")
        {
            animator.SetBool("start", true);
            loadSceneScript.LoadNextLevel();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
