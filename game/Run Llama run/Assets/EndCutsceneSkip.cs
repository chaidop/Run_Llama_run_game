using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class EndCutsceneSkip : MonoBehaviour
{
    private bool finished = false;
    IEnumerator Start()
    {

        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(13);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        finished = true;
    }

    // Update is called once per frame
    void Update()
    {

        //if skip button pressed or cutscene ended, disable this canvas
        if (Input.anyKey || finished)
        {
            Debug.Log("Cutscene finished");
            onTriggerEvent();
        }
    }

    void onTriggerEvent()
    {
        SceneManager.LoadScene("mainMenu");
    }

}
