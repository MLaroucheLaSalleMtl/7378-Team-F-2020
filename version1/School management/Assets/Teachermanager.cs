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

    //private string[] teachertypes = { "Viking", "Goblin", "Witch", "Pirate" };
    [Header("Teacher prefabs")]
    [SerializeField] public GameObject[] teacherPrefabs;

    [Header("Teacher Name")]
    public Text[] Teachernames;
    
    


    void Start()
    {
      
        teacherPrefabs[0].name = "Bob the Viking";
        teacherPrefabs[1].name = "Joe the Goblin";
        teacherPrefabs[2].name = "Stacy the Witch";
        teacherPrefabs[3].name = "Barb the Pirate";


       randomNum[0] = Random.Range(0, teacherPrefabs.Length);
       randomNum[1] = Random.Range(0, teacherPrefabs.Length);
       randomNum[2] = Random.Range(0, teacherPrefabs.Length);
       randomNum[3] = Random.Range(0, teacherPrefabs.Length);

        Teachernames[0].text = "Name: " + teacherPrefabs[randomNum[0]].ToString();
        Teachernames[1].text = "Name: " + teacherPrefabs[randomNum[1]].ToString();
        Teachernames[2].text = "Name: " + teacherPrefabs[randomNum[2]].ToString();
        Teachernames[3].text = "Name: " + teacherPrefabs[randomNum[3]].ToString();

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



    // Update is called once per frame
    void Update()
    {
        
    }
}
