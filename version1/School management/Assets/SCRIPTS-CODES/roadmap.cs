using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadmap : MonoBehaviour
{

    //Pause & Exit Buttons
    public static bool roadmapActivation = false;

    public GameObject roadmapBTN;
    public GameObject roadmapIMG;

    

    public void openRoadmap()
    {
        roadmapIMG.SetActive(true);
        roadmapActivation = true;
    }

    public void closeRoadmap()
    {
        roadmapIMG.SetActive(false);
        roadmapActivation = false;
    }

    public void DoRoadmap()
    {
        if (roadmapActivation)
        {
            closeRoadmap();
            Debug.Log("close roadmap");
        }
        else
        {
            openRoadmap();
            Debug.Log("open roadmap");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        roadmapIMG.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
