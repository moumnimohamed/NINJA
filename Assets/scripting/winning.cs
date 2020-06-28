using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winning : MonoBehaviour
{

    public loadScenes loadScene;
    // Start is called before the first frame update
    void Start()
    {
        loadScene = GameObject.FindGameObjectWithTag("loadScene").GetComponent<loadScenes>();

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ninja")
        {
            loadScene.LoadNextLevel();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
