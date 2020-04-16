using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    public static GameTime instance=null;
    GameManager manager;
    Teachermanager teacher;
    SchoolEventManager eventmanager;
    weatherManager wmanager;
    EndOfTheDayReportManager reportManager;


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

    

    private int Timescale = 400;//default45

    [Header("amount of money increase overtime")]
    [SerializeField] private float amount;

    private Text clockTxt, seasonTxt, dayTxt,datetxt;
    private int daysSurv;
    private float minute, day, second, month, year;
    public float hour;

    public int Timescale1 { get => Timescale; set => Timescale = value; }
    public float Day { get => day; set => day = value; }
    public float Month { get => month; set => month = value; }
    public float Year { get => year; set => year = value; }

    void Start()
    {
        Month = 1;
        Day = 1;
        Year = 2000;
        clockTxt = GameObject.Find("Clock").GetComponent<Text>();
        dayTxt = GameObject.Find("DaysSurv").GetComponent<Text>();
        seasonTxt = GameObject.Find("Season").GetComponent<Text>();
        datetxt = GameObject.Find("Date").GetComponent<Text>();
        CalculateSeason();
        hour = 0;
        manager = GameManager.instance;
        teacher = Teachermanager.instance;
        eventmanager = SchoolEventManager.instance;
        wmanager = weatherManager.instance;
        reportManager = EndOfTheDayReportManager.instance;
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
            
            Day++;

            //teacher generator per day
            teacher.RandomGenNum();

            //random event triggered at 50%
            if (Random.Range(0, 2) == 1)
            {
                eventmanager.eventTriggered();
            }

            //Breakdown report!
            reportManager.BreakdownReport();

            //weather generator per day
            wmanager.RandomWeather();

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
            BroadcastMessage("DetermineHappines",SendMessageOptions.DontRequireReceiver);
            
            UpdateText();
        }
        else if (Day >= 28)
        {
            CalcMonth();
        }
        else if(Month >= 12)
        {
            Month = 1;
            Year++;
            UpdateText();
            CalculateSeason();
        }

    }
    private void CalcMonth()
    {
        if (Month == 1 || Month == 3 || Month == 5||Month == 7 || Month == 8 || Month == 10 || Month == 12 )

        {
            if (Day >= 32)
            {
                daysSurv++;
                Month++;
                Day = 1;
                UpdateText();
                CalculateSeason();
            }
        }
        if (Month == 4 || Month == 6 || Month == 9 || Month == 11)

        {
            if (Day >= 31)
            {
                daysSurv++;
                Month++;
                Day = 1;
                UpdateText();
                CalculateSeason();
            }
        }
        if (Month == 2)

        {
            if (Day >= 29)
            {
                daysSurv++;
                Month++;
                Day = 1;
                UpdateText();
                CalculateSeason();
            }
        }
    }
    private void CalculateSeason()
    {
        if( Month == 2 || Month == 3|| Month == 4)

        {
            seasonTxt.text = "Spring";
        }
        else if( Month == 5 || Month == 7|| Month == 8|| Month == 6)
        {
            seasonTxt.text = "Summer";
            
        }
        else if ( Month == 9||Month == 10)
        {
            seasonTxt.text = "Autum";

        }
        else if (Month == 1 || Month == 11 || Month == 12)
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
        datetxt.text = "Date: " + Day+"/"+Month + "/" + Year;
       // monthtxt.text="Month"
        
    }
}
