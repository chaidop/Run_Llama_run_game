using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressBar : MonoBehaviour
{

    public Slider slider;
    public static progressBar progress;
    public int stars_collected;
    public GameObject[] stars;
    public GameObject[] starsYellow;
    //public Texture yellowStar;

    // private float targetProgress = 0;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }


    // Start is called before the first frame update
    void Start()
    {
        progress = this;
        slider.value = 0.0f;
        stars_collected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementProgress(float newProgress)
    {
   
        slider.value += newProgress;
        if (slider.value >= slider.maxValue/2.0f)
        {
            stars[0].SetActive(false);
            starsYellow[0].SetActive(true);
            stars_collected = 1;
        }
        if (slider.value >= (3.0f * slider.maxValue) / 4.0f)
        {
            stars[1].SetActive(false);
            starsYellow[1].SetActive(true);
            stars_collected = 2;
        }
        if (slider.value >= 0.97)
        {
            stars[2].SetActive(false);
            starsYellow[2].SetActive(true);
            stars_collected = 3;
        }

        // Debug.Log(slider.value);
    }
}
