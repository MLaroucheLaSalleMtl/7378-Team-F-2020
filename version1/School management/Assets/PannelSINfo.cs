using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PannelSINfo : MonoBehaviour
{
    public GameObject student;
    private PlayerLog eventLog;
    private GameManager manager;
    private void Start()
    {
        eventLog= PlayerLog.instance;
        manager = GameManager.instance;
    }
    void Update()
    {
        
    }
    public void FindStudent()
    {
        StudentShow.instance.closePanel();

        if (student.layer == 8)
        {
            FloorUI.instance.indexer=0;
            floorsystem.instance.cameralevels[0].transform.position = student.transform.position += new Vector3(0, 3, 0);
        }else if (student.layer == 9)
        {
            FloorUI.instance.indexer=1;
            floorsystem.instance.cameralevels[1].transform.position = student.transform.position += new Vector3(0, 3, 0);
        }
        else if (student.layer == 10)
        {
            FloorUI.instance.indexer=2;
            floorsystem.instance.cameralevels[2].transform.position = student.transform.position += new Vector3(0, 3, 0);
        }


    }

    public void ChangeClass()
    {
        GameObject temporary;

        if(student.GetComponent<StudentMono>().stdudentinfo.ClassIwant1!= student.GetComponent<StudentMono>().stdudentinfo.ClassIgot1)
        {
            temporary = manager.Reschudule(student.GetComponent<StudentMono>().stdudentinfo.ClassIwant1);
            if (temporary == null)
            {
                eventLog.AddEvent("No Space on Desired Class!");
            }
            else
            {
                student.GetComponent<StudentMono>().stdudentinfo.ClassIgot1 = student.GetComponent<StudentMono>().stdudentinfo.ClassIwant1;
                student.GetComponent<StudentMono>().ClassSit.GetComponent<SitUsed>().Ocupied = false;
                student.GetComponent<StudentMono>().ClassSit = temporary;
                eventLog.AddEvent("Class Successfully Changed!");
            }
          
            
        }
        else
        {
            eventLog.AddEvent("Student already on Desired Class!");
        }
    }
}
