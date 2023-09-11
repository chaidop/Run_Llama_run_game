using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class starsLeftInit : MonoBehaviour
{

    public static starsLeftInit starsPanel;
    int levelId;
    int stars_collected;
    public TMP_Text stars;
    public GameObject panel;
    //int stars_left;
    // Start is called before the first frame update
    void Start()
    {
        starsPanel = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void panelInitialise()
    {
        levelId = staticVariables.staticVar.get_level_id();
        stars_collected = staticVariables.staticVar.stars_sum();

        if(levelId == 1)
        {
            stars.text = "" + (2 - stars_collected);
        }
        else if (levelId == 2)
        {
            stars.text = "" + (4 - stars_collected);
        }
        else if (levelId == 3)
        {
            stars.text = "" + (7 - stars_collected);
        }

    }

    public void backButton()
    {
        panel.SetActive(true);
    }
}
