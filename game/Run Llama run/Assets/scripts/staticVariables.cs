using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticVariables : MonoBehaviour
{
    public static int stars_collected;
    //public static int starsLevel1; //+gia tis upoloipes pistes klp
    //public static int starsLevel2;
    public static staticVariables staticVar;
    public static int starsSum;

    public static int level_id; //0 means 1st level
    public static int max_level_id = 3; //4 levels currently

    // Start is called before the first frame update
    void Start()
    {
        staticVar = this;
        starsSum = 0;
    }

    private void Awake()
    {
        staticVar = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void passStars(int stars)
    {
        //total_stars[i] = stars;
        //stars_collected += stars;
        //SWITCH CASE ANALOGA ME LOAD SCENE GIA TO POIA METAVLHTH THA XRHSIMOPOIHSW
        //starsLevel1 = stars;
    }
    /*
    public int returnStars()
    {
        return total_stars;
    }
    */
    public int stars_sum()
    {
        //+ ta stars ton upoloipwn otan gemisoun
        starsSum = 0;

        for (int i = 0; i <= max_level_id; i++)
        {

            starsSum += PlayerPrefs.GetInt("stars" + i, 0);
        }
        Debug.Log("STARS SUM = " + starsSum);

        return starsSum;
    }

    public void set_level_id(int id)
    {
        level_id = id;
    }

    public int get_level_id()
    {
        return level_id;
    }
}
