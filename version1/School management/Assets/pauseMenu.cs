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
    public string sceneToReload = "SampleScene";
    public GameObject pauseTxt;
    public GameObject pauseBG;

    //timescale
    [SerializeField] public float timeScale;

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

    void Start()
    {
        //Pause Menu ... :monkaS:
        btnQuit.SetActive(false);
        btnRestart.SetActive(false);
        pauseTxt.SetActive(false);
        pauseBG.SetActive(false);
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
            }
            else
            {
                Pause();
            }
        }
    }
}
