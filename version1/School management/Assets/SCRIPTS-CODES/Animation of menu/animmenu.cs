using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animmenu : MonoBehaviour
{
    private bool toggle = true;
    public void MainMenuanim()
    {
        if (toggle==true)
        {
            GetComponent<Animator>().Play("MainMenuAnim");
            toggle = false;
        }
        else if(toggle==false)
        {
            GetComponent<Animator>().Play("closemenu");
             toggle = true;
        }
    }
    
}
