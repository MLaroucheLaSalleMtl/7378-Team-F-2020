using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roadmap : MonoBehaviour
{

    //Pause & Exit Buttons
    public static bool roadmapActivation = false;

    public GameObject roadmapBTN;
    public GameObject roadmapIMG;

    public Text sideTaskTxt1;
    public Text sideTaskTxt2;
    public Text sideTaskTxt3;

    GameManager gamemanager;

    public void openRoadmap()
    {
        roadmapIMG.SetActive(true);
        roadmapActivation = true;
    }

    public void closeRoadmap()
    {
        roadmapIMG.SetActive(false);
        roadmapActivation = false;
    }

    public void DoRoadmap()
    {
        if (roadmapActivation)
        {
            closeRoadmap();
            Debug.Log("close roadmap");
        }
        else
        {
            openRoadmap();
            Debug.Log("open roadmap");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        Task1();
        Task2();
        Task3();
    }

    public void Task1()
    {
        if (gamemanager.NumberOfMagic == 1 && gamemanager.NumberOfSurfing == 1 && gamemanager.NumberOfHacking == 1 && gamemanager.NumberOfAxeTrowing == 1)
        {
            sideTaskTxt1.text = "Nice! You finished your first side task!";
        }
        //else if ()
        //{
        //    
        //}
        else
        {
            sideTaskTxt1.text = "Task 1  -- Classrooms built " + "\n" + "\n" +
                                "Magic Class: " + gamemanager.NumberOfMagic + "\n" +
                                "Surf Class: " + gamemanager.NumberOfSurfing + "\n" +
                                "Hacking Class: " + gamemanager.NumberOfHacking + "\n" +
                                "Axe throwin' Class: " + gamemanager.NumberOfAxeTrowing + "\n";

        }

    }

    public void Task2()
    {
        if (gamemanager.TeacherCount == 5)
        {
            sideTaskTxt2.text = "Nice! You finished your Second side task!";
        }
        //else if ()
        //{
        //    
        //}
        else
        {
            sideTaskTxt2.text = "Task 2  -- Hire 5 teachers";

        }

    }

    public void Task3()
    {
        if (gamemanager.StudentCount1 == 10)
        {
            sideTaskTxt3.text = "Nice! You finished your Second side task!";
        }
        //else if ()
        //{
        //    
        //}
        else
        {
            sideTaskTxt3.text = "Task 3  -- Have 10 Students";
        }

    }

}
