using System.Collections;
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

    Reputation rep;

    [Header("Player Level")]
    [SerializeField] private int maxExp;
    [SerializeField] private float updatedExp;

    public Text leveltext;
    public Image Expbar;

    [SerializeField] private GameObject confetti;
    [SerializeField] private GameObject lvlsplash;

    [SerializeField] private int expIncrease;
    [SerializeField] private int playerLevel;

    [Header("Player Publicity")]

    public Text publicity;
    public Text publicityStanding;
    [SerializeField] private int maxPub;
    [SerializeField] private int addpub;
    [SerializeField] private int playerpublicity;

    [Header("Player Reputation")]
    [SerializeField] private Text reputationtxt;


    [Header("Level SFX")]
    public AudioClip lvlSFX;
    private AudioSource lvlsfxSource { get { return GetComponent<AudioSource>(); } }
    public Transform[] LevelMarkers;

    [Header("Gold Coins")]
    [SerializeField] private float money;
    [SerializeField] Text moneyText; //"Money Text"
    [SerializeField] private float earnedM;
    [SerializeField] private float spentM;

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

    public Vector3 LocationOfSpawn = new Vector3(-7.98f, 0f, -72f);
    public static GameManager instance = null;

    public List<GameObject> Clasesbogth = new List<GameObject>();
    public List<GameObject> Chilingspot = new List<GameObject>();
    public List<GameObject> Bathroomrooms = new List<GameObject>();
    public List<GameObject> MagicClass = new List<GameObject>();
    public List<GameObject> SurfingClass = new List<GameObject>();
    public List<GameObject> HakingClass = new List<GameObject>();
    public List<GameObject> AxeTrowingClass = new List<GameObject>();
    public int NumberOfMagic = 0;
    public int NumberOfSurfing = 0;
    public int NumberOfHacking = 0;
    public int NumberOfAxeTrowing = 0;


    public string[] AvalableClases = new string[] { "Magic", "Surfing", "Hacking", "AxeTrowing" };

    public List<GameObject> HiredTeachers;

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
    public int Playerpublicity { get => playerpublicity; set => playerpublicity = value; }
    public int MaxPub { get => maxPub; set => maxPub = value; }
    public int Addpub { get => addpub; set => addpub = value; }
    public float EarnedM { get => earnedM; set => earnedM = value; }
    public float SpentM { get => spentM; set => spentM = value; }

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


    // Publicity SYSTEM 
    public void playerBeginPublicity()
    {
        
        Playerpublicity = 50;

    }

    public void addPub(int Addpub)
    {
        Playerpublicity += Addpub;
    }

    public GameObject Reschudule(string clas)
    {
        GameObject tempo = null;
        if (clas == "Magic")
        {
           for(int i = 0; i < MagicClass.Count; i++)
            {
                if (MagicClass[i].GetComponent<ClasroomScip>().IsthereSpace())
                {
                    tempo=MagicClass[i].GetComponent<ClasroomScip>().AvalableSit();
                    
                }
            }
            return tempo;
        }
        else if (clas == "Hacking")
        {
            for (int i = 0; i < HakingClass.Count; i++)
            {
                if (HakingClass[i].GetComponent<ClasroomScip>().IsthereSpace())
                {
                    tempo = HakingClass[i].GetComponent<ClasroomScip>().AvalableSit();
                   
                }
                
            }
            return tempo;
        }
        else if (clas == "AxeTrowing")
        {
            for (int i = 0; i < AxeTrowingClass.Count; i++)
            {
                if (AxeTrowingClass[i].GetComponent<ClasroomScip>().IsthereSpace())
                {
                    tempo = AxeTrowingClass[i].GetComponent<ClasroomScip>().AvalableSit();
                    
                }
                
            }
            return tempo;

        }
        else if (clas == "Surfing")
        {
            for (int i = 0; i < SurfingClass.Count; i++)
            {
                if (SurfingClass[i].GetComponent<ClasroomScip>().IsthereSpace())
                {
                    tempo = SurfingClass[i].GetComponent<ClasroomScip>().AvalableSit();
                    
                }
                
            }
            return tempo;
        }
        else
        {
            return null;
        }
        
    }

    public void ClasesNumber(GameObject clasroom)
    {

        

        
            if (clasroom.tag == "Magic")
            {
                NumberOfMagic++;
                MagicClass.Add(clasroom);
            }
            else if (clasroom.tag == "Haking")
            {
                NumberOfHacking++;
                HakingClass.Add(clasroom);
            }
            else if (clasroom.tag == "AxeTrowing")
            {
                NumberOfAxeTrowing++;
                AxeTrowingClass.Add(clasroom);
                
            }
            else if (clasroom.tag == "Surfing")
            {
                NumberOfSurfing++;
                SurfingClass.Add(clasroom);
            }
    //public List<GameObject> MagicClass = new List<GameObject>();
    //public List<GameObject> SurfingClass = new List<GameObject>();
    //public List<GameObject> HakingClass = new List<GameObject>();
    //public List<GameObject> AxeTrowingClass = new List<GameObject>();

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
        rep = Reputation.instance;

        StudentCountText = GameObject.FindGameObjectWithTag("StudentCount").GetComponent<Text>();
        classRCountText = GameObject.FindGameObjectWithTag("ClassCount").GetComponent<Text>();
        TeacherCountTXT = GameObject.FindGameObjectWithTag("TeacherCount").GetComponent<Text>();

        playerBeginLvl();
        playerBeginPublicity();



    }



    void Update()
    {

        UpdateMoneyUI();
        RefreshTextOnUI();
        classRTxtOnUI();
        //ClasesNumber();
        teacherTxtOnUI();
        updateNewlyHiredTSalary();
        updateCurrentTSalary();
        updateRecentTSalary();
        levelTxtOnUI();
        publictyUI();
        publictyStandingUI();
        updateReputationUI();
        //levelUp();

    }

    /// money
    public void AddMoney(float amount)
    {
        money += amount;
        earnedMoney(amount);
        playGoldSFX();
        UpdateMoneyUI();
    }

    public void ReduceMoney(float amount)
    {
        money -= amount;
        spendMoney(amount);
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

    public void earnedMoney(float amount)
    {
        EarnedM += amount;
    }

    public void spendMoney(float amount)
    {
        SpentM += amount;
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

    public void AddTeacher(GameObject Teacher)
    {
        TeacherCount++;
        HiredTeachers.Add(Teacher);
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
    

    public void updateReputationUI()
    {
        reputationtxt.text = "Reputation: " + rep.REP1.ToString();
    }
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

    public void publictyUI()
    {
        Playerpublicity = Mathf.Clamp(Playerpublicity, 1, 100);
        publicity.text = "Publicity: " + Playerpublicity;
    }

    public void publictyStandingUI()
    {
        Playerpublicity = Mathf.Clamp(Playerpublicity, 1, 100);

        if(Playerpublicity > 0 && Playerpublicity < 45)
        {
            publicityStanding.text = "Current Publicity Standing is BAD because you are in the rage of 0 and 45.";
        }
        else if (Playerpublicity >= 45 && Playerpublicity < 65)
        {
            publicityStanding.text = "Current Publicity Standing is OKAY because you are in the range of 45 and 65.";
        }
        else if (Playerpublicity >= 65)
        {
            publicityStanding.text = "Current Publicity Standing is GOOD because you are above 65.";
        }
        
    }


  
    public void SpawnCode()
    {
        Instantiate(Student[Random.Range(0,1)], LocationOfSpawn, Quaternion.identity);
        //Instantiate(Student, LocationOfSpawn, Quaternion.identity);

    }

    public Administration[] managementlines;
    public List<GameObject> Allregisteredstudents;

    //public void Gopay()
    //{
    //    managementlines[0].studentstopay = new List<GameObject>();
    //    managementlines[1].studentstopay = new List<GameObject>();
    //    managementlines[2].studentstopay = new List<GameObject>();
    //    managementlines[3].studentstopay = new List<GameObject>();
    //    foreach (GameObject student in Allregisteredstudents) {
    //        if (student.GetComponent<StudentMono>().Paid == false)
    //        {
    //            NavMeshAgent agent;
    //            agent = student.GetComponent<NavMeshAgent>();
    //            int temp=0;
    //            for (int i = 0; i < managementlines.Length; i++)
    //            {
    //                int f = 1;

    //                if (managementlines[i].Isthereasecretary && managementlines[i].studentstopay.Count <= managementlines[f].studentstopay.Count)
    //                {
    //                    temp = i;
    //                }

    //            }

    //            managementlines[temp].studentstopay.Add(student);
    //        }

    //    }
    //    StartCoroutine( managementlines[0].Payfees());
    //    managementlines[0].organiseline();
    //    StartCoroutine( managementlines[1].Payfees());
    //    managementlines[1].organiseline();
    //    StartCoroutine( managementlines[2].Payfees());
    //    managementlines[2].organiseline();
    //    StartCoroutine( managementlines[3].Payfees());
    //    managementlines[3].organiseline();

    //}
}
