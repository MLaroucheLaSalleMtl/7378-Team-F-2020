using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{

    [SerializeField] private GameObject[] panels;
    [SerializeField] private Selectable[] defaultButtons;

    public void PanelToggle(int position)
    {
        Input.ResetInputAxes();
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(position == i);
            if (position == i)
            {
                // defaultButtons[i].Select(); dont need this anymore?
            }
        }
    }
   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
