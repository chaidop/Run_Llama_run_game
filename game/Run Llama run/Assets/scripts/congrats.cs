using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class congrats : MonoBehaviour
{
    public GameObject[] stars;
    public static congrats Congrats;
    public static int stars_collected = 0;
    // Start is called before the first frame update
    void Start()
    {
        Congrats = this;
        //stars_update();
    }

    public void stars_update(int level_id)
    {

        stars_collected = progressBar.progress.stars_collected;
        if (stars_collected == 1)
        {
            Debug.Log("1 STAR COLLECTED" + progressBar.progress.stars_collected);

            stars[1].SetActive(true);
        }
        else if (stars_collected == 2)
        {
            Debug.Log("2 STARS COLLECTED" + progressBar.progress.stars_collected);

            stars[0].SetActive(true);
            stars[1].SetActive(true);
        }
        else if(stars_collected == 3)
        {
            Debug.Log("3 STARS COLLECTED" + progressBar.progress.stars_collected);

            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
        else
        {
            Debug.Log("NO STARS COLLECTED" + progressBar.progress.stars_collected);

            stars[3].SetActive(true);
        }

        PlayerPrefs.SetInt("stars" + level_id, stars_collected);
    }

    public void backtomenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
