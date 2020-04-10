using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorUI : MonoBehaviour
{
    #region Singleton to change the camera view
    public static FloorUI instance = null;
    public int floor; 

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

    [SerializeField] public GameObject[] floorTxt;
    
    public int indexer = 0;

    public void firstFloor()
    {
        floorTxt[0].SetActive(true);
        floorTxt[1].SetActive(false);
        floorTxt[2].SetActive(false);
    }
    public void secondFloor()
    {
        floorTxt[0].SetActive(false);
        floorTxt[1].SetActive(true);
        floorTxt[2].SetActive(false);
        floor = 2;
    }
    public void thirdFloor()
    {
        floorTxt[0].SetActive(false);
        floorTxt[1].SetActive(false);
        floorTxt[2].SetActive(true);
        floor = 3;
    }

    public void clickNext()
    {
        
        if (indexer >= 3)
        {
            indexer = default;
            floorsystem.instance.changecamera(indexer);
        }

        else
        {
            indexer++;
            floorsystem.instance.changecamera();
        }
        
        
    }

    public void clickPrev()
    {
        
        if (indexer == 0)
        {
            indexer = 2;
            floorsystem.instance.changecamera(indexer);
        }

        else
        {
            indexer--;
            floorsystem.instance.changecamera();
        }
        
        
    }



    
    void Update()
    {
        switch (indexer)
        {
            case 1: { secondFloor(); } break;
            case 2: { thirdFloor(); } break;

            default:
                { firstFloor(); }
                break;
        }

    }

    
}

