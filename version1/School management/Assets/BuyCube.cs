using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCube : MonoBehaviour
{
    public static GameManager gameManager;



    [Header("Amount Deducted")]
    [SerializeField] private float amount;

    public Color hovercolor;
    private Renderer rend;
    private Color Defaaultcollor;
    private GameObject classroom;
    private GameObject Classselected;

    [Header("Player must have this much gold to purchase")]
    [SerializeField] private int classPrice;

    [SerializeField] private Vector3 PossitionOfcet;

    [Header("Teacher Model & Position")]
    [SerializeField] private GameObject teacher;
    [SerializeField] private Vector3 teacherPosition;

    [Header("Warning Panels")]
    [SerializeField] private GameObject[] Panels;
    [SerializeField] private GameObject[] BTNS;


    void Start()
    {

        rend = GetComponent<Renderer>();
        Defaaultcollor = rend.material.color;

        
    }

  

    private void OnMouseDown()
    {
        if (GameManager.gameManager.Money >= classPrice) //I put a barrier of 200 for now
        {
            // displays how many classes built
            GameManager.instance.AddClasses();

            //display ui to pick
            GameObject ClassToBuild = Buildingmanager.instance.GetClassToBuild();
            classroom = (GameObject)Instantiate(ClassToBuild, transform.position + PossitionOfcet, transform.rotation);

            //teacher shows up 
            Instantiate(teacher, teacherPosition, Quaternion.identity);

            //deactivate vbuy option
            Destroy(gameObject);

            //minus the money 
            GameManager.gameManager.ReduceMoney(amount);

        }

        else
        {

            GameManager.gameManager.RequestMoney(amount);

        }
    }
    void Update()
    {
        
    }

   
    private void OnMouseEnter()
    {
        rend.material.color = hovercolor;
    }
    private void OnMouseExit()
    {
        rend.material.color = Defaaultcollor;
    }
}
