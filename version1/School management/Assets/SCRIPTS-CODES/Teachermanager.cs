using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Teachermanager : MonoBehaviour
{
   public static Teachermanager instance = null;

    #region instance
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

    [Header("Teacher position")]
    [SerializeField] private Vector3 tPossitionOfcet;

    [Header("Randomize Number")]
    [SerializeField] public int[] randomNum;

    [Header("Teacher Skill's rarity")]
    [SerializeField] public string[] skills;
    
    [Header("Teacher prefabs")]
    [SerializeField] public GameObject[] teacherPrefabs;

    [Header("Teacher Name")]
    [SerializeField] public Text[] Teachernames;

    [Header("Teacher Pictures")]
    [SerializeField] public Sprite[] teacherPortrait;

    [Header("Teacher Icons")]
    [SerializeField] public Image[] teacherIcons;

    [Header("Teacher Skill's Rarity Text")]
    [SerializeField] public Text[] teachertraitstxt;

    [Header("Teacher Skill's Salary text")]
    [SerializeField] public Text[] salaryTxt;

    [Header("Teacher Skill's Salary")]
    [SerializeField] public string[] salary;

    [Header("Teacher Skill's Hire text")]
    [SerializeField] public Text[] hireCostTxt;

    [Header("Teacher Skill's Hiring Cost")]
    [SerializeField] public string[] hiringCost;

    private GameObject TeacherTohire;

    TeacherMono teachermono;



    public void teacherNames()
    {
        teacherPrefabs[0].name = "Vlad the Viking";         //Common
        teacherPrefabs[1].name = "Goe the Goblin";          //Common
        teacherPrefabs[2].name = "Wendy the Witch";         //Rare
        teacherPrefabs[3].name = "Percy the Pirate";        //Legendary       
        teacherPrefabs[4].name = "Gill the Goblin";         //Rare
        teacherPrefabs[5].name = "Will the Wizard";         //Common
        teacherPrefabs[6].name = "Vicky the Viking";        //Rare
    }

   

    public void RandomGenNum()
    {
        randomNum[0] = Random.Range(0, teacherPrefabs.Length);
        randomNum[1] = Random.Range(0, teacherPrefabs.Length);
        randomNum[2] = Random.Range(0, teacherPrefabs.Length);
       //randomNum[3] = Random.Range(0, teacherPrefabs.Length);
      
    }


    //dont touch These two functions!
    public void teacherAvatar()
    {
        teacherIcons[0].sprite = teacherPortrait[randomNum[0]];
        teacherIcons[1].sprite = teacherPortrait[randomNum[1]];
        teacherIcons[2].sprite = teacherPortrait[randomNum[2]];
        //teacherIcons[3].sprite = teacherPortrait[randomNum[3]];
        
    }


    public void teacherUInames()
    {
        Teachernames[0].text = teacherPrefabs[randomNum[0]].ToString();
        Teachernames[1].text = teacherPrefabs[randomNum[1]].ToString();
        Teachernames[2].text = teacherPrefabs[randomNum[2]].ToString();
        //Teachernames[3].text = teacherPrefabs[randomNum[3]].ToString();

    }

    public void teacherUItraits()
    {

        teachertraitstxt[0].text =  skills[randomNum[0]];
        teachertraitstxt[1].text =  skills[randomNum[1]];
        teachertraitstxt[2].text =  skills[randomNum[2]];
        //teachertraitstxt[3].text = "Rarity: " + skills[randomNum[3]];


    }

    public void teacherSalaryUI()
    {
        salaryTxt[0].text = "Salary/Day: $" + salary[randomNum[0]];
        salaryTxt[1].text = "Salary/Day: $" + salary[randomNum[1]];
        salaryTxt[2].text = "Salary/Day: $" + salary[randomNum[2]];
    }

    public void teacherHireCostUI()
    {
        hireCostTxt[0].text = "Hire for $" + hiringCost[randomNum[0]];
        hireCostTxt[1].text = "Hire for $" + hiringCost[randomNum[1]];
        hireCostTxt[2].text = "Hire for $" + hiringCost[randomNum[2]];
    }

    
    public void HireTeacherOne()
    {
        Instantiate(teacherPrefabs[randomNum[0]], tPossitionOfcet, Quaternion.identity);
        
    }

    public void HireTeacherTwo()
    {
        Instantiate(teacherPrefabs[randomNum[1]], tPossitionOfcet, Quaternion.identity);
    }

    public void HireTeacherThree()
    {
        Instantiate(teacherPrefabs[randomNum[2]], tPossitionOfcet, Quaternion.identity);
    }

    //public void HireTeacherFour()
    //{
    //    Instantiate(teacherPrefabs[randomNum[3]], tPossitionOfcet, Quaternion.identity);
    //}

    public GameObject GetTeacherTohire()
    {
        return TeacherTohire;
    }

    public void SetTeacher(GameObject Staff)
    {
        TeacherTohire = Staff;
    }



   public void GenerateRanNum()
    {
        RandomGenNum();
    }

    
    void Start()
    {
        //teacherNames(); //Teacher's name

        RandomGenNum(); //Generate Number (this applies to all the UI name and Avatar that goes along with it)

        //teacherUInames(); //Name of Teacher based off Random Gen Num

        //teacherAvatar(); //Teacher Portrait matches the Name!
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("R"))
        {
            RandomGenNum();
        }

        
        teacherNames();
        teacherUInames();
        teacherAvatar();
        teacherUItraits();
        teacherSalaryUI();
        teacherHireCostUI();
    }
}
