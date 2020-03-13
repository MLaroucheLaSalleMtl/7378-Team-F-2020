using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiring : MonoBehaviour
{
    private GameManager gameManager;

    private Teachermanager teachermanager;

    public GameObject HiringMenu;

    public static bool HiringMenuUI = false;

    

    public void OnhireTeacherOne()
    {
        //teachermanager.HireTeacherOne();
        teachermanager.SetTeacher(teachermanager.teacherPrefabs[teachermanager.randomNum[0]]);
        HiringMenu.SetActive(false);
    }

    public void OnhireTeacherTwo()
    {
        //teachermanager.HireTeacherTwo();
        teachermanager.SetTeacher(teachermanager.teacherPrefabs[teachermanager.randomNum[1]]);
        HiringMenu.SetActive(false);
    }

    public void OnhireTeacherThree()
    {
        //teachermanager.HireTeacherThree();
        teachermanager.SetTeacher(teachermanager.teacherPrefabs[teachermanager.randomNum[2]]);
        HiringMenu.SetActive(false);
    }

    public void OnhireTeacherFour()
    {
        //teachermanager.HireTeacherFour();
        teachermanager.SetTeacher(teachermanager.teacherPrefabs[teachermanager.randomNum[3]]);
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
        if (gameManager.ClassRCount > 0)
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
