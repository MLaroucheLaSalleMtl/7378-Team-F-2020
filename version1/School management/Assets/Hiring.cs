using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiring : MonoBehaviour
{

    public GameObject HiringMenu;

   
    void Start()
    {
       
    }

    public void oneStarTeacher()
    {
        HiringMenu.SetActive(false);
    }

    public void twoStarTeacher()
    {
        HiringMenu.SetActive(false);
    }

    public void treeStarTeacher()
    {
        HiringMenu.SetActive(false);
    }

    public void DisplayHiringMenu()
    {
        HiringMenu.SetActive(true);
    }

    public void ExitHiringMenu()
    {
        HiringMenu.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

}
