using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTime : MonoBehaviour
{
    public static bool timeStoped = false;

    // using SHIFT the player can speed up the game time or slow down the time
    public void stop()
    {
        Time.timeScale = 0f;
        timeStoped = true;
        Debug.Log("STOP Time");

    }

    public void play()
    {
        Time.timeScale = 1f;
        timeStoped = false;
        Debug.Log("PLAY Time");
    }



    void Start()
    {

    }


    void Update()
    {
        if (Input.GetButtonUp("space")) // Both Shift keys will work :)
        {
            if (timeStoped)
            {
                play();
            }
            else
            {
                stop();

            }
        }

    }
}
