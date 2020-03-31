using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCube : MonoBehaviour
{


    private GameManager gameManager;

    //cost of the class
    //[SerializeField] private float amount;
    private bool okayToHire = false;

    public Color hovercolor;
    private Renderer rend;
    private Color Defaaultcollor;
    private GameObject classroom;
    private GameObject Classselected;
    private GameObject tStaff;

    Teachermanager teacherManager;

    Buildingmanager buildManager;

     tasks Tasks;

    PlayerLog eventLog;

    Buying buying;

    [Header("Classroom Offset")]
    [SerializeField] private Vector3 PossitionOfcet;

    [Header("Tooltip when Hovered over cube")]
    [SerializeField] private GameObject tooltip;

    [Header("Hire Cube activation")]
    [SerializeField] private GameObject HireCube;

    [Header("Preview of classroom/building")]
    private GameObject clone;

    [Header("Teacher's Spawn point")]
    [SerializeField] private Vector3 teacherPosition;

    [Header("Teacher is facing towards the classroom")]
    [SerializeField] private Vector3 RotationOfcet;


   

    void Start()
    {
        rend = GetComponent<Renderer>();
        Defaaultcollor = rend.material.color;
        gameManager = GameManager.instance;
        buildManager = Buildingmanager.instance;
        teacherManager = Teachermanager.instance;
        eventLog = PlayerLog.instance;
        Tasks = tasks.instance;

    }
    void Update()
    {
       
    }


    private void OnMouseDown()
    {
        if (buildManager.GetClassToBuild() == null)
        {
            eventLog.AddEvent("Buy a classroom!");
            Debug.Log("Buy a classroom!");
            return;
        }
        



        if (gameManager.Money < buildManager.GetClassToBuild().GetComponent<ClasroomScip>().ClassCost)
        {
            eventLog.AddEvent("Not Enough Money");
            Debug.Log("Not Enough Money");
            return;
        }



        GameObject ClassToBuild = buildManager.GetClassToBuild();
        

        gameManager.ReduceMoney(ClassToBuild.GetComponent<ClasroomScip>().ClassCost);

        // displays how many classes built
        gameManager.AddClasses();

        //display ui to pick
        classroom = Instantiate(ClassToBuild, transform.position + PossitionOfcet, transform.rotation);
        gameManager.Clasesbogth.Add(classroom);

        //game to know there is a classroom, important for hiring a teacher
        buildManager.SetClass(null);

        Destroy(clone);

        // Remove Objective Spark
        Tasks.SparklesForObj[0].SetActive(false);

        //Remove the Cube
        Destroy(gameObject);

        //bring out the teacher HireCube
        HireCube.SetActive(true);

        tooltip.SetActive(false);

    }
    
    private void OnMouseEnter()
    {
        

        if (buildManager.GetClassToBuild() == null)
        {
            tooltip.SetActive(true);
            
        }
       else
        {
            tooltip.SetActive(false);
        }
        
            clone = buildManager.GetGostClass();
            clone = Instantiate(clone, transform.position + PossitionOfcet, transform.rotation);
            rend.material.color = hovercolor;
        
    }
    private void OnMouseExit()
    {
        tooltip.SetActive(false);
        rend.material.color = Defaaultcollor;
        Destroy(clone);
        
    }
}
