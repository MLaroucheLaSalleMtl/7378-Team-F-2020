using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
            //Destroy(gameObject);
        }
   
    }

    GameManager gameManager;

    SpawnLobby lobbyScript;

    SpawnAdmin adminScript;

    SpawnCaff caffScript;

    TeacherMono teachermono;

    HireSecretary secretaryScript;

    taskRewards rewards;

    FloorUI floorUI;



    [SerializeField] private GameObject[] taskPanels;
    // [SerializeField] private GameObject[] taskBTNS;

    [SerializeField] private GameObject taskArrow;

    [Header("Sparkles/Glow objective indicator")]
    [SerializeField] public GameObject[] SparklesForObj;

    [Header("Sparkle Spawn point")]
    [SerializeField] private Vector3 SparklePos;

    [Header("Task SFX")]
    public AudioClip sfx;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

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

    [Header("Objectives 6")]
    private int sfloor = 1;

    [Header("Objectives 7")]
    private int tfloor = 2;

    int indexer = 0;


    void Start()
    {
        gameManager = GameManager.instance;
        secretaryScript = HireSecretary.instance;
        lobbyScript = SpawnLobby.instance;
        adminScript = SpawnAdmin.instance;
        caffScript = SpawnCaff.instance;
        rewards = taskRewards.instance;
        floorUI = FloorUI.instance;


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
        sfxStuff();
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
            case 6: { secondFloor();  } break;
            case 7: { thirdFloor(); } break;
            case 8: { clearPlayerLog(); } break;
            case 9: { payTeacher(); } break;
            case 10: { pressY(); } break;
            case 11: { zoomCamera(); } break;
            case 12: { pressW(); } break;
            case 13: { pressA(); } break;
            case 14: { pressS(); } break;
            case 15: { pressD(); } break;

            default:
                break;
        }
    }
    #region SFX
    public void sfxStuff()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = sfx;

        //SFX volume level
        source.volume = 0.2f;
        source.playOnAwake = false;

    }
    public void playSFX()
    {
        source.PlayOneShot(sfx);
    }
    #endregion

    

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

            //reward
            rewards.rewardSystem();
            

            //sfx 
            playSFX();

            //next task
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

            //reward
            rewards.rewardSystem();

            //sfx
            playSFX();

            //next task
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

            //reward
            rewards.rewardSystem();

            //sfx
            playSFX();

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

            //reward
            rewards.rewardSystem();

            //sfx
            playSFX();

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

            //reward
            rewards.rewardSystem();

            //sfx
            playSFX();

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



            taskPanels[6].SetActive(true);

            //reward
            rewards.rewardSystem();

            //sfx
            playSFX();

            indexer++;
        }

        else
        {
            taskPanels[5].SetActive(true);
        }
    }

    //explore different floors

    public void secondFloor()
    {
        if (floorUI.floor > sfloor)
        {
            if (taskPanels[6] != null)
            {
                taskPanels[6].SetActive(false);
            }



            taskPanels[7].SetActive(true);

            //reward
            rewards.rewardSystem();

            //sfx
            playSFX();

            indexer++;
        }

        else
        {
            taskPanels[6].SetActive(true);
        }
    }

    public void thirdFloor()
    {
        if (floorUI.floor > tfloor)
        {
            if (taskPanels[7] != null)
            {
                taskPanels[7].SetActive(false);
            }



            //taskPanels[8].SetActive(true);

            //reward
            rewards.rewardSystem();

            //sfx
            playSFX();

            indexer++;
        }

        else
        {
            taskPanels[7].SetActive(true);
        }
    }

    //clear player log

    public void clearPlayerLog()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (taskPanels[8] != null)
            {
                taskPanels[8].SetActive(false);
            }



            //taskPanels[9].SetActive(true);

            //reward
            rewards.rewardSystem();

            //sfx
            playSFX();

            indexer++;
        }

        else
        {
            taskPanels[8].SetActive(true);
        }
    }

    //pay the teacher

    public void payTeacher()
    {
        if (gameManager.playerPaidSalary == true)
        {
            if (taskPanels[9] != null)
            {
                taskPanels[9].SetActive(false);
            }


            taskPanels[10].SetActive(true);

            //reward
            rewards.rewardSystem();

            //sfx
            playSFX();

            indexer++;
        }

        else
        {
            taskPanels[9].SetActive(true);
        }
    }

    //camera quest

    public void pressY()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (taskPanels[10] != null)
            {
                taskPanels[10].SetActive(false);
            }



            taskPanels[11].SetActive(true);

            //reward
            rewards.rewardSystem();

            //sfx
            playSFX();

            indexer++;
        }

        else
        {
            taskPanels[10].SetActive(true);
        }
    }

    public void zoomCamera()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (taskPanels[11] != null)
            {
                taskPanels[11].SetActive(false);
            }



            taskPanels[12].SetActive(true);

            //reward
            rewards.rewardSystem();

            //sfx
            playSFX();

            indexer++;
        }

        else
        {
            taskPanels[11].SetActive(true);
        }
    }

    // camera basic movement

    public void pressW()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (taskPanels[12] != null)
            {
                taskPanels[12].SetActive(false);
            }



            taskPanels[13].SetActive(true);

            //reward
            rewards.rewardSystem();

            //sfx
            playSFX();

            indexer++;
        }

        else
        {
            taskPanels[12].SetActive(true);
        }
    }

    public void pressA()
    {
        if (Input.GetKeyDown(KeyCode.A)) //&& Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.D)
        {
            if (taskPanels[13] != null)
            {
                taskPanels[13].SetActive(false);
            }



            taskPanels[14].SetActive(true);

            //reward
            rewards.rewardSystem();

            //sfx
            playSFX();

            indexer++;
        }

        else
        {
            taskPanels[13].SetActive(true);
        }
    }

    public void pressS()
    {
        if (Input.GetKeyDown(KeyCode.S)) //&& Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.D)
        {
            if (taskPanels[14] != null)
            {
                taskPanels[14].SetActive(false);
            }



            taskPanels[15].SetActive(true);

            //reward
            rewards.rewardSystem();

            //sfx
            playSFX();

            indexer++;
        }

        else
        {
            taskPanels[14].SetActive(true);
        }
    }

    public void pressD()
    {
        if (Input.GetKeyDown(KeyCode.D)) //&& Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.D)
        {

            if (taskPanels[15] != null)
            {
                taskPanels[15].SetActive(false);
            }



            //taskPanels[16].SetActive(true);

            //reward
            rewards.rewardSystem();

            //sfx
            playSFX();

            indexer++;
        }

        else
        {
            taskPanels[15].SetActive(true);
        }
    }

    // camera rotation

    public void pressQ()
    {
        if (Input.GetKey("q")) //&& Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.D)
        {

            if (taskPanels[16] != null)
            {
                taskPanels[16].SetActive(false);
            }



            taskPanels[17].SetActive(true);

            //reward
            rewards.rewardSystem();

            //sfx
            playSFX();

            indexer++;
        }

        else
        {
            taskPanels[16].SetActive(true);
        }
    }

    public void pressE()
    {
        if (Input.GetKey("e")) //&& Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.D)
        {

            if (taskPanels[17] != null)
            {
                taskPanels[17].SetActive(false);
            }



            taskPanels[18].SetActive(true);

            //reward
            rewards.rewardSystem();

            //sfx
            playSFX();

            indexer++;
        }

        else
        {
            taskPanels[17].SetActive(true);
        }
    }

    /// TO DO: 
    /// - go into the setting and select "Controls"

    public void RemoveArrow()
    {
        taskArrow.SetActive(false);
    }


}




    
   

