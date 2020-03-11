using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using System.Collections;




public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    

    [Header("Gold")]
    [SerializeField] private float money;
    [SerializeField] Text moneyText; //"Money Text"

    private int StudentCount;
    Text StudentCountText;//"StudentCount"

    private int classRCount;
    [SerializeField]private Text classRCountText;//"classRCount"

    public Vector3 LocationOfSpawn=new Vector3(-7.98f, 5.7f, -72f);
    public static GameManager instance = null;

    public List<GameObject> Clasesbogth=new List<GameObject>();
    public int NumberOfMagic=0; 
    public int NumberOfSurfing=0; 
    public int NumberOfHacking=0; 
    public int NumberOfAxeTrowing=0; 
    

    public string[] AvalableClases=new string[] {"Magic","Surfing","Hacking","Axe Trowing"};

    

    List<string> Clases=new List<string>();

    [Header("Male & Female Student Prefab Toinstanciate")]
    [SerializeField] private GameObject[] Student;

    private int StudentSpawn;



    //[Header("Female Student Prefab Toinstanciate")]
    //[SerializeField] private GameObject fStudent;

    //[Header("student prefab Pool")]
    //[SerializeField] private GameObject[] m_Pool;

    public int ClassRCount { get => classRCount; set => classRCount = value; }
    public float Money { get => money; set => money = value; }

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
        if (Clasesbogth.Count >= 0)
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
        //gameManager = this; //only one ---Why?????
        //UpdateMoneyUI();

        

        StudentCountText =GameObject.FindGameObjectWithTag("StudentCount").GetComponent<Text>();
        classRCountText  =GameObject.FindGameObjectWithTag("ClassCount").GetComponent<Text>();

    }



    void Update()
    {


        UpdateMoneyUI();
        RefreshTextOnUI();
        classRTxtOnUI();
        ClasesNumber();


    }

    /// money
    public void AddMoney(float amount)
    {
        money += amount;
        UpdateMoneyUI();
    }

    public void ReduceMoney(float amount)
    {
        money -= amount;
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
        StudentCount++;

    }

    public void AddClasses()
    {
        classRCount++;

    }

    public void UpdateMoneyUI()
    {
        moneyText.text = "$ " + money.ToString("N0");
    }

    public void RefreshTextOnUI()
    {
        StudentCountText.text = "Students: "+StudentCount;
    }

    public void classRTxtOnUI()
    {
        classRCountText.text = "Class Built: "+classRCount;
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
}
