using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public TMP_Text total_stars_text;

    void Start()
    {

    }

    private void Awake()
    {
       
    }

    void Update()
    {   
       
    }

    public void total_stars_text_update()
    {
        total_stars_text.text = "x" + staticVariables.staticVar.stars_sum();
    }

    public void PlayGame()
    {
        int stars = staticVariables.staticVar.stars_sum();
        int level = 0;

        if (stars >= 7)
            level = 3;
        else if (stars >= 4)
            level = 2;
        else if (stars >= 2)
            level = 1;

        staticVariables.staticVar.set_level_id(level);
        SceneManager.LoadScene("SampleScene");
    }
    

    public void QuitGame()
    {
        Debug.Log("Understandable, have a great day!");
        Application.Quit();
    }

    public void level1()
    {
        staticVariables.staticVar.set_level_id(0);
        panelInit.panel_init.panelInitialise();
    }

    public void level2()
    {
            staticVariables.staticVar.set_level_id(1);
            panelInit.panel_init.panelInitialise();
    }

    public void level3() //For now, just loading level3 again
    {
            staticVariables.staticVar.set_level_id(2);
            panelInit.panel_init.panelInitialise();
    }

    public void level4() //For now, just loading level4 again
    {
            staticVariables.staticVar.set_level_id(3);
            panelInit.panel_init.panelInitialise();
    }
}
