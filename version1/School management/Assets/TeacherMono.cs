//using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TeacherMono : MonoBehaviour
{
   

    private GameManager manager;
   
    public TeacherFactory tfactory;

    public Teacher teacherinfo;

    // Start is called before the first frame update


    // Update is called once per frame



    void Start()
    {
        //manager = GameManager.instance;
        //tfactory = TeacherFactory.instance;
        //teacherinfo = tfactory.CreateTeacher();

        Debug.Log("1st trait: " + teacherinfo.traits1 + "2nd trait: " + teacherinfo.traits12 + "3rd trait: " + teacherinfo.traits13 );

    }

    void Update()
    {

    }
}
