using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndOfTheDayReportManager : MonoBehaviour
{
    #region Singleton 
    public static EndOfTheDayReportManager instance = null;
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
    

    [Header("Break Down Text")]
    public Text date;
    public Text earned;
    public Text spent;
    public Text happyLvL;
    public Text pubLvl;
    public GameObject breakdownPanel;

    [Header("Final Result")]
    public Text overallRating;

    [Header("Colors")]
    public Color negativeColor;
    public Color possitiveColor;
    public Color MehColor;

    bool breakdown = false;

    public void breakDownReportUI()
    {
       
        date.text = "Report for the Day" + "\n" + timemanager.Day + "/" + timemanager.Month + "/" + timemanager.Year;
        earned.text = "Money Earned: " + gamemanager.EarnedM;
        spent.text = "Money Spent: " + gamemanager.SpentM;
        happyLvL.text = "Happiness Leve is ... ";  //we need to put the happiness level here.
        pubLvl.text = "Publicity Rating is " + gamemanager.Playerpublicity;


        if (gamemanager.EarnedM > gamemanager.SpentM && gamemanager.Playerpublicity >= 50)
        {
            overallRating.text = "You are in good standing! Keep up the good work.";
            overallRating.color = possitiveColor;
        }
        else if (gamemanager.EarnedM > gamemanager.SpentM && gamemanager.Playerpublicity >= 65)
        {
            overallRating.text = "Excellent work! Keep up it up.";
            overallRating.color = possitiveColor;
        }
        else if (gamemanager.EarnedM < gamemanager.SpentM && gamemanager.Playerpublicity >= 50)
        {
            overallRating.text = "You are spending more than your earnings. However your publicity is good. Keep up the good work.";
            overallRating.color = negativeColor;
        }
        else if (gamemanager.EarnedM < gamemanager.SpentM && gamemanager.Playerpublicity <= 50)
        {
            overallRating.text = "You are spending more than your earnings & your publicity isn't doing so hot. Make sure you get your publicity back up!";
            overallRating.color = negativeColor;
        }
        else
        {
            overallRating.text = "Keep it up!";
            overallRating.color = MehColor;
        }
    }

    public void OKbtn()
    {
        breakdownPanel.SetActive(false);
        breakdown = false;
        Time.timeScale = Time.timeScale = 1;
        gamemanager.EarnedM = 0;
        gamemanager.SpentM = 0;
    }

    public void BreakdownReport()
    {
        Time.timeScale = Time.timeScale = 0;
        breakdown = true;
        breakdownPanel.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameManager.instance;
        timemanager = GameTime.instance;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (breakdown == true)
        {
            breakDownReportUI();
        }
    }
}
