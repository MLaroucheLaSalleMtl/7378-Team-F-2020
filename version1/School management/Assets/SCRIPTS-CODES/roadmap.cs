using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roadmap : MonoBehaviour
{
    taskRewards rewards;

    //Pause & Exit Buttons
    public static bool roadmapActivation = false;

    public GameObject roadmapBTN;
    public GameObject roadmapIMG;

    public Text sideTaskTxt1;
    public Text sideTaskTxt2;
    public Text sideTaskTxt3;
    public Text sideTaskTxt4;
    public Text sideTaskTxt5;

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
        rewards = taskRewards.instance;
    }

    // Update is called once per frame
    void Update()
    {
        Task1();
        Task2();
        Task3();
        Task4();
        Task5();

    }

    public void Task1()
    {
        if (gamemanager.NumberOfMagic == 1 && gamemanager.NumberOfSurfing == 1 && gamemanager.NumberOfHacking == 1 && gamemanager.NumberOfAxeTrowing == 1)
        {
            sideTaskTxt1.text = "Nice! You finished your first side task!";
            rewards.rewardSystem();
        }
        else if (gamemanager.NumberOfMagic >= 1 && gamemanager.NumberOfSurfing >= 1 && gamemanager.NumberOfHacking >= 1 && gamemanager.NumberOfAxeTrowing >= 1)
        {
            sideTaskTxt1.text = "Task 1 - Completed!";
        }
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
            rewards.rewardSystem();
        }
        else if (gamemanager.TeacherCount >= 5)
        {
            sideTaskTxt2.text = "Task 2 - Completed!";
        }
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
            rewards.rewardSystem();
        }
        else if (gamemanager.StudentCount1 >= 10)
        {
            sideTaskTxt3.text = "Task 3 - Completed!";
        }
        else
        {
            sideTaskTxt3.text = "Task 3  -- Have 10 Students";
        }

    }

    public void Task4()
    {
        if (gamemanager.PlayerLevel == 15)
        {
            sideTaskTxt4.text = "Nice! You finished your third side task!";
            rewards.rewardSystem();
        }
        else if (gamemanager.PlayerLevel >= 15)
        {
            sideTaskTxt4.text = "Task 4 - Completed!";
        }
        else
        {
            sideTaskTxt4.text = "Task 4  -- Get to lvl 15";
        }

    }

    public void Task5()
    {
        if (gamemanager.Money == 1000)
        {
            sideTaskTxt5.text = "Nice! You finished your fourth side task!";
            rewards.rewardSystem();
            
        }
        else if (gamemanager.Money >= 1000)
        {
            sideTaskTxt5.text = "Task 5 - Completed!";
        }
        else
        {
            sideTaskTxt5.text = "Task 5  -- Get 1K Gold";
        }

    }

}
