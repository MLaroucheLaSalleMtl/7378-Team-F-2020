﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    //public static GameManager gameManager;

    PlayerLog eventlog;

    TeacherMono teachermono;

    [Header("Player Level")]
    [SerializeField] private int maxExp;
    [SerializeField] private float updatedExp;

    public Text leveltext;
    public Image Expbar;

    [SerializeField] private GameObject confetti;
    [SerializeField] private GameObject lvlsplash;

    [SerializeField] private int expIncrease;
    [SerializeField] private int playerLevel;

    [Header("Level SFX")]
    public AudioClip lvlSFX;
    private AudioSource lvlsfxSource { get { return GetComponent<AudioSource>(); } }
    public Transform[] LevelMarkers;

    [Header("Gold Coins")]
    [SerializeField] private float money;
    [SerializeField] Text moneyText; //"Money Text"

    [Header("Gold SFX")]
    public AudioClip goldSFX;
    private AudioSource goldsfxSource { get { return GetComponent<AudioSource>(); } }

    [Header("Student Count")]
    Text StudentCountText;//"StudentCount"
    private int StudentCount;
    private int classRCount;
    [SerializeField] private Text classRCountText;//"classRCount"

    //ADMIN
    private int adminCount;

    [Header("Teacher Count")]
    private int teacherCount;
    [SerializeField] private Text TeacherCountTXT;

    [Header("Salary Needs to be paid")]    
    [SerializeField] private float totalSalary;
    [SerializeField] private float totalSalaryPerDay;
    [SerializeField] private float GrandtotalSalary;

    public Text totalSalarytxt;
    public Text SalaryPaidtxt;
    public Text GrandtotalSalarytxt;

    public bool playerPaidSalary = false;

    // public Text incrementTxt; //tester

    public Vector3 LocationOfSpawn = new Vector3(-7.98f, 5.7f, -72f);
    public static GameManager instance = null;

    public List<GameObject> Clasesbogth = new List<GameObject>();
    public int NumberOfMagic = 0;
    public int NumberOfSurfing = 0;
    public int NumberOfHacking = 0;
    public int NumberOfAxeTrowing = 0;


    public string[] AvalableClases = new string[] { "Magic", "Surfing", "Hacking", "Axe Trowing" };



    List<string> Clases = new List<string>();

    [Header("Male & Female Student Prefab Toinstanciate")]
    [SerializeField] private GameObject[] Student;

    private int StudentSpawn;

    [SerializeField] private GameObject[] waypontsinmanagement;

  

    public int ClassRCount { get => classRCount; set => classRCount = value; }
    public float Money { get => money; set => money = value; }
    public int TeacherCount { get => teacherCount; set => teacherCount = value; }
    public float TotalSalary { get => totalSalary; set => totalSalary = value; }
   
    public float TotalSalaryPerDay { get => totalSalaryPerDay; set => totalSalaryPerDay = value; }
    public float GrandtotalSalary1 { get => GrandtotalSalary; set => GrandtotalSalary = value; }

    public int AdminCount { get => adminCount; set => adminCount = value; }
    
    public int MaxExp { get => maxExp; set => maxExp = value; }
    public float UpdatedExp { get => updatedExp; set => updatedExp = value; }
    public int ExpIncrease { get => expIncrease; set => expIncrease = value; }
    public int PlayerLevel { get => playerLevel; set => playerLevel = value; }
    public int StudentCount1 { get => StudentCount; set => StudentCount = value; }

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

    ///SFX 
    public void sfxStuff()
    {
        gameObject.AddComponent<AudioSource>();
        goldsfxSource.clip = goldSFX;
        lvlsfxSource.clip = lvlSFX;

        //SFX volume Gold
        goldsfxSource.volume = 0.5f;
        goldsfxSource.playOnAwake = false;

        //SFX Volume Level
        lvlsfxSource.volume = 0.5f;
        lvlsfxSource.playOnAwake = false;

    }

    public void playGoldSFX()
    {
        goldsfxSource.PlayOneShot(goldSFX);
    }

    public void playLevelSFX()
    {
        lvlsfxSource.PlayOneShot(lvlSFX);
    }

    ///LEVEL SYSTEM  
    public void playerBeginLvl()
    {
        PlayerLevel = 1;
        MaxExp = 100;
        UpdatedExp = 0;
        Expbar.fillAmount = 0;
    }

    public void addExp(int ExpIncrease)
    {
        //ExpIncrease = 50; for testing purposes lol
        UpdatedExp += ExpIncrease;
        Expbar.fillAmount = UpdatedExp / MaxExp;

        levelUp();
    }


    public void levelUp()
    {
        confetti.SetActive(false);
        lvlsplash.SetActive(false);

        if (UpdatedExp >= MaxExp)
        {
            PlayerLevel++;
            confetti.SetActive(true);
            lvlsplash.SetActive(true);
            playLevelSFX();
            UpdatedExp = 0;
            MaxExp += MaxExp/2;
        }
    }


    public void ClasesNumber()
    {

        NumberOfMagic = 0;
        NumberOfSurfing = 0;
        NumberOfHacking = 0;
        NumberOfAxeTrowing = 0;

        foreach (GameObject clasroom in Clasesbogth)
        {
            if (clasroom.tag == "Magic")
            {
                NumberOfMagic++;
            }
            else if (clasroom.tag == "Haking")
            {
                NumberOfHacking++;
            }
            else if (clasroom.tag == "AxeTrowing")
            {
                NumberOfAxeTrowing++;
            }
            else if (clasroom.tag == "Surfing")
            {
                NumberOfSurfing++;
            }

        }
    }

    public bool SpaceOnClasroomBogth()
    {
        bool temp = false;
        if (Clasesbogth.Count > 0)
        {

            foreach (GameObject a in Clasesbogth)
            {
                if (a.GetComponent<ClasroomScip>().IsthereSpace())
                    temp = true;

            }

            return temp;
        }
        else
        {
            return false;
        }
    }
    void Start()
    {
        eventlog = PlayerLog.instance;

        StudentCountText = GameObject.FindGameObjectWithTag("StudentCount").GetComponent<Text>();
        classRCountText = GameObject.FindGameObjectWithTag("ClassCount").GetComponent<Text>();
        TeacherCountTXT = GameObject.FindGameObjectWithTag("TeacherCount").GetComponent<Text>();

        playerBeginLvl();

       

    }



    void Update()
    {

        UpdateMoneyUI();
        RefreshTextOnUI();
        classRTxtOnUI();
        ClasesNumber();
        teacherTxtOnUI();
        updateNewlyHiredTSalary();
        updateCurrentTSalary();
        updateRecentTSalary();
        levelTxtOnUI();
        //levelUp();

    }

    /// money
    public void AddMoney(float amount)
    {
        money += amount;
        playGoldSFX();
        UpdateMoneyUI();
    }

    public void ReduceMoney(float amount)
    {
        money -= amount;
        playGoldSFX();
        UpdateMoneyUI();
    }

    public void AddMoneyOvertime(float amount)
    {
        money += amount++;
        UpdateMoneyUI();
    }

    public bool RequestMoney(float amount)
    {
        if (amount <= money)
        {
            return true;
        }
        return false;
    }


    /// student
    public void AddStudent()
    {
        StudentCount1++;

    }

    public void AddClasses()
    {
        classRCount++;

    }

    public void ReduceClasses()
    {
        classRCount--;

    }

    //TEACHER

    public void AddTeacher()
    {
        TeacherCount++;
    }

    /// ADMIN
    public void AddAdmin()
    {
        AdminCount++;
    }

    // SALARY
    public void SumofSalary(float teacherSalary)
    {

        TotalSalaryPerDay += teacherSalary;

       calcTotalSumofAllSalary();

    }

    public void calcTotalSumofAllSalary()
    {
        //cal what needs to be paid in TOTAL
        GrandtotalSalary1 = TotalSalaryPerDay + totalSalary;
    }


    public void paySumofSalary()
    {
        if (playerPaidSalary == true)
        {
            eventlog.AddEvent("Already paid!");
            Debug.Log("Already paid!");
        }
        else
        {
            //remove it from the Money
            ReduceMoney(TotalSalaryPerDay); //GrandtotalSalary1

            //resets the daily salary 
            TotalSalary += TotalSalaryPerDay;
            TotalSalaryPerDay = 0;

            //paid salary indicator
            playerPaidSalary = true;
        }

    }

    




    // UI 
    public void updateCurrentTSalary()
    {
        SalaryPaidtxt.text = "Paid Salary: $" + TotalSalary.ToString();
    }

    public void updateNewlyHiredTSalary()
    {
        totalSalarytxt.text = "Salary to Pay: $" + TotalSalaryPerDay.ToString();
    }

    public void updateRecentTSalary()
    {
        GrandtotalSalarytxt.text = "Total Upkeep: $" + GrandtotalSalary1.ToString(); 
    }

    public void UpdateMoneyUI()
    {
        moneyText.text = "$ " + money.ToString("N0");
    }

    public void RefreshTextOnUI()
    {
        StudentCountText.text = "Students: "+StudentCount1;
    }

    public void classRTxtOnUI()
    {
        classRCountText.text = "Class Built: "+classRCount;
    }

    public void teacherTxtOnUI()
    {
        TeacherCountTXT.text = "Teachers: " + TeacherCount;
    }

    public void levelTxtOnUI()
    {
        leveltext.text = "Level " + playerLevel;
    }

    

    public void Spawn(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Instantiate (Student[Random.Range(0,1)], LocationOfSpawn, Quaternion.identity);
        }
    }
    public void SpawnCode()
    {
        Instantiate(Student[Random.Range(0,1)], LocationOfSpawn, Quaternion.identity);
        //Instantiate(Student, LocationOfSpawn, Quaternion.identity);

    }

    public Administration[] managementlines;
    public List<GameObject> Allregisteredstudents;

    public void Gopay()
    {
        managementlines[0].studentstopay = new List<GameObject>();
        managementlines[1].studentstopay = new List<GameObject>();
        managementlines[2].studentstopay = new List<GameObject>();
        managementlines[3].studentstopay = new List<GameObject>();
        foreach (GameObject student in Allregisteredstudents) {
            if (student.GetComponent<StudentMono>().Paid == false)
            {
                NavMeshAgent agent;
                agent = student.GetComponent<NavMeshAgent>();
                int temp=0;
                for (int i = 0; i < managementlines.Length; i++)
                {
                    int f = 1;

                    if (managementlines[i].Isthereasecretary && managementlines[i].studentstopay.Count <= managementlines[f].studentstopay.Count)
                    {
                        temp = i;
                    }

                }

                managementlines[temp].studentstopay.Add(student);
            }

        }
        StartCoroutine( managementlines[0].Payfees());
        managementlines[0].organiseline();
        StartCoroutine( managementlines[1].Payfees());
        managementlines[1].organiseline();
        StartCoroutine( managementlines[2].Payfees());
        managementlines[2].organiseline();
        StartCoroutine( managementlines[3].Payfees());
        managementlines[3].organiseline();

    }
}
