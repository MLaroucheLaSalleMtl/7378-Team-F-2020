//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TeacherMono : MonoBehaviour
{
    public static TeacherMono instance = null;

    GameManager gamemanager;

    Teachermanager teachermanager;

    Teacher teacherinfo;

    public string Name; // initaial payment

    [SerializeField]
    private int HiringCost; // initaial payment

    [SerializeField]
    private int salary; // each teacher's salary that will be paid at the end of the day

    public int Salary { get => salary; set => salary = value; }
    public int HiringCost1 { get => HiringCost; set => HiringCost = value; }

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

 


    void Start()
    {
        gamemanager = GameManager.instance;
        teachermanager = Teachermanager.instance;

    }

    void Update()
    {
        
      
    }

}
