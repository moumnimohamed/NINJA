using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{

    public string playerName = "";
    public static game_manager instance;
    public GameObject [] players;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);


    
        playerName = PlayerPrefs.GetString("playerName");
        if (playerName == "ninja")
        {
            playerName = "ninja";
          players[1].transform.GetChild(0).gameObject.SetActive(false);
            players[0].transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (playerName == "girl")
        {
            playerName = "girl";
             players[1].transform.GetChild(0).gameObject.SetActive(true);
             players[0].transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            playerName = "ninja";
        }
    }

    // Update is called once per frame

    public void ChangePlayer()
    {
        FindObjectOfType<audio_manager>().Play("change");
        if (playerName == "ninja")
        {
            playerName = "girl";
             players[1].transform.GetChild(0).gameObject.SetActive(true);
             players[0].transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            playerName = "ninja";
            players[1].transform.GetChild(0).gameObject.SetActive(false);
           players[0].transform.GetChild(0).gameObject.SetActive(true);
        }
        PlayerPrefs.SetString("playerName", playerName);


    }
   
}
