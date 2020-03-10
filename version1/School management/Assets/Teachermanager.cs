using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teachermanager : MonoBehaviour
{
   public static Teachermanager instance = null;


    [System.Serializable]
    public struct Teacher
    {
        [SerializeField] private string teacherName;
        [SerializeField] public Sprite avatar;
        [SerializeField] private GameObject[] teachers;

        public string TeacherName { get { return TeacherName; } }
        public GameObject[] Teachers { get { return Teachers; } }
    }

    [Header("Teacher Name, Avatar & Prefab")]
    [SerializeField]
    public Teacher[] _teachers;

    List<string> teacherName;

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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void HireTeacher()
    {
        Instantiate(_teachers[4].Teachers[Random.Range(0, 6)], tPossitionOfcet, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
