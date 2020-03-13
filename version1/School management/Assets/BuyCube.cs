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

    //GostyStuff
    
    private GameObject clone;
    //...

    //Teacher position , inside the class room
    //[SerializeField] private GameObject teacher;
    [SerializeField] private Vector3 teacherPosition;


    void Start()
    {
        rend = GetComponent<Renderer>();
        Defaaultcollor = rend.material.color;
        buildManager=Buildingmanager.instance;
        gameManager = GameManager.instance;
        teacherManager = Teachermanager.instance;
    }


    private void OnMouseDown()
    {
        if (buildManager.GetClassToBuild() == null)
        {
            Debug.Log("Buy a classroom!");
            return;
        }
            


        if (gameManager.Money < buildManager.GetClassToBuild().GetComponent<ClasroomScip>().ClassCost)
        {
            Debug.Log("Not Enough Money");
            return;
        }



        GameObject ClassToBuild = buildManager.GetClassToBuild();
        //GameObject TeacherTohire = teacherManager.GetTeacherTohire();


        gameManager.ReduceMoney(ClassToBuild.GetComponent<ClasroomScip>().ClassCost);

        // displays how many classes built
        GameManager.instance.AddClasses();

        //display ui to pick
        
        classroom = Instantiate(ClassToBuild, transform.position + PossitionOfcet, transform.rotation);
        gameManager.Clasesbogth.Add(classroom);

        //if (teacher != null)
        //{
        //    //teacher shows up 

        //    Instantiate(teacher, teacherPosition, Quaternion.identity);
        //}
        Destroy(clone);

        // we could only hire a teacher if we have a classroom built 
        if (gameManager.ClassRCount > 0)
        {
            okayToHire = true;
            GameObject TeacherTohire = teacherManager.GetTeacherTohire();
            tStaff = Instantiate(TeacherTohire, teacherPosition, transform.rotation);

            //Player can choose other teachers
            teacherManager.SetTeacher(null);
        }
        else
        {
            okayToHire = false;
        }


        buildManager.SetClass(null);
        //deactivate vbuy option

        
        Destroy(clone);

        //Fuck the cube! :D
        Destroy(gameObject);



    }
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {

        if (buildManager.GetClassToBuild() == null)
        
            return;
        
            clone = buildManager.GetGostClass();
            clone = Instantiate(clone, transform.position + PossitionOfcet, transform.rotation);
            rend.material.color = hovercolor;
        
    }
    private void OnMouseExit()
    {
        rend.material.color = Defaaultcollor;
        Destroy(clone);
        Destroy(clone);
    }
}
