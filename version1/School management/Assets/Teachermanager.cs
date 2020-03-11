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
    [System.Serializable]
    public class teacherInfo
    {
        public string teacherName;
    }
    [Header("Teacher Information")]
    [SerializeField] public teacherInfo[] info;

    public Text displayTeacherName;

    //private string[] teachertypes = { "Viking", "Goblin", "Witch", "Pirate" };
    [Header("Teacher prefabs")]
    [SerializeField] public GameObject[] teacherPrefabs;
    
    void Start()
    {
       // teacherPrefabs[0].name = info[0];
        teacherPrefabs[0].name = "Bob the Viking";
        teacherPrefabs[1].name = "Joe the Goblin";
        teacherPrefabs[2].name = "Stacy the Witch";
        teacherPrefabs[3].name = "Umi the Pirate";
    }

    public void HireTeacher()
    {
        Debug.Log(Instantiate(teacherPrefabs[Random.Range(0, teacherPrefabs.Length)], tPossitionOfcet, Quaternion.identity));
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
