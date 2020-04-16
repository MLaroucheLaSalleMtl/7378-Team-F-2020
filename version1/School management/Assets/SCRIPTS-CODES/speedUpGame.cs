using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedUpGame : MonoBehaviour
{

    public static bool gameSpeedUp = false;
   
    // using SHIFT the player can speed up the game time or slow down the time
    public void Speed()
    {
        Time.timeScale = Time.timeScale =3;
        gameSpeedUp = true;
        Debug.Log("Speen ON");
        
    }

    public void unSpeed()
    {
        Time.timeScale=Time.timeScale=1;
        gameSpeedUp = false;
        Debug.Log("Speed OFF");
    }

    public void DoSpeed()
    {
        Speed();
    }

    public void DoUnspeed()
    {
        unSpeed();
    }
   
    void Start()
    {
        
    }

  
    void Update()
    {
        if (Input.GetButtonUp("Left Shift") || Input.GetButtonUp("Right Shift")) // Both Shift keys will work :)
        {
            if (gameSpeedUp)
            {
                unSpeed();
            }
            else
            {
                Speed();
               
            }
        }
       
    }
}
