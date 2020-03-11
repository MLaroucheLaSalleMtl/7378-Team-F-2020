using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiring : MonoBehaviour
{
    public GameManager gameManager;

    public Teachermanager teachermanager;

    public GameObject HiringMenu;

    public static bool HiringMenuUI = false;

    

    public void OnhireTeacherOne()
    {
        teachermanager.HireTeacherOne();
        HiringMenu.SetActive(false);
    }

    public void OnhireTeacherTwo()
    {
        teachermanager.HireTeacherTwo();
        HiringMenu.SetActive(false);
    }

    public void OnhireTeacherThree()
    {
        teachermanager.HireTeacherThree();
        HiringMenu.SetActive(false);
    }

    public void OnhireTeacherFour()
    {
        teachermanager.HireTeacherFour();
        HiringMenu.SetActive(false);
    }


    //menu panel
    



    public void EnterHiringMenu()
    {
       
        HiringMenu.SetActive(true);
        HiringMenuUI = true;

    }
    public void ExitHiringMenu()
    {
        
        HiringMenu.SetActive(false);
        HiringMenuUI = false;
    }


    public void DoHireMenu()
    {
        if (HiringMenuUI)
        {
            ExitHiringMenu();
            Debug.Log("hire menu OFF");
        }
        else
        {
            EnterHiringMenu();
            Debug.Log("hire menu ON");
            
        }
    }


    void Start()
    {
        teachermanager = Teachermanager.instance;
        gameManager = GameManager.instance;

        
    }

    void Update()
    {
        
    }

}
