using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class Loading : MonoBehaviour
{
    private AsyncOperation async;
    [SerializeField] private Image circle; //circle loading image   
    private float rotateSpeed = 1f; //ll speed for the circle loading image
    [SerializeField] public static int sceneToLoad = 0;

    private bool ready = false;
    
    [SerializeField] private bool waitForUserInput = true;

    void Start()
    {
        
        //circle.fillAmount = 0;
        Time.timeScale = 1;
        Scene currentScene = SceneManager.GetActiveScene();//current scene 
        if (sceneToLoad == 1)
        {
            async = SceneManager.LoadSceneAsync(currentScene.buildIndex + 1);//load next scene
        }
        else
        {
            async = SceneManager.LoadSceneAsync(sceneToLoad);
        }
        async.allowSceneActivation = false;

    }


    public void Activate()
    {
        ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (circle)
        {
            circle.fillAmount = Mathf.Lerp(circle.fillAmount, 1+ circle.fillAmount, Time.deltaTime * rotateSpeed);
            if (circle.fillAmount >= 1)
            {
                circle.fillAmount = 0;
            }
        }

        if (waitForUserInput && Input.anyKey)
        {
            ready = true;
        }

        if (ready)
        {

            async.allowSceneActivation = true;

        }
    }
}
