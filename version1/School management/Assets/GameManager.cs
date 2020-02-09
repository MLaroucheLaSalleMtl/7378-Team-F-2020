using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.IO;

//TODO: 


public class GameManager : MonoBehaviour
{
    //Pause & Exit Buttons
    public static bool gamePaused = false;
    public GameObject btnQuit;
    public GameObject btnRestart;
    public string sceneToReload = "SampleScene";
    public GameObject pauseTxt;
    public GameObject pauseBG;

    //timescale
    [SerializeField] public float timeScale;

    private int StudentCount;
    Text StudentCountText;//"StudentCount"
    Vector3 LocationOfSpawn=new Vector3(6,1,2);
    public static GameManager instance = null;

    string[] Clasesbogth;

    //Percy wtf is Haking? 
    string[] AvalableClases= {"Magic","Surfing","Haking","Axe Trowing"};

    

    List<string> Clases;

    [Header("Student Prefab Toinstanciate")]
    [SerializeField]private GameObject Student;


    //Buttons for pauseMenu
    public void DoQuit()
    {
        SceneManager.LoadScene(0);
    }
    public void DoRestart()
    {
        SceneManager.LoadScene(sceneToReload);
    }

    //Pause Menu Boolean activation
    
    public void Pause()
    {
        Time.timeScale = 0;
        pauseTxt.SetActive(true);
        btnQuit.SetActive(true);
        btnRestart.SetActive(true);
        pauseBG.SetActive(true);
        gamePaused = true;
    }

    public void unPause()
    {
        //Restarts the time when unpaused but timescale doesn't start right away??? :omegaMonka:
        Time.timeScale = timeScale;
        pauseTxt.SetActive(false);
        btnQuit.SetActive(false);
        btnRestart.SetActive(false);
        pauseBG.SetActive(false);
        gamePaused = false;
    }

    

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

    void Start()
    {
        StudentCountText =GameObject.FindGameObjectWithTag("StudentCount").GetComponent<Text>();

        //Pause Menu ... :monkaS:
        btnQuit.SetActive(false);
        btnRestart.SetActive(false);
        pauseTxt.SetActive(false);
        pauseBG.SetActive(false);
    }

    
    void Update()
    {
        RefreshTextOnUI();

        //ESC to pause the game
        if (Input.GetButtonUp("Cancel")) 
        {
            if (gamePaused)
            {
                unPause();
            }
            else
            {
                Pause();
            }

        }
    }

    public void AddStudent( )
    {
        StudentCount++;

    }

    public void RefreshTextOnUI()
    {
        StudentCountText.text = "Students: "+StudentCount;
    }

    public void Spawn(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Instantiate(Student, LocationOfSpawn, Quaternion.identity);
        }
    }
}
