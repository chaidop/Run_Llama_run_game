using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifeSystem : MonoBehaviour
{

    public GameObject[] lifes;
    public int life;
    public static lifeSystem lifesystem;

    // Start is called before the first frame update

    void Start()
    {
        life = 3;
        lifesystem = this;
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void LifeRemoved(int d)
    {
        if (life == 1)
        {
            Destroy(lifes[0].gameObject);
            GameManagerScript.instance.GameOver();
        }
        else if (life == 2)
        {
            Destroy(lifes[1].gameObject);
        }
        else
        {
            Destroy(lifes[2].gameObject);
        }

        life -= d;
        //Debug.Log(life);
    }
}
