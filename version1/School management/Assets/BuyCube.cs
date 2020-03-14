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
    
    Buying buying;

    [SerializeField] private Vector3 PossitionOfcet;
    [SerializeField] private GameObject tooltip;

    //GostyStuff

    private GameObject clone;
    //...

    //Teacher position , inside the class room
    [SerializeField] private Vector3 teacherPosition;


    void Start()
    {
        rend = GetComponent<Renderer>();
        Defaaultcollor = rend.material.color;
        gameManager = GameManager.instance;
        buildManager =Buildingmanager.instance;
        teacherManager = Teachermanager.instance;
    }


    private void OnMouseDown()
    {
        if (buildManager.GetClassToBuild() == null)
        {
            Debug.Log("Buy a classroom!");
            return;
        }



        //if (gameManager.Money < buildManager.GetClassToBuild().GetComponent<ClasroomScip>().ClassCost)
        //{
        //    Debug.Log("Not Enough Money");
        //    return;
        //}



        GameObject ClassToBuild = buildManager.GetClassToBuild();
        

        gameManager.ReduceMoney(ClassToBuild.GetComponent<ClasroomScip>().ClassCost);

        // displays how many classes built
        GameManager.instance.AddClasses();

        //display ui to pick
        classroom = Instantiate(ClassToBuild, transform.position + PossitionOfcet, transform.rotation);
        gameManager.Clasesbogth.Add(classroom);

        
        // Destroy(clone);

        //HIRE TEACHER ---------- NEED TO BUY ATLEAST 1 CLASSROOM TO UNLOCK ---------------- 
        if (gameManager.ClassRCount >= 1)
        {
            if (gameManager.Money < teacherManager.GetTeacherTohire().GetComponent<TeacherMono>().Salary)
            {
                

                /// FALSE
                Debug.Log("Not enough money to hire this teacher!");
                return;
            }
            else
            {
                okayToHire = true;

                GameManager.instance.AddTeacher();

                //ez fix or else it will say there are two classrooms lmao 
                // TO DO: fix later

                GameManager.instance.ReduceClasses();
                /// TRUE
                GameObject TeacherTohire = teacherManager.GetTeacherTohire();
                tStaff = Instantiate(TeacherTohire, teacherPosition, transform.rotation);

                //How much the teacher cost to hire 
                gameManager.ReduceMoney(TeacherTohire.GetComponent<TeacherMono>().Salary);

                //Player can choose other teachers, wont duplicate to previously selected one
                teacherManager.SetTeacher(null);
            }
        }



        //game to know there is a classroom, important for hiring a teacher
        buildManager.SetClass(null);
        

        //Fuck the cube! :D
        Destroy(gameObject);



    }
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        tooltip.SetActive(true);

        if (buildManager.GetClassToBuild() == null)
        
            return;
        
            clone = buildManager.GetGostClass();
            clone = Instantiate(clone, transform.position + PossitionOfcet, transform.rotation);
            rend.material.color = hovercolor;
        
    }
    private void OnMouseExit()
    {
        tooltip.SetActive(false);
        rend.material.color = Defaaultcollor;
        Destroy(clone);
        Destroy(clone);
    }
}
