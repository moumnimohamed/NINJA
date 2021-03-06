﻿using System.Collections;
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
         FindObjectOfType<audio_manager>().Play("japanMusic");

    }

    // Update is called once per frame
    public void LoadNextLevel()
    {

         FindObjectOfType<audio_manager>().stop("japanMusic");
        /* AudioSource[] Sounds = FindObjectOfType<audio_manager>().GetComponents<AudioSource>();
        foreach (AudioSource s in Sounds)
        {

            s.volume = 0;

        } */

         FindObjectOfType<audio_manager>().Play("taiko"); 

        StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex + 1,.5f));

    }
    public void LoadSameLevel()
    {

         FindObjectOfType<audio_manager>().stop("japanMusic");
        /* AudioSource[] Sounds = FindObjectOfType<audio_manager>().GetComponents<AudioSource>();
        foreach (AudioSource s in Sounds)
        {

            s.volume = 0;

        } */

         FindObjectOfType<audio_manager>().Play("dead"); 

        StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex,3f ));

    }

    public void loadLevel (int levelNbr){
         StartCoroutine(loadLevel( levelNbr,0 ));
         
    }



    IEnumerator loadLevel(int levelIndex , float sc)
    {
        yield return new WaitForSeconds(sc);
        transition.SetTrigger("start");
          
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelIndex);

    }
}
