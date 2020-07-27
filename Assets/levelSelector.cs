using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class levelSelector : MonoBehaviour
{
     public TextMeshProUGUI totalScore  ;
    public List<Button> buttons = new List<Button>();
    public Color activeColor;
    public Color lockedColor;

    private loadScenes loadSceneScript;
    private void Start()
    {
               
               FindObjectOfType<audio_manager>().stop("japanMusic");   
               FindObjectOfType<audio_manager>().Play("wind");   
        /* PlayerPrefs.DeleteAll();   */

       /*  change icons status */
       int countScore =0;
        for (int i = 2; i < buttons.Count; i++)
        {
             
            int score = PlayerPrefs.GetInt("lv" + i);
                countScore +=  score;
            Transform coinParent = buttons[i-2].transform.GetChild(1);

            for (int j = 0; j < score; j++)
            {
                coinParent.transform.GetChild(j).GetComponent<Image>().color = activeColor;
            }
        }
            totalScore.text="* "+ countScore;

        for (int i = 1; i < buttons.Count; i++)
        {



            int previewLevelNum = int.Parse(buttons[i].name) - 1;
            int score = PlayerPrefs.GetInt("lv" + previewLevelNum);
            if (score > 0)
            {
                buttons[i].GetComponent<Image>().color = activeColor;


                buttons[i].interactable = true;
            }
            else
            {
                buttons[i].GetComponent<Image>().color = lockedColor;

            }
        }

        loadSceneScript = GameObject.FindGameObjectWithTag("loadScene").GetComponent<loadScenes>();

    }

    public void LoadScene(int levelNbr)
    {
         FindObjectOfType<audio_manager>().Play("taiko");
        loadSceneScript.loadLevel(levelNbr);
    }



}
