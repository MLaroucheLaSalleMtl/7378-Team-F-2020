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

    GameManager gamemanager;

    PlayerLog eventLog;

    public GameObject[] cameralevels;

    [Header("Unlock Pannels")]
    [SerializeField] private GameObject[] Pannels;



    void Start()
    {
        floorui = FloorUI.instance;
        gamemanager = GameManager.instance;
        eventLog = PlayerLog.instance;
    }


    public void changecamera()
    {
        for (int i = 0; i < cameralevels.Length; i++)
        {

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
    public void changecamera(int indexer)
    {
        for (int i = 0; i < cameralevels.Length; i++)
        {

            if (i == indexer)
            {
                if (i == 0) { cameralevels[i].transform.position = cameralevels[i + 1].transform.position; } else { cameralevels[i].transform.position = cameralevels[i - 1].transform.position; }

                cameralevels[indexer].SetActive(true);
            }
            else
            {
                cameralevels[i].SetActive(false);
            }
        }

    }

    public void unlock2ndfloor()
    {
        if (gamemanager.Money < 500)
        {
            eventLog.AddEvent("Not enough Gold to unlock");
            Debug.Log("Not enough Gold to unlock");
            return;
        }
        else
        {
            gamemanager.ReduceMoney(500);
            Destroy(Pannels[0]);
        }
    }

    public void unlock3rdfloor()
    {
        if (gamemanager.Money < 1000)
        {
            eventLog.AddEvent("Not enough Gold to unlock");
            Debug.Log("Not enough Gold to unlock");
            return;
        }
        else
        {
            gamemanager.ReduceMoney(1000);
            Destroy(Pannels[1]);
        }
    }

}
