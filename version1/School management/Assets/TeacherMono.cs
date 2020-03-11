using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TeacherMono : MonoBehaviour
{
   

    private GameManager manager;
    public Teacher teacherinfo;
    private TeacherFactory tfactory;
    

    // Start is called before the first frame update


    // Update is called once per frame


   

    
    void Start()
    {
        manager = GameManager.instance;
        tfactory = TeacherFactory.instance;
        teacherinfo = tfactory.CreateTeacher();
    }

    void Update()
    {

    }
}
