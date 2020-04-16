using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PannelSINfo : MonoBehaviour
{
    public GameObject student;
    
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
}
