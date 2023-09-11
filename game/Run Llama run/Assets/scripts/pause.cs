using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    bool isPuased;
    // Start is called before the first frame update
    void Start()
    {
        isPuased = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pauseGame()
    {
        if (isPuased)
        {
            Time.timeScale = 1;
            isPuased = false;
        }
        else
        {
            Time.timeScale = 0;
            isPuased = true;
        }
    }
}
