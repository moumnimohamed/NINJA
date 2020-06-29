using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loadScenes : MonoBehaviour
{

    public Animator transition;
    // Start is called before the first frame update
/* 
      public static loadScenes Instance;
     
     void Awake(){
         if (Instance!=null){
             GameObject.Destroy(Instance);
     } else {
         Instance = this;         
         DontDestroyOnLoad(this);
     }

     } */
     
    void Start()
    {
        
    }

    // Update is called once per frame
    public void LoadNextLevel()
    {
        StartCoroutine(loadLevel( SceneManager.GetActiveScene().buildIndex + 1));
      
    }

    IEnumerator loadLevel(int levelIndex){
         yield return new WaitForSeconds(.5f);
        transition.SetTrigger("start");
        yield return new WaitForSeconds(1f);
          SceneManager.LoadScene( levelIndex);
      
    }
}
