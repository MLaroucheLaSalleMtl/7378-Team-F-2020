using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCube : MonoBehaviour
{
     GameManager gameManager;

    //cost of the class
    //[SerializeField] private float amount;

    public Color hovercolor;
    private Renderer rend;
    private Color Defaaultcollor;
    private GameObject classroom;
    private GameObject Classselected;

    Buildingmanager buildManager;
    Buying buying;

    [SerializeField] private Vector3 PossitionOfcet;

    //Teacher position , inside the class room
    [SerializeField] private GameObject teacher;
    [SerializeField] private Vector3 teacherPosition;


    void Start()
    {
        rend = GetComponent<Renderer>();
        Defaaultcollor = rend.material.color;
        buildManager=Buildingmanager.instance;
        gameManager = GameManager.instance;
    }


    private void OnMouseDown()
    {if (buildManager.GetClassToBuild() == null)
            return;
        if (gameManager.Money < buildManager.GetClassToBuild().GetComponent<ClasroomScip>().ClassCost)
        {
            Debug.Log("Not Enogth Money");
            return;
        }



        GameObject ClassToBuild = buildManager.GetClassToBuild();
        
        gameManager.ReduceMoney(ClassToBuild.GetComponent<ClasroomScip>().ClassCost);
        // displays how many classes built
        GameManager.instance.AddClasses(); 

        //display ui to pick
       
        classroom = Instantiate(ClassToBuild,transform.position+PossitionOfcet,transform.rotation);
        gameManager.Clasesbogth.Add(classroom);
        if (teacher != null)
        {
            //teacher shows up 
            Instantiate(teacher, teacherPosition, Quaternion.identity);
        }
        buildManager.SetClass(null);
        //deactivate vbuy option


        //minus the money 
        

        Destroy(gameObject);

    }
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        
            if (buildManager.GetClassToBuild() == null)
                return;
            rend.material.color = hovercolor;
    }
    private void OnMouseExit()
    {
        rend.material.color = Defaaultcollor;
    }
}
