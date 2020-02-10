﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.IO;




public class GameManager : MonoBehaviour
{


    private int StudentCount;
    Text StudentCountText;//"StudentCount"
    Vector3 LocationOfSpawn=new Vector3(6,1,2);
    public static GameManager instance = null;

    string[] Clasesbogth;

    //Percy wtf is Haking? 
    string[] AvalableClases= {"Magic","Surfing","Haking","Axe Trowing"};

    

    List<string> Clases;

    [Header("Student Prefab Toinstanciate")]
    [SerializeField]private GameObject Student;


  

    

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

    void Start()
    {
        StudentCountText =GameObject.FindGameObjectWithTag("StudentCount").GetComponent<Text>();

        
    }

    
    void Update()
    {
        RefreshTextOnUI();


    }

    public void AddStudent( )
    {
        StudentCount++;

    }

    public void RefreshTextOnUI()
    {
        StudentCountText.text = "Students: "+StudentCount;
    }

    public void Spawn(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Instantiate(Student, LocationOfSpawn, Quaternion.identity);
        }
    }
}
