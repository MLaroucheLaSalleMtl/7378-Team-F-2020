using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HireCube : MonoBehaviour
{

    private GameManager gameManager;

    private GameObject tStaff;

    private tasks Tasks;

    Teachermanager teacherManager;

    private bool okayToHire = false;


    [Header("Teacher's Spawn point")]
    [SerializeField] private Vector3 teacherPosition;

    [Header("Teacher is facing towards the classroom")]
    [SerializeField] private Vector3 RotationOfcet;

    [Header("Tooltip when Hovered over cube")]
    [SerializeField] private GameObject tooltip;

    [Header("Sparkles/Glow objective indicator")]
    [SerializeField] public GameObject SparklesForTeacher;

    


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        teacherManager = Teachermanager.instance;
        Tasks = tasks.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {

        if (teacherManager.GetTeacherTohire() == null)
        {
            Debug.Log("Hire a Teacher!");
            return;
        }



        if (gameManager.Money < teacherManager.GetTeacherTohire().GetComponent<TeacherMono>().Salary)
        {
            Debug.Log("Not enough money to hire this teacher!");
            return;
        }

        if (gameManager.ClassRCount >= 1)
        {
            okayToHire = true;

            gameManager.AddTeacher();


            // TO DO: fix later
            //gameManager.ReduceClasses();


            GameObject TeacherTohire = teacherManager.GetTeacherTohire();
            tStaff = Instantiate(TeacherTohire, teacherPosition, transform.rotation * Quaternion.Euler(RotationOfcet));

            //How much the teacher cost to hire 
            gameManager.ReduceMoney(TeacherTohire.GetComponent<TeacherMono>().Salary);


            //Player can choose other teachers, wont duplicate to previously selected one
            teacherManager.SetTeacher(null);
        }



        Tasks.SparklesForObj[1].SetActive(false);
        Destroy(gameObject);
        tooltip.SetActive(false);

    }


    private void OnMouseEnter()
    {
        if (teacherManager.GetTeacherTohire() == null)
        {

            tooltip.SetActive(true);

        }
        else
        {
            tooltip.SetActive(false);
        }
    }

    private void OnMouseExit()
    {
        tooltip.SetActive(false);
    }
}
