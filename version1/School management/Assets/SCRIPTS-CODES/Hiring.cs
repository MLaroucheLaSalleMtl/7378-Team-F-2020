using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiring : MonoBehaviour
{
    private GameManager gameManager;

    private Teachermanager teachermanager;

    public GameObject HiringMenu;

    public static bool HiringMenuUI = false;

    [Header("Unlock pannels in the hiring menu")]
    [SerializeField] public GameObject[] unlockPannels;


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
    /// Teacher unlock Panel
    public void unlockPannel200()
    {
        if (gameManager.Money < 200)
        {
            Debug.Log("Not enough Gold to unlock this pannel");
            return;
        }
        else
        {
            gameManager.ReduceMoney(200);
            Destroy(unlockPannels[0]);
        }
    }

    
    public void unlockPannel400()
    {
        if (gameManager.Money < 400)
        {
            Debug.Log("Not enough Gold to unlock this pannel");
            return;
        }
        else
        {
            gameManager.ReduceMoney(400);
            Destroy(unlockPannels[1]);
        }
    }


    //Admin unlock Panel
    public void unlockAdminPannel100()
    {
        if (gameManager.Money < 100)
        {
            Debug.Log("Not enough Gold to unlock this pannel");
            return;
        }
        else
        {
            gameManager.ReduceMoney(100);
            Destroy(unlockPannels[2]);
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
