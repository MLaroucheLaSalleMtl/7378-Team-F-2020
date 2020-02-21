using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCube : MonoBehaviour
{
    public Color hovercolor;
    private Renderer rend;
    private Color Defaaultcollor;
    private GameObject classroom;
    private GameObject Classselected;
    

    [SerializeField] private Vector3 PossitionOfcet;

    //Teacher position , inside the class room
    [SerializeField] private GameObject teacher;
    [SerializeField] private Vector3 teacherPosition;


    void Start()
    {
        rend = GetComponent<Renderer>();
        Defaaultcollor = rend.material.color;
    }


    private void OnMouseDown()
    {
        //display ui to pick
        GameObject ClassToBuild = Buildingmanager.instance.GetClassToBuild();
        classroom = (GameObject)Instantiate(ClassToBuild,transform.position+PossitionOfcet,transform.rotation);

        //teacher shows up , for the demo i dont think we will have enough time to "hire" the teacher yet lol
        Instantiate(teacher, teacherPosition, Quaternion.identity);

        //deactivate vbuy option
        //minus the money
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
