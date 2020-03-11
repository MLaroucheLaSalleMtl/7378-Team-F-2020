using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiring : MonoBehaviour
{
    public GameManager gameManager;

    public Teachermanager teachermanager;

    public GameObject HiringMenu;

    void Start()
    {
        teachermanager = Teachermanager.instance;
        gameManager = GameManager.instance;
    }

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
    }
    public void ExitHiringMenu()
    {
        HiringMenu.SetActive(false);
    }


    
    void Update()
    {
        
    }

}
