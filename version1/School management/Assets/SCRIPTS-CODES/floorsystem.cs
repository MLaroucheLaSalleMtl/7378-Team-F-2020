using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorsystem : MonoBehaviour
{

    #region Singleton to change the camera view
    public static floorsystem instance = null;
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
    #endregion

    private FloorUI floorui;

    [SerializeField] private GameObject[] cameralevels;

    void Start()
    {
        floorui = FloorUI.instance;
    }

    
    public void changecamera()
    {
        for (int i=0;i<cameralevels.Length;i++) {
            
            if (i == floorui.indexer)
            {
                if (i == 0) { cameralevels[i].transform.position = cameralevels[i + 1].transform.position; } else { cameralevels[i].transform.position = cameralevels[i - 1].transform.position; }
               
                cameralevels[floorui.indexer].SetActive(true);
            }
            else
            {
                cameralevels[i].SetActive(false);
            }
        }
        
    }
    
}
