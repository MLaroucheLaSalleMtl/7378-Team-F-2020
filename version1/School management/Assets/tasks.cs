using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tasks : MonoBehaviour
{
    public GameManager gameManager;

    public SpawnLobby lobbyScript;


    [SerializeField] private GameObject[] taskPanels;
    [SerializeField] private GameObject[] taskBTNS;

    



    [Header("Objectives 1")]
    private int classRoom = 1; //player must have this many classes built to complete Objective 1

    [Header("Objectives 2")]
    private int Teacher = 1; 

    [Header("Objectives 3")]
    private int LobbyBuilt = 0; 

    [Header("Objectives 4")]
    private int coinGoal = 400; //player must make this much money to complete Objective 2



    public void classRoomGoals()
    {
        if (gameManager.ClassRCount >= classRoom)
        {
            if (taskPanels[0] != null)
            {
                taskPanels[0].SetActive(false);
            }

            
            Destroy(taskBTNS[0].gameObject);

            taskPanels[1].SetActive(true);
            taskBTNS[1].SetActive(true);

        }

        else
        {
            taskPanels[0].SetActive(true);
        }
    }

    public void TeacherGoals()
    {
        if (gameManager.TeacherCount >= Teacher)
        {
            if (taskPanels[1] != null)
            {
                taskPanels[1].SetActive(false);
            }

            Destroy(taskBTNS[1].gameObject);

            taskPanels[2].SetActive(true);
            taskBTNS[2].SetActive(true);

        }

        else
        {
            taskPanels[1].SetActive(true);
        }
    }


    public void LobbyGoals()
    {
        if (lobbyScript.LobbyMade > LobbyBuilt)
        {
            if (taskPanels[2] != null)
            {
                taskPanels[2].SetActive(false);
            }

            Destroy(taskBTNS[2].gameObject);

            taskPanels[3].SetActive(true);
            taskBTNS[3].SetActive(true);

        }

        else
        {
            taskPanels[2].SetActive(true);
        }
    }



    public void coinGoals()
    {
        if (gameManager.Money >= coinGoal)
        {
            if (taskPanels[3] != null)
            {
                taskPanels[3].SetActive(false);
               
            }

           
            Destroy(taskBTNS[3].gameObject);
            //SceneManager.LoadScene(3);

        }

        else
        {
            taskPanels[3].SetActive(true);
        }

        
    }


    
    void Start()
    {
        gameManager = GameManager.instance;
        lobbyScript = SpawnLobby.instance;

        ////second objectives
        //taskPanels[1].SetActive(false);
        //taskBTNS[1].SetActive(false);
        ////third objectives
        //taskPanels[2].SetActive(false);
        //taskBTNS[2].SetActive(false);
        ////third objectives
        //taskPanels[3].SetActive(false);
        //taskBTNS[3].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
