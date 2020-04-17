using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeasonManager : MonoBehaviour
{
        #region Singleton 
    public static SeasonManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)

        {
            Destroy(gameObject);
        }
    }
    #endregion

    GameManager gamemanager;
    GameTime timemanager;

    [Header("Different Terrains")]
    public GameObject[] terrains;

    public void changeTerrain()
    {

        terrains[0].SetActive(false);
        terrains[1].SetActive(false);
        terrains[2].SetActive(false);

        if (timemanager.Month == 5 || timemanager.Month == 7 || timemanager.Month == 8 || timemanager.Month == 6)
        {
            //seasonTxt.text = "Summer";
            terrains[0].SetActive(true);
            terrains[1].SetActive(false);
            terrains[2].SetActive(false);


        }
        else if (timemanager.Month == 9 || timemanager.Month == 10)
        {
            //seasonTxt.text = "Autum";
            terrains[0].SetActive(false);
            terrains[1].SetActive(true);
            terrains[2].SetActive(false);

        }
        else if (timemanager.Month == 1 || timemanager.Month == 11 || timemanager.Month == 12)
        {

            //seasonTxt.text = "Winter";
            terrains[0].SetActive(false);
            terrains[1].SetActive(false);
            terrains[2].SetActive(true);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameManager.instance;
        timemanager = GameTime.instance;

        

        changeTerrain();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
