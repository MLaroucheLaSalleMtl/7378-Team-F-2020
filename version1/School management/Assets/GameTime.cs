using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    public static GameTime instance=null;
    GameManager manager;

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

    

    private const int Timescale = 600;//default45

    [Header("amount of money increase overtime")]
    [SerializeField] private float amount;

    private Text clockTxt, seasonTxt, dayTxt,datetxt;
    private int daysSurv;
    private double minute,day, second, month, year;
    public double hour;

    void Start()
    {
        month = 1;
        day = 1;
        year = 2000;
        clockTxt = GameObject.Find("Clock").GetComponent<Text>();
        dayTxt = GameObject.Find("DaysSurv").GetComponent<Text>();
        seasonTxt = GameObject.Find("Season").GetComponent<Text>();
        datetxt = GameObject.Find("Date").GetComponent<Text>();
        CalculateSeason();
        hour = 6;
        manager = GameManager.instance;
    }

    
    void Update()
    {
        CalculateTime();    
    }

    private void CalculateTime()
    {
        second += Time.deltaTime * Timescale;
        //if (second >= 10&& Lobby.instance.StudentsInLine.Count > 0 )
        //{
            
             
        //        Lobby.instance.Register();

            
        //}
        if (second >= 60)
        {
            minute++;
            //GameManager.gameManager.AddMoneyOvertime(amount); Not using singleton
            manager.AddMoneyOvertime(amount);
            
            second = 0;
            UpdateText();
        }else
        if (minute >= 60)
        {
            // if(manager.AvalableClases[1].)
            //if (GameObject.Find("Lobby") != null)
            //{
            //    manager.SpawnCode();
            //}
            hour++;
            minute = 0;
            UpdateText();
        }
        else if(hour >= 24)
        {
           
            day++;
            hour = 0;
            UpdateText();
        }else if (day >= 28)
        {
            CalcMonth();
        }else if(month >= 12)
        {
            month = 1;
            year++;
            UpdateText();
            CalculateSeason();
        }

    }
    private void CalcMonth()
    {
        if (month == 1 || month == 3 || month == 5||month == 7 || month == 8 || month == 10 || month == 12 )

        {
            if (day >= 32)
            {
                daysSurv++;
                month++;
                day = 1;
                UpdateText();
                CalculateSeason();
            }
        }
        if (month == 4 || month == 6 || month == 9 || month == 11)

        {
            if (day >= 31)
            {
                daysSurv++;
                month++;
                day = 1;
                UpdateText();
                CalculateSeason();
            }
        }
        if (month == 2)

        {
            if (day >= 29)
            {
                daysSurv++;
                month++;
                day = 1;
                UpdateText();
                CalculateSeason();
            }
        }
    }
    private void CalculateSeason()
    {
        if( month == 2 || month == 3|| month == 4)

        {
            seasonTxt.text = "Spring";
        }
        else if( month == 5 || month == 7|| month == 8|| month == 6)
        {
            seasonTxt.text = "Summer";
            
        }
        else if ( month == 9||month == 10)
        {
            seasonTxt.text = "Autum";

        }
        else if (month == 1 || month == 11 || month == 12)
        {
            
            seasonTxt.text = "Winter";
        }
        
    }

    private void UpdateText()
    {
        dayTxt.text = "Days survived: "+daysSurv;
        clockTxt.text = "Time: " + hour + ":" + minute;
        datetxt.text = "Date: " + day+"/"+month + "/" + year;
       // monthtxt.text="Month"
        
    }
}
