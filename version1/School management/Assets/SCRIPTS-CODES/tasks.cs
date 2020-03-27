using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tasks : MonoBehaviour
{
    public static tasks instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    GameManager gameManager;

    SpawnLobby lobbyScript;

    SpawnAdmin adminScript;

    SpawnCaff caffScript;

    TeacherMono teachermono;

    HireSecretary secretaryScript;

   

    [SerializeField] private GameObject[] taskPanels;
    // [SerializeField] private GameObject[] taskBTNS;

    [SerializeField] private GameObject taskArrow;

    [Header("Sparkles/Glow objective indicator")]
    [SerializeField] public GameObject[] SparklesForObj;

    [Header("Sparkle Spawn point")]
    [SerializeField] private Vector3 SparklePos;



    [Header("Objectives 0")]
    private int classRoom = 1; 

    [Header("Objectives 1")]
    private int Teacher = 1;

    [Header("Objectives 2")]
    private int LobbyBuilt = 0;

    [Header("Objectives 3")]
    private int AdminBuilt = 0;

    [Header("Objectives 4")]
    private int noSecretary = 0;

    [Header("Objectives 5")]
    private int CaffBuilt = 0;

    int indexer = 0;


    void Start()
    {
        gameManager = GameManager.instance;
        secretaryScript = HireSecretary.instance;
        lobbyScript = SpawnLobby.instance;
        adminScript = SpawnAdmin.instance;
        caffScript = SpawnCaff.instance;
        

        #region hidden task
        ////second objectives
        //taskPanels[1].SetActive(false);
        //taskBTNS[1].SetActive(false);
        ////third objectives
        //taskPanels[2].SetActive(false);
        //taskBTNS[2].SetActive(false);
        ////third objectives
        //taskPanels[3].SetActive(false);
        //taskBTNS[3].SetActive(false);
        #endregion

        SparklesForObj[0].SetActive(true);
    }

    void Update()
    {
        switch (indexer)
        {
            case 0: { classRoomGoals(); } break;
            case 1: { TeacherGoals(); } break;
            case 2: { LobbyGoals(); } break;
            case 3: { AdminGoals(); } break;
            case 4: { SecretaryGoal(); } break;
            case 5: { CaffGoals(); } break;

            default:
                break;
        }
    }


    public void classRoomGoals()
    {
        if (gameManager.ClassRCount >= classRoom)
        {
            if (taskPanels[0] != null)
            {
                taskPanels[0].SetActive(false);
            }


            taskPanels[1].SetActive(true);
          

            SparklesForObj[1].SetActive(true);

            indexer++;
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

           


            taskPanels[2].SetActive(true);
            SparklesForObj[2].SetActive(true);

            indexer++;
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


            SparklesForObj[3].SetActive(true);
            taskPanels[3].SetActive(true);
       
            
            indexer++;
        }

        else
        {
            taskPanels[2].SetActive(true);
        }
    }


    public void AdminGoals()
    {
        if (adminScript.AdminMade > AdminBuilt) 
        {
            if (taskPanels[3] != null)
            {
                taskPanels[3].SetActive(false);
            }


            SparklesForObj[4].SetActive(true);
            taskPanels[4].SetActive(true);


            indexer++;
        }

        else
        {
            taskPanels[4].SetActive(true);
        }
    }


    public void SecretaryGoal()
    {
        if (gameManager.AdminCount > noSecretary)
        {
            if (taskPanels[4] != null)
            {
                taskPanels[4].SetActive(false);

            }



            SparklesForObj[5].SetActive(true);
            taskPanels[5].SetActive(true);

            indexer++;
        }

        else
        {
            taskPanels[4].SetActive(true);
        }
    }

    public void CaffGoals()
    {
        if (caffScript.CaffMade > CaffBuilt)
        {
            if (taskPanels[5] != null)
            {
                taskPanels[5].SetActive(false);
            }

      

            //taskPanels[6].SetActive(true);
           

            indexer++;
        }

        else
        {
            taskPanels[5].SetActive(true);
        }
    }




    public void RemoveArrow()
    {
        taskArrow.SetActive(false);
    }


}




    
   

