using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class panelInit : MonoBehaviour
{
    public static panelInit panel_init;

    public GameObject[] stars;
    public TMP_Text song_text;
    public TMP_Text artist_text;
    public TMP_Text highscore_text;
    public GameObject zipper;
    public GameObject starspanel;


    int levelId;
    int stars_collected;

    // Start is called before the first frame update
    void Start()
    {
        panel_init = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void panelInitialise()
    {
        stars[0].SetActive(false);
        stars[1].SetActive(false);
        stars[2].SetActive(false);
        zipper.SetActive(true);
        levelId = staticVariables.staticVar.get_level_id();

        if (levelId == 0)
        {
            song_text.text = "Place On Fire";
            artist_text.text = "Creo";
            
        }
        else if (levelId == 1)
        {
            song_text.text = "Epic Cinematic";
            artist_text.text = "Scott Holmes";
        }
        else if (levelId == 2)
        {
            song_text.text = "Hall Of The Mountain King";
            artist_text.text = "Grieg";
        }
        else if (levelId == 3)
        {
            song_text.text = "Exotica";
            artist_text.text = "Juanitos";
        }

        highscore_text.text = "" + PlayerPrefs.GetInt("hiscore" + levelId, 0);
        stars_update(levelId);
        zipperInit();
    }

    public void stars_update(int level_id)
    {

        stars_collected = PlayerPrefs.GetInt("stars" + level_id, 0);
        if (stars_collected == 1)
        {
            stars[0].SetActive(true);
        }
        else if (stars_collected == 2)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
        }
        else if (stars_collected == 3)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
    }

    public void zipperInit()
    {
        levelId = staticVariables.staticVar.get_level_id();
        if (levelId == 0)
        {
            zipper.SetActive(false);
        }
        else if (levelId == 1)
        {
            if (staticVariables.staticVar.stars_sum() >= 2)
            {
                zipper.SetActive(false);
            }
        }
        else if (levelId == 2)
        {
            if (staticVariables.staticVar.stars_sum() >= 4)
            {
                zipper.SetActive(false);
            }
        }
        else if (levelId == 3)
        {
            if (staticVariables.staticVar.stars_sum() >= 7)
            {
                zipper.SetActive(false);
            }
        }
    }

    public void playButton()
    {
        levelId = staticVariables.staticVar.get_level_id();
        Debug.Log("LEVEL ID = " + levelId);

        if (levelId == 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else if (levelId == 1)
        {
            if (staticVariables.staticVar.stars_sum() >= 2)
            {
                Debug.Log("loading");
                SceneManager.LoadScene("SampleScene");
            }
            else
            {
                Debug.Log("not enough stars");

                starspanel.SetActive(true);
                starsLeftInit.starsPanel.panelInitialise();
                //this.SetActive(false);
            }
        }
        else if (levelId == 2)
        {
            if (staticVariables.staticVar.stars_sum() >= 4)
            {
                SceneManager.LoadScene("SampleScene");
            }
            else
            {
                starspanel.SetActive(true);
                starsLeftInit.starsPanel.panelInitialise();
                //this.SetActive(false);
            }
        }
        else if (levelId == 3)
        {
            if (staticVariables.staticVar.stars_sum() >= 7)
            {
                SceneManager.LoadScene("SampleScene");
            }
            else
            {
                starspanel.SetActive(true);
                starsLeftInit.starsPanel.panelInitialise();
                //this.SetActive(false);
            }
        }

    }

}
