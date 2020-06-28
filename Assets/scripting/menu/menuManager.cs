using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuManager : MonoBehaviour
{
    // Start is called before the first frame update
   public loadScenes loadScene;
    // Start is called before the first frame update
    void Start()
    {
        loadScene = GameObject.FindGameObjectWithTag("loadScene").GetComponent<loadScenes>();

    }


    public void loadlevel (){
        
         loadScene.LoadNextLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
