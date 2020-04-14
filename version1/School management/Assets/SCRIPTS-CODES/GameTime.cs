using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    public static GameTime instance=null;
    GameManager manager;
    Teachermanager teacher;


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

    

    private int Timescale = 600;//default45

    [Header("amount of money increase overtime")]
    [SerializeField] private float amount;

    private Text clockTxt, seasonTxt, dayTxt,datetxt;
    private int daysSurv;
    private float minute,day, second, month, year;
    public float hour;

    public int Timescale1 { get => Timescale; set => Timescale = value; }

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
        hour = 0;
        manager = GameManager.instance;
        teacher = Teachermanager.instance;
    }

    
    void Update()
    {
        CalculateTime();    
    }

    private void CalculateTime()
    {
        second += Time.deltaTime * Timescale1;
        Mathf.Round(second);
        //if (second >= 10&& Lobby.instance.StudentsInLine.Count > 0 )
        //{
            
             
        //        Lobby.instance.Register();

            
        //}
        if (second >= 60)
        {
            minute++;
            //GameManager.gameManager.AddMoneyOvertime(amount); Not using singleton
            //manager.AddMoneyOvertime(amount);
            
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

            // give XP
            manager.addExp(5);

            minute = 0;
            UpdateText();
        }
        else if(hour >= 24)
        {
            //manager.Gopay();
            
            day++;

            //teacher generator per day
            teacher.RandomGenNum();

            //total teacher salary paid per day
            manager.SumofSalary(manager.GrandtotalSalary1);

            if (manager.playerPaidSalary == true)
            {
                Debug.Log("Already paid!");
            }
            else
            {
                //total teacher salary paid per day
                manager.paySumofSalary();
                manager.playerPaidSalary = false;
            }
           

            hour = 0;

            
            UpdateText();
        }
        else if (day >= 28)
        {
            CalcMonth();
        }
        else if(month >= 12)
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
        if (minute >= 0&&minute<10)
        {
            clockTxt.text = "Time: " + hour + ":"+"0"+minute;
        }
        else
        {
            clockTxt.text = "Time: " + hour + ":" + minute;
        }
        datetxt.text = "Date: " + day+"/"+month + "/" + year;
       // monthtxt.text="Month"
        
    }
}
