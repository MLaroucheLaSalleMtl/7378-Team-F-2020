//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TeacherMono : MonoBehaviour
{
    public static TeacherMono instance = null;

    GameManager gamemanager;

    TeacherFactory tfactory;

    public Teacher teacherinfo;

    public int HiringCost; // initaial payment

    public int salary; // each teacher's salary that will be paid at the end of the day

    //public int totalSalary;

    //public Text totalSalarytxt; //total sum of salary

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            //Destroy(gameObject);
        }
    }

    // Start is called before the first frame update


    // Update is called once per frame







    void Start()
    {
        gamemanager = GameManager.instance;


        //tfactory = TeacherFactory.instance;
        //teacherinfo = tfactory.CreateTeacher();

        //Debug.Log("1st trait: " + teacherinfo.traits1 + "2nd trait: " + teacherinfo.traits12 + "3rd trait: " + teacherinfo.traits13 );

    }

    void Update()
    {
        
        //totalSalarytxt.text = TeacherMono.instance.totalSalary.ToString();
        //updateSalaryUI();
    }

}
