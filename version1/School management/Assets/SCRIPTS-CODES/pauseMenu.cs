using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{

    

    //Pause & Exit Buttons
    public static bool gamePaused = false;
    public GameObject btnQuit;
    public GameObject btnRestart;
    public GameObject btnResume;
    public GameObject btnControls;
    public GameObject btnSHIFT;
    public GameObject btnSPACEBAR;


    //Pause & Exit BG
    public GameObject pauseTxt;
    public GameObject pauseBG;

    public string sceneToReload = "SampleScene";

    //timescale
    private float timeScale = 45f;

    //Buttons for pauseMenu
    public void DoQuit()
    {
        SceneManager.LoadScene(0);
    }
    public void DoRestart()
    {
        SceneManager.LoadScene(sceneToReload);
    }

    public void DoResume()
    {
        unPause();
    }

    public void DoControl()
    {

        control();
    }

    public void DoPause()
    {
        if (gamePaused)
        {
            unPause();
            Debug.Log("unpaused");
        }
        else
        {
            Pause();
            Debug.Log("Paused");
        }
    }


    //Pause Menu Boolean activation

    public void Pause()
    {
        Time.timeScale = 0;
        pauseTxt.SetActive(true);
        btnQuit.SetActive(true);
        btnRestart.SetActive(true);
        btnResume.SetActive(true);
        btnControls.SetActive(true);
        pauseBG.SetActive(true);
        btnSHIFT.SetActive(false);
        btnSPACEBAR.SetActive(false);
        gamePaused = true;
    }

    public void unPause()
    {
        //Restarts the time when unpaused but timescale doesn't start right away??? :omegaMonka:
        Time.timeScale = timeScale;
        pauseTxt.SetActive(false);
        btnQuit.SetActive(false);
        btnRestart.SetActive(false);
        btnResume.SetActive(false);
        btnControls.SetActive(false);
        pauseBG.SetActive(false);
        btnSHIFT.SetActive(false);
        btnSPACEBAR.SetActive(false);
        gamePaused = false;
    }


    public void control()
    {
        //Restarts the time when unpaused but timescale doesn't start right away??? :omegaMonka:
        Time.timeScale = 0;
        pauseTxt.SetActive(true);
        btnQuit.SetActive(false);
        btnRestart.SetActive(false);
        btnResume.SetActive(true);
        btnControls.SetActive(false);
        pauseBG.SetActive(true);
        btnSHIFT.SetActive(true);
        btnSPACEBAR.SetActive(true);
        gamePaused = true;
    }

    void Start()
    {

        //btnQuit.SetActive(false);
        //btnRestart.SetActive(false);
        //btnResume.SetActive(false);
        //btnControls.SetActive(false);
        //pauseTxt.SetActive(false);
        //pauseBG.SetActive(false);
        //btnSHIFT.SetActive(false);
        //btnSPACEBAR.SetActive(false);
    }


    

    // Update is called once per frame
    void Update()
    {

        //ESC to pause the game
        if (Input.GetButtonUp("Cancel"))
        {
            if (gamePaused)
            {
                unPause();
                Debug.Log("unpaused");
            }
            else
            {
                Pause();
                Debug.Log("Paused");
            }
        }
    }
}
