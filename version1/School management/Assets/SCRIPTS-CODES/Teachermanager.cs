using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teachermanager : MonoBehaviour
{
   public static Teachermanager instance = null;



    //[System.Serializable]
    //public struct Teacher
    //{
    //    [SerializeField] private string teacherName;
    //    [SerializeField] public Sprite avatar;
    //    [SerializeField] private GameObject[] teachers;

    //    public string TeacherName { get { return TeacherName; } }
    //    public GameObject[] Teachers { get { return Teachers; } }
    //}

    //[Header("Teacher Name, Avatar & Prefab")]
    //[SerializeField]
    //public Teacher[] _teachers;

    //List<string> teacherName;

    [Header("Teacher position")]
    [SerializeField] private Vector3 tPossitionOfcet;

    [Header("Randomize Number")]
    [SerializeField] public int[] randomNum;

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

    
    [Header("Teacher prefabs")]
    [SerializeField] public GameObject[] teacherPrefabs;

    [Header("Teacher Name")]
    [SerializeField] public Text[] Teachernames;

    [Header("Teacher Pictures")]
    [SerializeField] public Sprite[] teacherPortrait;

    [Header("Teacher Icons")]
    [SerializeField] public Image[] teacherIcons;

    private GameObject TeacherTohire;


    public void teacherNames()
    {
        teacherPrefabs[0].name = "Bob the Viking";
        teacherPrefabs[1].name = "Joe the Goblin";
        teacherPrefabs[2].name = "Stacy the Witch";
        teacherPrefabs[3].name = "Percy the Pirate";
        teacherPrefabs[4].name = "Jill the Goblin";
        teacherPrefabs[5].name = "Sam the Wizard";
        teacherPrefabs[6].name = "Jesse the Viking";
    }

   

    public void RandomGenNum()
    {
        randomNum[0] = Random.Range(0, teacherPrefabs.Length);
        randomNum[1] = Random.Range(0, teacherPrefabs.Length);
        randomNum[2] = Random.Range(0, teacherPrefabs.Length);
        randomNum[3] = Random.Range(0, teacherPrefabs.Length);
      
    }


    //dont touch These two functions!
    public void teacherAvatar()
    {
        teacherIcons[0].sprite = teacherPortrait[randomNum[0]];
        teacherIcons[1].sprite = teacherPortrait[randomNum[1]];
        teacherIcons[2].sprite = teacherPortrait[randomNum[2]];
        teacherIcons[3].sprite = teacherPortrait[randomNum[3]];
        
    }

    
    public void teacherUInames()
    {
        Teachernames[0].text = teacherPrefabs[randomNum[0]].ToString();
        Teachernames[1].text = teacherPrefabs[randomNum[1]].ToString();
        Teachernames[2].text = teacherPrefabs[randomNum[2]].ToString();
        Teachernames[3].text = teacherPrefabs[randomNum[3]].ToString();

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

    public void HireTeacherFour()
    {
        Instantiate(teacherPrefabs[randomNum[3]], tPossitionOfcet, Quaternion.identity);
    }

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
    }
}
